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


namespace InstallerSlam
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Application.EnableVisualStyles();
        }

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
                MessageBox.Show("Falta insetar el cd de instalacion de Slam Tenis");
            }



            //int count = 0;
            //string[] sss = Environment.GetLogicalDrives();

            //foreach (string item in sss)
            //{
            //    DirectoryInfo currentDir = new DirectoryInfo(item);
            //    string path = string.Format("win32_logicaldisk.deviceid=\"{0}\"", currentDir.Root.Name.Replace("\\", ""));
            //    ManagementObject disk = new ManagementObject(path);
            //    disk.Get();
            //    string nombre = disk.GetText(TextFormat.CimDtd20);
                
            //}

            //string path = string.Empty;  //= string.Format("win32_logicaldisk.deviceid=\"{0}\"", currentDir.Root.Name.Replace("\\", ""));
            //ManagementObject disk = new ManagementObject(path);
            //disk.Get();
            //foreach (PropertyData property in disk.Properties)
            //{
            //    string name = property.Name.PadRight(25);
            //    string value = (property.Value ?? string.Empty).ToString().PadRight(25);
            //    Console.WriteLine("Nombre: {0} Valor: {1}", name, value);
            //}
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            

        }

        private void BtnSql_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
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


        //private void button1_Click(object sender, EventArgs e)
        //{
        //    IDbConnection Conn = null;
        //    try
        //    {
        //        DbProviderFactory Dpf = DbProviderFactories.GetFactory("System.Data.SqlClient");
        //        Conn = Dpf.CreateConnection();
        //        Conn.ConnectionString = "Server=(Local)\\SQLEXPRESS;Database=master;Integrated Security =SSPI;";
        //        Conn.Open();
        //        IDbCommand Com = Conn.CreateCommand();

        //        string script = string.Empty;

        //        //Crear la base de datos

        //        script += " USE master";
        //        script += " ";
        //        script += " if exists(select * from sysdatabases where name= 'SlamDB')";
        //        script += " BEGIN";
        //        script += "      drop database SlamDB";
        //        script += " END";
        //        script += " DECLARE @device_directory NVARCHAR(520),@comando varchar(500)";
        //        script += " set @device_directory = ''";
        //        script += " set @comando = ''";
        //        script += " SELECT @device_directory = SUBSTRING(filename, 1, CHARINDEX(N'master.mdf', LOWER(filename)) - 1)";
        //        script += " FROM master.dbo.sysaltfiles WHERE dbid = 1 AND fileid = 1";
        //        script += " set @comando = N'CREATE DATABASE [SlamDB] ON PRIMARY (NAME = N' + char(39) + 'SlamDB' + char(39) + ', FILENAME = N' + char(39) + @device_directory + N'SlamDB.mdf' + char(39) + ') LOG ON (NAME = N' + char(39) + 'SlamDB_log' + char(39) + ',  FILENAME = N' + char(39) + '' + @device_directory + N'SlamDB.ldf' + char(39) + ')'";
        //        script += " Execute(@comando)";
        //        script += " ";
        //        //script += " USE [SlamDB]";
        //        //script += " ";
        //        //script += " SET ANSI_NULLS ON";
        //        //script += " ";
        //        //script += " SET QUOTED_IDENTIFIER ON";
        //        //script += " ";

        //        Com.CommandText = script;
        //        Com.ExecuteNonQuery();
        //        GC.Collect();
        //        GC.SuppressFinalize(Conn);

        //        //Restaurar la base

        //        script = string.Empty;
        //        string ubicacion = System.AppDomain.CurrentDomain.BaseDirectory;

        //        System.IO.StreamReader stream = new System.IO.StreamReader(ubicacion + "SlamDb.sql");
        //        script = stream.ReadToEnd();
        //        stream.Close();

        //        //script += "RESTORE DATABASE ";
        //        //script += " SlamDB ";
        //        //script += " FROM ";
        //        //script += " DISK='" + ubicacion + "SlamDB.bak' ";
        //        //script += " WITH REPLACE";

        //        Com.CommandText = script;
        //        Com.ExecuteNonQuery();
        //        GC.Collect();
        //        GC.SuppressFinalize(Conn);

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    finally
        //    {
        //        if (Conn != null)
        //        {
        //            Conn.Close();
        //        }
        //        this.Close();
        //    }
        //}

        //private void BtnMySQl_Click(object sender, EventArgs e)
        //{
        //    IDbConnection Conn = null;
        //    try
        //    {
        //        DbProviderFactory Dpf = DbProviderFactories.GetFactory("MySql.Data.MySqlClient");
        //        Conn = Dpf.CreateConnection();
        //        Conn.ConnectionString = "Server=localhost;Database=SlamDB;Uid=root;Pwd=;";
        //        Conn.Open();
        //        IDbCommand Com = Conn.CreateCommand();

        //        string script = string.Empty;

        //        ////Crear la base de datos

        //        //script += " USE master";
        //        //script += " ";
        //        //script += " if exists(select * from sysdatabases where name= 'SlamDB')";
        //        //script += " BEGIN";
        //        //script += "      drop database SlamDB";
        //        //script += " END";
        //        //script += " DECLARE @device_directory NVARCHAR(520),@comando varchar(500)";
        //        //script += " set @device_directory = ''";
        //        //script += " set @comando = ''";
        //        //script += " SELECT @device_directory = SUBSTRING(filename, 1, CHARINDEX(N'master.mdf', LOWER(filename)) - 1)";
        //        //script += " FROM master.dbo.sysaltfiles WHERE dbid = 1 AND fileid = 1";
        //        //script += " set @comando = N'CREATE DATABASE [SlamDB] ON PRIMARY (NAME = N' + char(39) + 'SlamDB' + char(39) + ', FILENAME = N' + char(39) + @device_directory + N'SlamDB.mdf' + char(39) + ') LOG ON (NAME = N' + char(39) + 'SlamDB_log' + char(39) + ',  FILENAME = N' + char(39) + '' + @device_directory + N'SlamDB.ldf' + char(39) + ')'";
        //        //script += " Execute(@comando)";
        //        //script += " ";
        //        ////script += " USE [SlamDB]";
        //        ////script += " ";
        //        ////script += " SET ANSI_NULLS ON";
        //        ////script += " ";
        //        ////script += " SET QUOTED_IDENTIFIER ON";
        //        ////script += " ";

        //        //Com.CommandText = script;
        //        //Com.ExecuteNonQuery();
        //        //GC.Collect();
        //        //GC.SuppressFinalize(Conn);

        //        ////Restaurar la base

        //        script = string.Empty;
        //        string ubicacion = System.AppDomain.CurrentDomain.BaseDirectory;

        //        System.IO.StreamReader stream = new System.IO.StreamReader(ubicacion + "MySqlSlamDb.sql");
        //        script = stream.ReadToEnd();
        //        stream.Close();

        //        //script += "RESTORE DATABASE ";
        //        //script += " SlamDB ";
        //        //script += " FROM ";
        //        //script += " DISK='" + ubicacion + "SlamDB.bak' ";
        //        //script += " WITH REPLACE";

        //        Com.CommandText = script;
        //        Com.ExecuteNonQuery();
        //        GC.Collect();
        //        GC.SuppressFinalize(Conn);

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    finally
        //    {
        //        if (Conn != null)
        //        {
        //            Conn.Close();
        //        }
        //        this.Close();
        //    }
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

