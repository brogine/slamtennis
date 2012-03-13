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


namespace InstallerSlam
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Application.EnableVisualStyles();
        }

        string discoSlam = "I:\\";

        private void FrmCrearBase_Load(object sender, EventArgs e)
        {
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
                    cdslam = true;
                }
            }

            if (!cdslam)
            {
                MessageBox.Show("Falta insetar el cd de instalacion de Slam Tenis", "Slam Tenis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                        //if (item.Application.ToString() == "Microsoft SQL Server 2005")
                        //{
                        //    MSSql = true;
                        //}
                        if (item.Application.ToString() == Nombre)
                        {
                            MSSql = true;
                        }
                    }
                }
            }
            return MSSql;
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            

        }

        private void BtnSql_Click(object sender, EventArgs e)
        {
            if (AplicacionInstalada("Microsoft SQL Server 2005"))
            {
                PnlSqlServer.Visible = true;
            }
            else 
            {
                Process.Start(discoSlam + @"Base de Datos\SQL SERVER\sqlexpr32.exe");

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

                String ConnString = "";
                if (this.CheckSWindAut.Checked)
                    ConnString = "Server=" + this.TxtServidor.Text + ";Database=SlamDB;Integrated Security =SSPI;";
                else
                    ConnString = "Server=" + TxtMsServidor.Text + ";Database=SlamDB;Uid=" + this.TxtMsUsuario.Text + ";Pwd=" + this.TxtMsClave.Text + ";";

                //ListaNodos[CboConexiones.SelectedIndex].Attributes["ConnectionString"].Value = ConnString;
                //doc.Save(dir);
                GC.Collect();
                GC.WaitForPendingFinalizers();
                this.Close();
                IDbConnection Conn = null;
                Application.DoEvents();
                try
                {
                    DbProviderFactory Dpf = DbProviderFactories.GetFactory("System.Data.SqlClient");
                    Conn = Dpf.CreateConnection();
                    if (CheckSWindAut.Checked)
                    {
                        Conn.ConnectionString = "Server=(Local)\\SQLEXPRESS;Database=master;Integrated Security =SSPI;";
                    }
                    else
                    {
                        Conn.ConnectionString = "Data Source=(Local)\\SQLEXPRESS;Initial Catalog=master;Integrated Security =SSPI;Max Pool Size=1000;Connect Timeout=80";
                    }
                    Conn.Open();
                    IDbCommand Com = Conn.CreateCommand();

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

                    Com.CommandText = script;
                    Com.ExecuteNonQuery();
                    GC.Collect();
                    GC.SuppressFinalize(Conn);

                    //Restaurar la base

                    script = string.Empty;

                    System.IO.StreamReader stream = new System.IO.StreamReader(discoSlam + @"Base de Datos\SQL SERVER\SlamDB.sql");
                    script = stream.ReadToEnd();
                    stream.Close();

                    Com.CommandText = script;
                    Com.ExecuteNonQuery();
                    GC.Collect();
                    GC.SuppressFinalize(Conn);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    if (Conn != null)
                    {
                        Conn.Close();
                    }
                    //this.Close();
                }
                groupBox1.Visible = false;
                groupBox2.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start(discoSlam + @"Web Setup\setup.exe");
            //bool running = true;
            //while (running != false)
            //{
            //    running = Running("msiexec");
            //    Application.DoEvents();
            //    if (running)
            //    {
            System.Threading.Thread.Sleep(5000);
            //    }                
            //}
            groupBox2.Visible = false;
            groupBox4.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox4.Visible = false;
            PnlAjax.Visible = true;
            System.Threading.Thread.Sleep(4000);
            groupBox3.Visible = true;
            System.Threading.Thread hilo = new System.Threading.Thread(GuardarConf);
            hilo.Start();
        }

        void GuardarConf()
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
        }

        void FinalizarWizard()
        {
            PnlAjax.Visible = false;
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

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
            IDbConnection Conn = null;
            Application.DoEvents();
            try
            {
                DbProviderFactory Dpf = DbProviderFactories.GetFactory("System.Data.SqlClient");
                Conn = Dpf.CreateConnection();
                if (CheckSWindAut.Checked)
                {
                    Conn.ConnectionString = "Server=" + TxtMsServidor.Text + ";Database=master;Integrated Security =SSPI;";
                }
                else
                {
                    Conn.ConnectionString = "Data Source=" + TxtMsServidor.Text + ";Initial Catalog=master;User ID=" + TxtMsUsuario.Text + ";Password=" + TxtMsClave.Text + ";Max Pool Size=1000;Connect Timeout=80";
                }
                Conn.Open();
                IDbCommand Com = Conn.CreateCommand();

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

                //script += " USE [SlamDB]";
                //script += " ";
                //script += " SET ANSI_NULLS ON";
                //script += " ";
                //script += " SET QUOTED_IDENTIFIER ON";
                //script += " ";

                Com.CommandText = script;
                Com.ExecuteNonQuery();
                GC.Collect();
                GC.SuppressFinalize(Conn);

                //Restaurar la base

                script = string.Empty;

                System.IO.StreamReader stream = new System.IO.StreamReader(discoSlam + @"Base de Datos\SQL SERVER\SlamDB.sql");
                script = stream.ReadToEnd();
                stream.Close();

                Com.CommandText = script;
                Com.ExecuteNonQuery();
                GC.Collect();
                GC.SuppressFinalize(Conn);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (Conn != null)
                {
                    Conn.Close();
                }
                //this.Close();
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
            IDbConnection Conn = null;
            try
            {
                DbProviderFactory Dpf = DbProviderFactories.GetFactory("MySql.Data.MySqlClient");
                Conn = Dpf.CreateConnection();
                Conn.ConnectionString = "Server=" + TxtServidorMy.Text + ";Database=mysql;Uid=" + TxtUsuarioMY.Text + ";Pwd=" + TxtClaveMy.Text +";";
                Conn.Open();
                IDbCommand Com = Conn.CreateCommand();

                string script = string.Empty;
                System.IO.StreamReader stream = new System.IO.StreamReader(discoSlam + @"Base de Datos\MySQL\MySqlSlamDb.sql");
                script = stream.ReadToEnd();
                stream.Close();

                Com.CommandText = script;
                Com.ExecuteNonQuery();
                GC.Collect();
                GC.SuppressFinalize(Conn);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (Conn != null)
                {
                    Conn.Close();
                }
                this.Close();
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

                IDbConnection Conn = null;
                try
                {
                    DbProviderFactory Dpf = DbProviderFactories.GetFactory("MySql.Data.MySqlClient");
                    Conn = Dpf.CreateConnection();
                    Conn.ConnectionString = "Server=localhost;Database=mysql;Uid=root;Pwd=;";
                    Conn.Open();
                    IDbCommand Com = Conn.CreateCommand();

                    string script = string.Empty;
                   
                    System.IO.StreamReader stream = new System.IO.StreamReader(discoSlam + @"Base de Datos\MySQL\MySqlSlamDb.sql");
                    script = stream.ReadToEnd();
                    stream.Close();

                    Com.CommandText = script;
                    Com.ExecuteNonQuery();
                    GC.Collect();
                    GC.SuppressFinalize(Conn);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    if (Conn != null)
                    {
                        Conn.Close();
                    }
                }
                groupBox1.Visible = false;
                groupBox2.Visible = true;
            }
        }


      

        //private void BtnMySQl_Click(object sender, EventArgs e)
        //{
        //    
        //}

        //private void BtnSql_MouseDown(object sender, MouseEventArgs e)
        //{
        //    this.LblInfo.Text = "Escalabilidad, estabilidad y seguridad.\r\nSoporta procedimientos almacenados.\r\nPer" +
        //       "mite trabajar en modo cliente-servidor, donde la información y datos se alojan e" +
        //       "n el servidor.\r\n";
        //    LblInfo.Visible = true;
        //}

        //private void BtnMySQl_MouseDown(object sender, MouseEventArgs e)
        //{
        //    this.LblInfo.Text = "Proporciona sistemas de almacenamiento transaccionales y no transaccionales.\r\n" +
        //    "Usa tablas en disco B-tree (MyISAM) muy rápidas con compresión de índice.\r\n" +
        //    "Relativamente sencillo de añadir otro sistema de almacenamiento.\r\n" +
        //    "Un sistema de reserva de memoria muy rápido basado en threads.\r\n";               
        //    LblInfo.Visible = true;
        //}
    }
}

