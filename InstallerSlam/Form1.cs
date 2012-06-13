using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Common;
using System.IO;
using System.Management;
using System.Diagnostics;
using Microsoft.Win32;
using System.Xml;
using System.Runtime.InteropServices;


namespace InstallerSlam
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Application.EnableVisualStyles();
        }

        string discoSlam = string.Empty; //@"E:\Slam Tenis\"; //string.Empty;

        private void FrmCrearBase_Load(object sender, EventArgs e)
        {
            this.Activate();
            ManagementClass partionsClass = new ManagementClass("Win32_LogicalDisk");
            ManagementObjectCollection partions = partionsClass.GetInstances();

            string hdd = string.Empty;
            bool cdslam = false;
            string Unidad = string.Empty;
            foreach (ManagementObject partion in partions)
            {
                hdd = Convert.ToString(partion["VolumeName"]);
                if (hdd == "Slam Tenis")
                {
                    Unidad = Convert.ToString(partion["DeviceID"]);
                    //cdslam = true;
                }
            }

            if (!cdslam)
            {
                MessageBox.Show("Falta insetar el cd de instalacion de Slam Tenis", "Slam Tenis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //this.Close();
            }
            else
            {
                discoSlam = Unidad;
            }

        }

      
        bool AplicacionInstalada(string Nombre)
        {
            string registryKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            bool MSSql = false;
            
            using (Microsoft.Win32.RegistryKey key = Registry.LocalMachine.OpenSubKey(registryKey))
            {
                var query = from a in key.GetSubKeyNames()
                            let r = key.OpenSubKey(a)
                            select new
                            {
                                Application = r.GetValue("DisplayName")
                            };

                foreach (var item in query)
                {
                    if (item.Application != null)
                    {
                        if (item.Application.ToString() == Nombre)
                        {
                            MSSql = true;
                        }
                    }
                }
            }
            return MSSql;
        }

        private void BtnSql_Click(object sender, EventArgs e)
        {
            try
            {
                if (AplicacionInstalada("Microsoft SQL Server 2005") || AplicacionInstalada("Microsoft SQL Server 2008") || AplicacionInstalada("Microsoft SQL Server 2008 R2") || AplicacionInstalada("Microsoft SQL Server 2008 R2 Native Client"))
                {
                    PnlSqlServer.Visible = true;
                }
                else
                {
                    if (Marshal.SizeOf(typeof(IntPtr)) == 8)
                    {
                        throw new Exception("El instalador de SQL Server no es compatible con Sistemas X64 por favor instale manualmente y vuelva a instentarlo");
                    }
                    //else
                    //{
                    //    Process.Start(discoSlam + @"Base de Datos\SQL SERVER\sqlexpr32.exe");
                    //}

                    //Process.Start(discoSlam + @"Base de Datos\SQL SERVER\sqlexpr32.exe");

                    bool running = true;
                    while (running != false)
                    {
                        running = Running("sqlexpr32");
                        Application.DoEvents();
                        if (running)
                        {
                            System.Threading.Thread.Sleep(5000);
                        }
                    }

                    XmlNodeList ListaNodos;
                    XmlDocument doc = new XmlDocument();
                    string dir = System.AppDomain.CurrentDomain.BaseDirectory + "\\Configuracion.xml";
                    try
                    {
                        doc.Load(dir);
                    }
                    catch (Exception)
                    {
                        throw new Exception("El archivo de Configuración no se encuentra.");
                    }

                    ListaNodos = doc.GetElementsByTagName("config");

                    try
                    {
                        string cadena = string.Empty;
                        cadena = "Server=(Local)\\SQLEXPRESS;Database=master;Integrated Security =SSPI;";

                        string script = string.Empty;
                        //Crear la base de datos

                        script += " USE master";
                        script += " ";
                        script += " if exists(select * from sysdatabases where name= 'SlamDB')";
                        script += " BEGIN";
                        script += "      drop database SlamDB";
                        script += " END";
                        script += " DECLARE @device_directory NVARCHAR(520),@comando varchar(500)";
                        script += " set @device_directory = ''";
                        script += " set @comando = ''";
                        script += " SELECT @device_directory = SUBSTRING(filename, 1, CHARINDEX(N'master.mdf', LOWER(filename)) - 1)";
                        script += " FROM master.dbo.sysaltfiles WHERE dbid = 1 AND fileid = 1";
                        script += " set @comando = N'CREATE DATABASE [SlamDB] ON PRIMARY (NAME = N' + char(39) + 'SlamDB' + char(39) + ', FILENAME = N' + char(39) + @device_directory + N'SlamDB.mdf' + char(39) + ') LOG ON (NAME = N' + char(39) + 'SlamDB_log' + char(39) + ',  FILENAME = N' + char(39) + '' + @device_directory + N'SlamDB.ldf' + char(39) + ')'";
                        script += " Execute(@comando)";
                        script += " ";


                        ListaNodos[0].Attributes["ConnectionString"].Value = cadena;
                        ListaNodos[0].Attributes["Default"].Value = "True";
                        ListaNodos[1].Attributes["Default"].Value = "False";
                        doc.Save(dir);

                        Repositorio.Conexiones.Conexion cnn = new Repositorio.Conexiones.Conexion();
                        cnn.ActualizarOEliminar(script);
                        GC.Collect();
                        GC.SuppressFinalize(cnn);

                        //Restaurar la base

                        script = string.Empty;

                        System.IO.StreamReader stream = new System.IO.StreamReader(discoSlam + @"Base de Datos\SQL SERVER\SlamDB.sql");
                        script = stream.ReadToEnd();
                        stream.Close();

                        cnn.ActualizarOEliminar(script);
                        GC.Collect();
                        GC.SuppressFinalize(cnn);

                        doc.Load(dir);
                        ListaNodos[0].Attributes["ConnectionString"].Value = cadena.Replace("master", "SlamDb");
                        ListaNodos[0].Attributes["Default"].Value = "True";
                        ListaNodos[1].Attributes["Default"].Value = "False";
                        doc.Save(dir);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    groupBox1.Visible = false;
                    groupBox2.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ah ocurrido un error en la instalacion error devuelto: " + ex.Message, "Instalacion de Slam Tenis", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (System.IO.Directory.Exists(@"C:\inetpub\wwwroot\"))
                {
                    System.IO.DirectoryInfo direc = new DirectoryInfo(discoSlam + @"Web Slam\");
                    if (System.IO.Directory.Exists(@"C:\inetpub\wwwroot\SlamWeb\"))
                    {
                        System.IO.Directory.Delete(@"C:\inetpub\wwwroot\SlamWeb\");
                        System.IO.Directory.CreateDirectory(@"C:\inetpub\wwwroot\SlamWeb\");
                    }
                    else
                    {
                        System.IO.Directory.CreateDirectory(@"C:\inetpub\wwwroot\SlamWeb\");
                    }

                    DirectoryCopy(discoSlam + @"Web Slam\", @"C:\inetpub\wwwroot\SlamWeb\", true);
                    groupBox2.Visible = false;
                    groupBox4.Visible = true;
                }
                else
                {
                    MessageBox.Show("No se encuentre instalado Internet Information Services (IIS) o no es una version compatible, verifique...", "Slam Tenis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch { }
        }

        private void DirectoryCopy(
        string sourceDirName, string destDirName, bool copySubDirs)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            DirectoryInfo[] dirs = dir.GetDirectories();

            // If the source directory does not exist, throw an exception.
            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            // If the destination directory does not exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }


            // Get the file contents of the directory to copy.
            FileInfo[] files = dir.GetFiles();

            foreach (FileInfo file in files)
            {
                // Create the path to the new copy of the file.
                string temppath = Path.Combine(destDirName, file.Name);

                // Copy the file.
                file.CopyTo(temppath, false);
            }

            // If copySubDirs is true, copy the subdirectories.
            if (copySubDirs)
            {

                foreach (DirectoryInfo subdir in dirs)
                {
                    // Create the subdirectory.
                    string temppath = Path.Combine(destDirName, subdir.Name);

                    // Copy the subdirectories.
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (TxtEmail.Text == string.Empty || TxtNombre.Text == string.Empty || TxtClave.Text == string.Empty)
            {
                MessageBox.Show("Por Favor complete todos los campos...", "Configuracion de email", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            groupBox4.Visible = false;
            System.Threading.Thread.Sleep(4000);
            groupBox3.Visible = true;
            System.Threading.Thread hilo = new System.Threading.Thread(GuardarConf);
            hilo.Start();
        }

        void GuardarConf()
        {
            try
            {
                Dominio.ConfEmail email = new Dominio.ConfEmail();

                if (CheckAut.Checked)
                {
                    email.GuardarCuenta(TxtNombre.Text, TxtEmail.Text, TxtClave.Text);
                }
                else
                {
                    email.GuardarCuenta(TxtNombre.Text, TxtEmail.Text, TxtClave.Text);
                }
                Dominio.Email mail = new Dominio.Email();
                mail.Asunto = "Prueba de configuracion";
                mail.EmailDestino = TxtEmail.Text;
                mail.Mensaje = " Este es un email de prueba...";
                mail.Prioridad = Dominio.PrioridadEmail.Normal;
                mail.Enviar();
                string targetDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
                System.IO.File.Copy(Path.Combine(targetDirectory,"Configuracion.xml"), @"C:\inetpub\wwwroot\SlamWeb\Configuracion.xml", true);
                System.IO.File.Copy(Path.Combine(targetDirectory,"CuentaEmail.xml"), @"C:\inetpub\wwwroot\SlamWeb\CuentaEmail.xml", true);
                System.IO.File.Copy(Path.Combine(targetDirectory,"CuentasSMTP.xml"), @"C:\inetpub\wwwroot\SlamWeb\CuentasSMTP.xml", true);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Instalacion de Slam Tenis", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
                
        } 

        bool Running(string app)
        {
            bool running = false;
            foreach (var item in Process.GetProcesses())
            {
                if (item.ProcessName == app)
                {
                    running = true;
                    break;
                }
                else
                {
                    running = false;
                }
            }
            GC.Collect();
            GC.WaitForFullGCComplete();
            return running;
        }

        private void CheckAut_CheckedChanged(object sender, EventArgs e)
        {
            if (!CheckAut.Checked)
            {
                PnlConf.Visible = true;
            }
            else
            {
                PnlConf.Visible = false;
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            if (CheckIniciar.Checked)
            {
                string ubicacion = System.AppDomain.CurrentDomain.BaseDirectory;
                Process.Start(ubicacion + "Slam.exe");
            }
            this.Close();
        }

        private void CheckSWindAut_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckSWindAut.Checked)
            {
                PnlWindowsAut.Visible = false;
            }
            else
            {
                PnlWindowsAut.Visible = true;
            }
        }

        private void BtnContinuarMS_Click(object sender, EventArgs e)
        {
            XmlNodeList ListaNodos;
            XmlDocument doc = new XmlDocument();
            string dir = System.AppDomain.CurrentDomain.BaseDirectory + "\\Configuracion.xml";
            try
            {
                doc.Load(dir);
            }
            catch (Exception)
            {
                throw new Exception("El archivo de Configuración no se encuentra.");
            }

            ListaNodos = doc.GetElementsByTagName("config");

            try
            {
                string cadena = string.Empty;
              
                if (this.CheckSWindAut.Checked)
                    cadena = "Server=" + this.TxtMsServidor.Text + ";Database=master;Integrated Security =SSPI;";
                else
                    cadena = "Server=" + TxtMsServidor.Text + ";Database=master;Uid=" + this.TxtMsUsuario.Text + ";Pwd=" + this.TxtMsClave.Text + ";";

                string script = string.Empty;
                //Crear la base de datos

                script += " USE master";
                script += " ";
                script += " if exists(select * from sysdatabases where name= 'SlamDB')";
                script += " BEGIN";
                script += "      drop database SlamDB";
                script += " END";
                script += " DECLARE @device_directory NVARCHAR(520),@comando varchar(500)";
                script += " set @device_directory = ''";
                script += " set @comando = ''";
                script += " SELECT @device_directory = SUBSTRING(filename, 1, CHARINDEX(N'master.mdf', LOWER(filename)) - 1)";
                script += " FROM master.dbo.sysaltfiles WHERE dbid = 1 AND fileid = 1";
                script += " set @comando = N'CREATE DATABASE [SlamDB] ON PRIMARY (NAME = N' + char(39) + 'SlamDB' + char(39) + ', FILENAME = N' + char(39) + @device_directory + N'SlamDB.mdf' + char(39) + ') LOG ON (NAME = N' + char(39) + 'SlamDB_log' + char(39) + ',  FILENAME = N' + char(39) + '' + @device_directory + N'SlamDB.ldf' + char(39) + ')'";
                script += " Execute(@comando)";
                script += " ";

                ListaNodos[0].Attributes["ConnectionString"].Value = cadena;
                ListaNodos[0].Attributes["Default"].Value = "True";
                ListaNodos[1].Attributes["Default"].Value = "False";
                doc.Save(dir);

                Repositorio.Conexiones.Conexion cnn = new Repositorio.Conexiones.Conexion();
                cnn.ActualizarOEliminar(script);
                GC.Collect();
                GC.SuppressFinalize(cnn);

                //Restaurar la base

                script = string.Empty;

                System.IO.StreamReader stream = new System.IO.StreamReader(discoSlam + @"Base de Datos\SQL SERVER\SlamDB.sql");
                script = stream.ReadToEnd();
                stream.Close();

                cnn.ActualizarOEliminar(script);
                GC.Collect();
                GC.SuppressFinalize(cnn);

                doc.Load(dir);
                ListaNodos[0].Attributes["ConnectionString"].Value = cadena.Replace("master", "SlamDb");
                ListaNodos[0].Attributes["Default"].Value = "True";
                ListaNodos[1].Attributes["Default"].Value = "False";
                doc.Save(dir);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            groupBox1.Visible = false;
            groupBox2.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            groupBox4.Visible = true;
        }

        private void BtnContinuarMy_Click(object sender, EventArgs e)
        {
            XmlNodeList ListaNodos;
            XmlDocument doc = new XmlDocument();
            string dir = System.AppDomain.CurrentDomain.BaseDirectory + "\\Configuracion.xml";
            try
            {
                doc.Load(dir);
            }
            catch (Exception)
            {
                throw new Exception("El archivo de Configuración no se encuentra.");
            }

            ListaNodos = doc.GetElementsByTagName("config");

            try
            {
                string cadena = string.Empty;
                cadena = "Server=" + TxtServidorMy.Text + ";Database=mysql;Uid=" + TxtUsuarioMY.Text + ";Pwd=" + TxtClaveMy.Text +";";
                string script = string.Empty;
                System.IO.StreamReader stream = new System.IO.StreamReader(discoSlam + @"Base de Datos\MySQL\MySqlSlamDb.sql");
                script = stream.ReadToEnd();
                stream.Close();

                ListaNodos[0].Attributes["Default"].Value = "False";
                ListaNodos[1].Attributes["ConnectionString"].Value = cadena;
                ListaNodos[1].Attributes["Default"].Value = "True";
                doc.Save(dir);

                Repositorio.Conexiones.Conexion cnn = new Repositorio.Conexiones.Conexion();
                cnn.ActualizarOEliminar(script);
                GC.Collect();
                GC.SuppressFinalize(cnn);

                doc.Load(dir);
                ListaNodos[0].Attributes["Default"].Value = "False";
                ListaNodos[1].Attributes["ConnectionString"].Value = cadena.Replace("mysql", "SlamDb");
                ListaNodos[1].Attributes["Default"].Value = "True";
                doc.Save(dir);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            groupBox1.Visible = false;
            groupBox2.Visible = true;
        }

        private void BtnMySQl_Click(object sender, EventArgs e)
        {
            if (AplicacionInstalada("MySQL Server 5.0"))
            {
                this.PnlMySQL.Visible = true;
            }
            else
            {
                Process.Start(discoSlam + @"Base de Datos\MySQL\MySQL-Setup.exe");

                bool running = true;
                while (running != false)
                {
                    running = Running("MySQL-Setup");
                    Application.DoEvents();
                    if (running)
                    {
                        System.Threading.Thread.Sleep(5000);
                    }
                }

                XmlNodeList ListaNodos;
                XmlDocument doc = new XmlDocument();
                string dir = System.AppDomain.CurrentDomain.BaseDirectory + "\\Configuracion.xml";
                try
                {
                    doc.Load(dir);
                }
                catch (Exception)
                {
                    throw new Exception("El archivo de Configuración no se encuentra.");
                }

                ListaNodos = doc.GetElementsByTagName("config");

                try
                {
                    string cadena = string.Empty;
                    cadena = "Server=Localhost;Database=mysql;Uid=root;Pwd=;";
                    string script = string.Empty;
                    System.IO.StreamReader stream = new System.IO.StreamReader(discoSlam + @"Base de Datos\MySQL\MySqlSlamDb.sql");
                    script = stream.ReadToEnd();
                    stream.Close();


                    ListaNodos[0].Attributes["Default"].Value = "False";
                    ListaNodos[1].Attributes["ConnectionString"].Value = cadena;
                    ListaNodos[1].Attributes["Default"].Value = "True";
                    doc.Save(dir);

                    Repositorio.Conexiones.Conexion cnn = new Repositorio.Conexiones.Conexion();
                    cnn.ActualizarOEliminar(script);
                    GC.Collect();
                    GC.SuppressFinalize(cnn);

                    doc.Load(dir);
                    ListaNodos[0].Attributes["Default"].Value = "False";
                    ListaNodos[1].Attributes["ConnectionString"].Value = cadena.Replace("mysql", "SlamDb");
                    ListaNodos[1].Attributes["Default"].Value = "True";
                    doc.Save(dir);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                groupBox1.Visible = false;
                groupBox2.Visible = true;
            }
        }
        
    }
}

