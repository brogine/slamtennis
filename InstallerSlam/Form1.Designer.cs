namespace InstallerSlam
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnMySQl = new System.Windows.Forms.Button();
            this.BtnSql = new System.Windows.Forms.Button();
            this.LblInfo = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.CheckIniciar = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.TxtNombre = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.CheckAut = new System.Windows.Forms.CheckBox();
            this.PnlConf = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.CheckAutenticacion = new System.Windows.Forms.CheckBox();
            this.TxtServidor = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtClave = new System.Windows.Forms.TextBox();
            this.TxtEmail = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PnlAjax = new System.Windows.Forms.Panel();
            this.PnlSqlServer = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.TxtMsServidor = new System.Windows.Forms.TextBox();
            this.CheckSWindAut = new System.Windows.Forms.CheckBox();
            this.TxtMsUsuario = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.TxtMsClave = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.PnlWindowsAut = new System.Windows.Forms.Panel();
            this.BtnContinuarMS = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.PnlConf.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.PnlAjax.SuspendLayout();
            this.PnlSqlServer.SuspendLayout();
            this.PnlWindowsAut.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Wizard de configuración";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.PnlSqlServer);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.BtnMySQl);
            this.groupBox1.Controls.Add(this.BtnSql);
            this.groupBox1.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(44, 90);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(453, 226);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Base de Datos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(6, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(219, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Seleccione una base de datos...";
            // 
            // BtnMySQl
            // 
            this.BtnMySQl.BackgroundImage = global::InstallerSlam.Properties.Resources.mysql;
            this.BtnMySQl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnMySQl.Location = new System.Drawing.Point(252, 81);
            this.BtnMySQl.Name = "BtnMySQl";
            this.BtnMySQl.Size = new System.Drawing.Size(114, 83);
            this.BtnMySQl.TabIndex = 1;
            this.BtnMySQl.UseVisualStyleBackColor = true;
            this.BtnMySQl.Click += new System.EventHandler(this.BtnSql_Click);
            // 
            // BtnSql
            // 
            this.BtnSql.BackgroundImage = global::InstallerSlam.Properties.Resources.sql_server_2008_logo;
            this.BtnSql.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnSql.Location = new System.Drawing.Point(84, 81);
            this.BtnSql.Name = "BtnSql";
            this.BtnSql.Size = new System.Drawing.Size(114, 83);
            this.BtnSql.TabIndex = 0;
            this.BtnSql.UseVisualStyleBackColor = true;
            this.BtnSql.Click += new System.EventHandler(this.BtnSql_Click);
            // 
            // LblInfo
            // 
            this.LblInfo.AutoSize = true;
            this.LblInfo.BackColor = System.Drawing.Color.Transparent;
            this.LblInfo.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblInfo.ForeColor = System.Drawing.Color.White;
            this.LblInfo.Location = new System.Drawing.Point(3, 361);
            this.LblInfo.Name = "LblInfo";
            this.LblInfo.Size = new System.Drawing.Size(452, 60);
            this.LblInfo.TabIndex = 3;
            this.LblInfo.Text = resources.GetString("LblInfo.Text");
            this.LblInfo.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(44, 89);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(453, 242);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Aplicacion web";
            this.groupBox2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(95, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(271, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Instalar Aplicacion web [Requiere IIS]";
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::InstallerSlam.Properties.Resources.Slam;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(190, 72);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(71, 46);
            this.button1.TabIndex = 1;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.BtnSalir);
            this.groupBox3.Controls.Add(this.CheckIniciar);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(38, 83);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(465, 242);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Configuracion Finalizada";
            this.groupBox3.Visible = false;
            // 
            // BtnSalir
            // 
            this.BtnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSalir.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Location = new System.Drawing.Point(351, 192);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(93, 40);
            this.BtnSalir.TabIndex = 8;
            this.BtnSalir.Text = "Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // CheckIniciar
            // 
            this.CheckIniciar.AutoSize = true;
            this.CheckIniciar.Checked = true;
            this.CheckIniciar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckIniciar.Location = new System.Drawing.Point(16, 213);
            this.CheckIniciar.Name = "CheckIniciar";
            this.CheckIniciar.Size = new System.Drawing.Size(125, 19);
            this.CheckIniciar.TabIndex = 3;
            this.CheckIniciar.Text = "Iniciar Slam Tenis";
            this.CheckIniciar.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(60, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(375, 25);
            this.label4.TabIndex = 2;
            this.label4.Text = "Slam Tenis instalada correctamente...";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.TxtNombre);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.button2);
            this.groupBox4.Controls.Add(this.CheckAut);
            this.groupBox4.Controls.Add(this.PnlConf);
            this.groupBox4.Controls.Add(this.TxtClave);
            this.groupBox4.Controls.Add(this.TxtEmail);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.Color.White;
            this.groupBox4.Location = new System.Drawing.Point(38, 72);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(465, 315);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Configuracion de Email";
            this.groupBox4.Visible = false;
            // 
            // TxtNombre
            // 
            this.TxtNombre.Location = new System.Drawing.Point(182, 54);
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Size = new System.Drawing.Size(190, 23);
            this.TxtNombre.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(84, 54);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 19);
            this.label9.TabIndex = 8;
            this.label9.Text = "Su Nombre:";
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(351, 264);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 40);
            this.button2.TabIndex = 7;
            this.button2.Text = "Finalizar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // CheckAut
            // 
            this.CheckAut.AutoSize = true;
            this.CheckAut.Checked = true;
            this.CheckAut.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckAut.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckAut.Location = new System.Drawing.Point(216, 19);
            this.CheckAut.Name = "CheckAut";
            this.CheckAut.Size = new System.Drawing.Size(243, 23);
            this.CheckAut.TabIndex = 6;
            this.CheckAut.Text = "Configurar Automaticamente";
            this.CheckAut.UseVisualStyleBackColor = true;
            this.CheckAut.CheckedChanged += new System.EventHandler(this.CheckAut_CheckedChanged);
            // 
            // PnlConf
            // 
            this.PnlConf.Controls.Add(this.textBox1);
            this.PnlConf.Controls.Add(this.label8);
            this.PnlConf.Controls.Add(this.CheckAutenticacion);
            this.PnlConf.Controls.Add(this.TxtServidor);
            this.PnlConf.Controls.Add(this.label7);
            this.PnlConf.Location = new System.Drawing.Point(31, 160);
            this.PnlConf.Name = "PnlConf";
            this.PnlConf.Size = new System.Drawing.Size(404, 103);
            this.PnlConf.TabIndex = 5;
            this.PnlConf.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(151, 49);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(85, 23);
            this.textBox1.TabIndex = 9;
            this.textBox1.Text = "25";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(85, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 19);
            this.label8.TabIndex = 8;
            this.label8.Text = "Puerto:";
            // 
            // CheckAutenticacion
            // 
            this.CheckAutenticacion.AutoSize = true;
            this.CheckAutenticacion.Checked = true;
            this.CheckAutenticacion.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckAutenticacion.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckAutenticacion.Location = new System.Drawing.Point(90, 80);
            this.CheckAutenticacion.Name = "CheckAutenticacion";
            this.CheckAutenticacion.Size = new System.Drawing.Size(202, 23);
            this.CheckAutenticacion.TabIndex = 7;
            this.CheckAutenticacion.Text = "Requiere Autenticacion";
            this.CheckAutenticacion.UseVisualStyleBackColor = true;
            // 
            // TxtServidor
            // 
            this.TxtServidor.Location = new System.Drawing.Point(151, 17);
            this.TxtServidor.Name = "TxtServidor";
            this.TxtServidor.Size = new System.Drawing.Size(190, 23);
            this.TxtServidor.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(21, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 19);
            this.label7.TabIndex = 4;
            this.label7.Text = "Servidor (SMTP)";
            // 
            // TxtClave
            // 
            this.TxtClave.Location = new System.Drawing.Point(182, 137);
            this.TxtClave.Name = "TxtClave";
            this.TxtClave.Size = new System.Drawing.Size(190, 23);
            this.TxtClave.TabIndex = 4;
            this.TxtClave.UseSystemPasswordChar = true;
            // 
            // TxtEmail
            // 
            this.TxtEmail.Location = new System.Drawing.Point(182, 100);
            this.TxtEmail.Name = "TxtEmail";
            this.TxtEmail.Size = new System.Drawing.Size(190, 23);
            this.TxtEmail.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(84, 137);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 19);
            this.label6.TabIndex = 2;
            this.label6.Text = "Contraseña:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(34, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 19);
            this.label5.TabIndex = 1;
            this.label5.Text = "Direccion de Email:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(70, 43);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(185, 19);
            this.label10.TabIndex = 7;
            this.label10.Text = "Aguarde unos segundos...";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::InstallerSlam.Properties.Resources.arrow5;
            this.pictureBox1.Location = new System.Drawing.Point(6, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(57, 57);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // PnlAjax
            // 
            this.PnlAjax.BackColor = System.Drawing.Color.Transparent;
            this.PnlAjax.Controls.Add(this.pictureBox1);
            this.PnlAjax.Controls.Add(this.label10);
            this.PnlAjax.Location = new System.Drawing.Point(44, 155);
            this.PnlAjax.Name = "PnlAjax";
            this.PnlAjax.Size = new System.Drawing.Size(255, 100);
            this.PnlAjax.TabIndex = 9;
            this.PnlAjax.Visible = false;
            // 
            // PnlSqlServer
            // 
            this.PnlSqlServer.Controls.Add(this.BtnContinuarMS);
            this.PnlSqlServer.Controls.Add(this.PnlWindowsAut);
            this.PnlSqlServer.Controls.Add(this.CheckSWindAut);
            this.PnlSqlServer.Controls.Add(this.TxtMsServidor);
            this.PnlSqlServer.Controls.Add(this.label11);
            this.PnlSqlServer.Location = new System.Drawing.Point(32, 68);
            this.PnlSqlServer.Name = "PnlSqlServer";
            this.PnlSqlServer.Size = new System.Drawing.Size(394, 152);
            this.PnlSqlServer.TabIndex = 3;
            this.PnlSqlServer.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(58, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 15);
            this.label11.TabIndex = 0;
            this.label11.Text = "Servidor:";
            // 
            // TxtMsServidor
            // 
            this.TxtMsServidor.Location = new System.Drawing.Point(120, 14);
            this.TxtMsServidor.Name = "TxtMsServidor";
            this.TxtMsServidor.Size = new System.Drawing.Size(146, 23);
            this.TxtMsServidor.TabIndex = 1;
            this.TxtMsServidor.Text = "(Local)\\SQLEXPRESS";
            // 
            // CheckSWindAut
            // 
            this.CheckSWindAut.AutoSize = true;
            this.CheckSWindAut.Checked = true;
            this.CheckSWindAut.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckSWindAut.Location = new System.Drawing.Point(120, 49);
            this.CheckSWindAut.Name = "CheckSWindAut";
            this.CheckSWindAut.Size = new System.Drawing.Size(174, 19);
            this.CheckSWindAut.TabIndex = 2;
            this.CheckSWindAut.Text = "Autenticacion de Windows";
            this.CheckSWindAut.UseVisualStyleBackColor = true;
            this.CheckSWindAut.CheckedChanged += new System.EventHandler(this.CheckSWindAut_CheckedChanged);
            // 
            // TxtMsUsuario
            // 
            this.TxtMsUsuario.Location = new System.Drawing.Point(69, 9);
            this.TxtMsUsuario.Name = "TxtMsUsuario";
            this.TxtMsUsuario.Size = new System.Drawing.Size(146, 23);
            this.TxtMsUsuario.TabIndex = 4;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 12);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 15);
            this.label12.TabIndex = 3;
            this.label12.Text = "Usuario:";
            // 
            // TxtMsClave
            // 
            this.TxtMsClave.Location = new System.Drawing.Point(69, 38);
            this.TxtMsClave.Name = "TxtMsClave";
            this.TxtMsClave.Size = new System.Drawing.Size(146, 23);
            this.TxtMsClave.TabIndex = 6;
            this.TxtMsClave.UseSystemPasswordChar = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 41);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(40, 15);
            this.label13.TabIndex = 5;
            this.label13.Text = "Clave:";
            // 
            // PnlWindowsAut
            // 
            this.PnlWindowsAut.Controls.Add(this.TxtMsUsuario);
            this.PnlWindowsAut.Controls.Add(this.TxtMsClave);
            this.PnlWindowsAut.Controls.Add(this.label12);
            this.PnlWindowsAut.Controls.Add(this.label13);
            this.PnlWindowsAut.Location = new System.Drawing.Point(52, 67);
            this.PnlWindowsAut.Name = "PnlWindowsAut";
            this.PnlWindowsAut.Size = new System.Drawing.Size(233, 75);
            this.PnlWindowsAut.TabIndex = 7;
            this.PnlWindowsAut.Visible = false;
            // 
            // BtnContinuarMS
            // 
            this.BtnContinuarMS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnContinuarMS.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnContinuarMS.Location = new System.Drawing.Point(298, 98);
            this.BtnContinuarMS.Name = "BtnContinuarMS";
            this.BtnContinuarMS.Size = new System.Drawing.Size(93, 40);
            this.BtnContinuarMS.TabIndex = 8;
            this.BtnContinuarMS.Text = "Continuar";
            this.BtnContinuarMS.UseVisualStyleBackColor = true;
            this.BtnContinuarMS.Click += new System.EventHandler(this.BtnContinuarMS_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::InstallerSlam.Properties.Resources.B_cesped1;
            this.ClientSize = new System.Drawing.Size(554, 439);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.PnlAjax);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.LblInfo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Opacity = 0.97;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Creando Entorno";
            this.Load += new System.EventHandler(this.FrmCrearBase_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.PnlConf.ResumeLayout(false);
            this.PnlConf.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.PnlAjax.ResumeLayout(false);
            this.PnlAjax.PerformLayout();
            this.PnlSqlServer.ResumeLayout(false);
            this.PnlSqlServer.PerformLayout();
            this.PnlWindowsAut.ResumeLayout(false);
            this.PnlWindowsAut.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnMySQl;
        private System.Windows.Forms.Button BtnSql;
        private System.Windows.Forms.Label LblInfo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox CheckAut;
        private System.Windows.Forms.Panel PnlConf;
        private System.Windows.Forms.TextBox TxtClave;
        private System.Windows.Forms.TextBox TxtEmail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtServidor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox CheckAutenticacion;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TxtNombre;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel PnlAjax;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.CheckBox CheckIniciar;
        private System.Windows.Forms.Panel PnlSqlServer;
        private System.Windows.Forms.Panel PnlWindowsAut;
        private System.Windows.Forms.TextBox TxtMsUsuario;
        private System.Windows.Forms.TextBox TxtMsClave;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox CheckSWindAut;
        private System.Windows.Forms.TextBox TxtMsServidor;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button BtnContinuarMS;
    }
}