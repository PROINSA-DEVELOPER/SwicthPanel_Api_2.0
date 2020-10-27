namespace EASY_PASS_SWITCH_PANEL.FORMS.SEGURIDAD
{
    partial class CONFIG_DATA_BASE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CONFIG_DATA_BASE));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BTN_DB_GENERAR = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.LBL_PATH = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LBL_DB_CADENA = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TXT_DB_DATA_SOURCE = new System.Windows.Forms.TextBox();
            this.TXT_DB_CATALOGO = new System.Windows.Forms.TextBox();
            this.TXT_DB_USER = new System.Windows.Forms.TextBox();
            this.TXT_DB_PASSWORD = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.LBL_SINCRONIZACION = new System.Windows.Forms.Label();
            this.TXT_SINC_PASSWORD = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.TXT_SINC_USER = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.TXT_SINC_CATALOGO = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TXT_SINC_DATA_SOURCE = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.BTN_DB_GUARDAR = new System.Windows.Forms.Button();
            this.PANEL_DB = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.RD_NO = new System.Windows.Forms.RadioButton();
            this.RD_SI = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.TXT_USER = new System.Windows.Forms.TextBox();
            this.TXT_PASS = new System.Windows.Forms.TextBox();
            this.BTN_INGRESAR = new System.Windows.Forms.Button();
            this.LBL_MSJ_LOGIN = new System.Windows.Forms.Label();
            this.radioButton_SERVICE_ACCOUNT = new System.Windows.Forms.RadioButton();
            this.radioButton_SQL_USER_ACCOUNT = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.PANEL_DB.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkRed;
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(671, 43);
            this.panel1.TabIndex = 7;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(14, 8);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(43, 27);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(72, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(352, 26);
            this.label2.TabIndex = 4;
            this.label2.Text = "CONFIGURACION DATA BASE";
            // 
            // BTN_DB_GENERAR
            // 
            this.BTN_DB_GENERAR.BackColor = System.Drawing.Color.DarkGray;
            this.BTN_DB_GENERAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_DB_GENERAR.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_DB_GENERAR.ForeColor = System.Drawing.Color.Black;
            this.BTN_DB_GENERAR.Location = new System.Drawing.Point(7, 277);
            this.BTN_DB_GENERAR.Name = "BTN_DB_GENERAR";
            this.BTN_DB_GENERAR.Size = new System.Drawing.Size(75, 27);
            this.BTN_DB_GENERAR.TabIndex = 22;
            this.BTN_DB_GENERAR.Text = "Generar";
            this.BTN_DB_GENERAR.UseVisualStyleBackColor = false;
            this.BTN_DB_GENERAR.Click += new System.EventHandler(this.BTN_DB_GENERAR_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(4, 139);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(166, 17);
            this.label23.TabIndex = 24;
            this.label23.Text = "Conexión Sincronización:";
            // 
            // LBL_PATH
            // 
            this.LBL_PATH.AutoSize = true;
            this.LBL_PATH.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_PATH.Location = new System.Drawing.Point(105, 288);
            this.LBL_PATH.Name = "LBL_PATH";
            this.LBL_PATH.Size = new System.Drawing.Size(17, 9);
            this.LBL_PATH.TabIndex = 24;
            this.LBL_PATH.Text = "****";
            this.LBL_PATH.Visible = false;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(4, 3);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(70, 17);
            this.label22.TabIndex = 23;
            this.label22.Text = "Conexión:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.LBL_DB_CADENA);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.TXT_DB_DATA_SOURCE);
            this.panel2.Controls.Add(this.TXT_DB_CATALOGO);
            this.panel2.Controls.Add(this.TXT_DB_USER);
            this.panel2.Controls.Add(this.TXT_DB_PASSWORD);
            this.panel2.Location = new System.Drawing.Point(7, 23);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(572, 113);
            this.panel2.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Data Source:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(291, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Catalogo:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "User:";
            // 
            // LBL_DB_CADENA
            // 
            this.LBL_DB_CADENA.AutoSize = true;
            this.LBL_DB_CADENA.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_DB_CADENA.Location = new System.Drawing.Point(14, 95);
            this.LBL_DB_CADENA.Name = "LBL_DB_CADENA";
            this.LBL_DB_CADENA.Size = new System.Drawing.Size(17, 9);
            this.LBL_DB_CADENA.TabIndex = 9;
            this.LBL_DB_CADENA.Text = "****";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(291, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "Password:";
            // 
            // TXT_DB_DATA_SOURCE
            // 
            this.TXT_DB_DATA_SOURCE.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_DB_DATA_SOURCE.Location = new System.Drawing.Point(109, 20);
            this.TXT_DB_DATA_SOURCE.Name = "TXT_DB_DATA_SOURCE";
            this.TXT_DB_DATA_SOURCE.Size = new System.Drawing.Size(176, 20);
            this.TXT_DB_DATA_SOURCE.TabIndex = 5;
            // 
            // TXT_DB_CATALOGO
            // 
            this.TXT_DB_CATALOGO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_DB_CATALOGO.Location = new System.Drawing.Point(374, 20);
            this.TXT_DB_CATALOGO.Name = "TXT_DB_CATALOGO";
            this.TXT_DB_CATALOGO.Size = new System.Drawing.Size(176, 20);
            this.TXT_DB_CATALOGO.TabIndex = 6;
            // 
            // TXT_DB_USER
            // 
            this.TXT_DB_USER.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_DB_USER.Location = new System.Drawing.Point(109, 51);
            this.TXT_DB_USER.Name = "TXT_DB_USER";
            this.TXT_DB_USER.Size = new System.Drawing.Size(176, 20);
            this.TXT_DB_USER.TabIndex = 7;
            // 
            // TXT_DB_PASSWORD
            // 
            this.TXT_DB_PASSWORD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_DB_PASSWORD.Location = new System.Drawing.Point(374, 51);
            this.TXT_DB_PASSWORD.Name = "TXT_DB_PASSWORD";
            this.TXT_DB_PASSWORD.PasswordChar = '*';
            this.TXT_DB_PASSWORD.Size = new System.Drawing.Size(176, 20);
            this.TXT_DB_PASSWORD.TabIndex = 8;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel3.Controls.Add(this.LBL_SINCRONIZACION);
            this.panel3.Controls.Add(this.TXT_SINC_PASSWORD);
            this.panel3.Controls.Add(this.label21);
            this.panel3.Controls.Add(this.TXT_SINC_USER);
            this.panel3.Controls.Add(this.label20);
            this.panel3.Controls.Add(this.TXT_SINC_CATALOGO);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.TXT_SINC_DATA_SOURCE);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Location = new System.Drawing.Point(7, 159);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(572, 112);
            this.panel3.TabIndex = 9;
            // 
            // LBL_SINCRONIZACION
            // 
            this.LBL_SINCRONIZACION.AutoSize = true;
            this.LBL_SINCRONIZACION.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_SINCRONIZACION.Location = new System.Drawing.Point(14, 88);
            this.LBL_SINCRONIZACION.Name = "LBL_SINCRONIZACION";
            this.LBL_SINCRONIZACION.Size = new System.Drawing.Size(17, 9);
            this.LBL_SINCRONIZACION.TabIndex = 26;
            this.LBL_SINCRONIZACION.Text = "****";
            // 
            // TXT_SINC_PASSWORD
            // 
            this.TXT_SINC_PASSWORD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_SINC_PASSWORD.Location = new System.Drawing.Point(374, 46);
            this.TXT_SINC_PASSWORD.Name = "TXT_SINC_PASSWORD";
            this.TXT_SINC_PASSWORD.PasswordChar = '*';
            this.TXT_SINC_PASSWORD.Size = new System.Drawing.Size(176, 20);
            this.TXT_SINC_PASSWORD.TabIndex = 32;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(12, 14);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(91, 17);
            this.label21.TabIndex = 25;
            this.label21.Text = "Data Source:";
            // 
            // TXT_SINC_USER
            // 
            this.TXT_SINC_USER.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_SINC_USER.Location = new System.Drawing.Point(109, 47);
            this.TXT_SINC_USER.Name = "TXT_SINC_USER";
            this.TXT_SINC_USER.Size = new System.Drawing.Size(178, 20);
            this.TXT_SINC_USER.TabIndex = 31;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(291, 15);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(68, 17);
            this.label20.TabIndex = 26;
            this.label20.Text = "Catalogo:";
            // 
            // TXT_SINC_CATALOGO
            // 
            this.TXT_SINC_CATALOGO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_SINC_CATALOGO.Location = new System.Drawing.Point(374, 15);
            this.TXT_SINC_CATALOGO.Name = "TXT_SINC_CATALOGO";
            this.TXT_SINC_CATALOGO.Size = new System.Drawing.Size(176, 20);
            this.TXT_SINC_CATALOGO.TabIndex = 30;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 17);
            this.label8.TabIndex = 27;
            this.label8.Text = "User:";
            // 
            // TXT_SINC_DATA_SOURCE
            // 
            this.TXT_SINC_DATA_SOURCE.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_SINC_DATA_SOURCE.Location = new System.Drawing.Point(109, 14);
            this.TXT_SINC_DATA_SOURCE.Name = "TXT_SINC_DATA_SOURCE";
            this.TXT_SINC_DATA_SOURCE.Size = new System.Drawing.Size(176, 20);
            this.TXT_SINC_DATA_SOURCE.TabIndex = 29;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(293, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 17);
            this.label7.TabIndex = 28;
            this.label7.Text = "Password:";
            // 
            // BTN_DB_GUARDAR
            // 
            this.BTN_DB_GUARDAR.BackColor = System.Drawing.Color.DarkRed;
            this.BTN_DB_GUARDAR.Dock = System.Windows.Forms.DockStyle.Left;
            this.BTN_DB_GUARDAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_DB_GUARDAR.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_DB_GUARDAR.ForeColor = System.Drawing.Color.White;
            this.BTN_DB_GUARDAR.Location = new System.Drawing.Point(0, 0);
            this.BTN_DB_GUARDAR.Name = "BTN_DB_GUARDAR";
            this.BTN_DB_GUARDAR.Size = new System.Drawing.Size(204, 47);
            this.BTN_DB_GUARDAR.TabIndex = 23;
            this.BTN_DB_GUARDAR.Text = "Guardar";
            this.BTN_DB_GUARDAR.UseVisualStyleBackColor = false;
            this.BTN_DB_GUARDAR.Visible = false;
            this.BTN_DB_GUARDAR.Click += new System.EventHandler(this.BTN_DB_GUARDAR_Click);
            // 
            // PANEL_DB
            // 
            this.PANEL_DB.Controls.Add(this.panel6);
            this.PANEL_DB.Controls.Add(this.panel5);
            this.PANEL_DB.Controls.Add(this.panel4);
            this.PANEL_DB.Location = new System.Drawing.Point(12, 80);
            this.PANEL_DB.Name = "PANEL_DB";
            this.PANEL_DB.Size = new System.Drawing.Size(635, 439);
            this.PANEL_DB.TabIndex = 8;
            this.PANEL_DB.Visible = false;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.BTN_DB_GUARDAR);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 377);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(635, 47);
            this.panel6.TabIndex = 27;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label22);
            this.panel5.Controls.Add(this.LBL_PATH);
            this.panel5.Controls.Add(this.label23);
            this.panel5.Controls.Add(this.panel2);
            this.panel5.Controls.Add(this.BTN_DB_GENERAR);
            this.panel5.Controls.Add(this.panel3);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 60);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(635, 317);
            this.panel5.TabIndex = 26;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.radioButton_SERVICE_ACCOUNT);
            this.panel4.Controls.Add(this.radioButton_SQL_USER_ACCOUNT);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.RD_NO);
            this.panel4.Controls.Add(this.RD_SI);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(635, 60);
            this.panel4.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(4, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(136, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "Inicio Automático:";
            // 
            // RD_NO
            // 
            this.RD_NO.AutoSize = true;
            this.RD_NO.Checked = true;
            this.RD_NO.Location = new System.Drawing.Point(197, 22);
            this.RD_NO.Name = "RD_NO";
            this.RD_NO.Size = new System.Drawing.Size(41, 17);
            this.RD_NO.TabIndex = 1;
            this.RD_NO.TabStop = true;
            this.RD_NO.Text = "NO";
            this.RD_NO.UseVisualStyleBackColor = true;
            // 
            // RD_SI
            // 
            this.RD_SI.AutoSize = true;
            this.RD_SI.Location = new System.Drawing.Point(146, 22);
            this.RD_SI.Name = "RD_SI";
            this.RD_SI.Size = new System.Drawing.Size(35, 17);
            this.RD_SI.TabIndex = 0;
            this.RD_SI.Text = "SI";
            this.RD_SI.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 57);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Usuario:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(183, 57);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Password:";
            // 
            // TXT_USER
            // 
            this.TXT_USER.Location = new System.Drawing.Point(68, 54);
            this.TXT_USER.Name = "TXT_USER";
            this.TXT_USER.Size = new System.Drawing.Size(112, 20);
            this.TXT_USER.TabIndex = 11;
            // 
            // TXT_PASS
            // 
            this.TXT_PASS.Location = new System.Drawing.Point(245, 54);
            this.TXT_PASS.Name = "TXT_PASS";
            this.TXT_PASS.PasswordChar = '*';
            this.TXT_PASS.Size = new System.Drawing.Size(112, 20);
            this.TXT_PASS.TabIndex = 12;
            // 
            // BTN_INGRESAR
            // 
            this.BTN_INGRESAR.BackColor = System.Drawing.Color.DarkRed;
            this.BTN_INGRESAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_INGRESAR.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_INGRESAR.ForeColor = System.Drawing.Color.White;
            this.BTN_INGRESAR.Location = new System.Drawing.Point(363, 50);
            this.BTN_INGRESAR.Name = "BTN_INGRESAR";
            this.BTN_INGRESAR.Size = new System.Drawing.Size(75, 27);
            this.BTN_INGRESAR.TabIndex = 24;
            this.BTN_INGRESAR.Text = "Ingresar";
            this.BTN_INGRESAR.UseVisualStyleBackColor = false;
            this.BTN_INGRESAR.Click += new System.EventHandler(this.BTN_INGRESAR_Click);
            // 
            // LBL_MSJ_LOGIN
            // 
            this.LBL_MSJ_LOGIN.AutoSize = true;
            this.LBL_MSJ_LOGIN.ForeColor = System.Drawing.Color.DarkRed;
            this.LBL_MSJ_LOGIN.Location = new System.Drawing.Point(472, 61);
            this.LBL_MSJ_LOGIN.Name = "LBL_MSJ_LOGIN";
            this.LBL_MSJ_LOGIN.Size = new System.Drawing.Size(156, 13);
            this.LBL_MSJ_LOGIN.TabIndex = 25;
            this.LBL_MSJ_LOGIN.Text = "Usuario o Password incorrectos";
            this.LBL_MSJ_LOGIN.Visible = false;
            // 
            // radioButton_SERVICE_ACCOUNT
            // 
            this.radioButton_SERVICE_ACCOUNT.AutoSize = true;
            this.radioButton_SERVICE_ACCOUNT.Location = new System.Drawing.Point(495, 22);
            this.radioButton_SERVICE_ACCOUNT.Name = "radioButton_SERVICE_ACCOUNT";
            this.radioButton_SERVICE_ACCOUNT.Size = new System.Drawing.Size(117, 17);
            this.radioButton_SERVICE_ACCOUNT.TabIndex = 28;
            this.radioButton_SERVICE_ACCOUNT.TabStop = true;
            this.radioButton_SERVICE_ACCOUNT.Text = "Cuenta De Servicio";
            this.radioButton_SERVICE_ACCOUNT.UseVisualStyleBackColor = true;
            // 
            // radioButton_SQL_USER_ACCOUNT
            // 
            this.radioButton_SQL_USER_ACCOUNT.AutoSize = true;
            this.radioButton_SQL_USER_ACCOUNT.Checked = true;
            this.radioButton_SQL_USER_ACCOUNT.Location = new System.Drawing.Point(303, 22);
            this.radioButton_SQL_USER_ACCOUNT.Name = "radioButton_SQL_USER_ACCOUNT";
            this.radioButton_SQL_USER_ACCOUNT.Size = new System.Drawing.Size(169, 17);
            this.radioButton_SQL_USER_ACCOUNT.TabIndex = 27;
            this.radioButton_SQL_USER_ACCOUNT.TabStop = true;
            this.radioButton_SQL_USER_ACCOUNT.Text = "Cuenta Usuario SQL SERVER";
            this.radioButton_SQL_USER_ACCOUNT.UseVisualStyleBackColor = true;
            // 
            // CONFIG_DATA_BASE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 534);
            this.Controls.Add(this.LBL_MSJ_LOGIN);
            this.Controls.Add(this.BTN_INGRESAR);
            this.Controls.Add(this.TXT_PASS);
            this.Controls.Add(this.TXT_USER);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.PANEL_DB);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CONFIG_DATA_BASE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CONFIGURACION DATA BASE";
            this.Load += new System.EventHandler(this.CONFIG_DATA_BASE_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.PANEL_DB.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TXT_DB_PASSWORD;
        private System.Windows.Forms.TextBox TXT_DB_USER;
        private System.Windows.Forms.TextBox TXT_DB_CATALOGO;
        private System.Windows.Forms.TextBox TXT_DB_DATA_SOURCE;
        private System.Windows.Forms.Label LBL_DB_CADENA;
        private System.Windows.Forms.Button BTN_DB_GUARDAR;
        private System.Windows.Forms.Button BTN_DB_GENERAR;
        private System.Windows.Forms.Label LBL_PATH;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox TXT_SINC_PASSWORD;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox TXT_SINC_USER;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox TXT_SINC_CATALOGO;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TXT_SINC_DATA_SOURCE;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label LBL_SINCRONIZACION;
        private System.Windows.Forms.Panel PANEL_DB;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TXT_USER;
        private System.Windows.Forms.TextBox TXT_PASS;
        private System.Windows.Forms.Button BTN_INGRESAR;
        private System.Windows.Forms.Label LBL_MSJ_LOGIN;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton RD_NO;
        private System.Windows.Forms.RadioButton RD_SI;
        private System.Windows.Forms.RadioButton radioButton_SERVICE_ACCOUNT;
        private System.Windows.Forms.RadioButton radioButton_SQL_USER_ACCOUNT;
    }
}