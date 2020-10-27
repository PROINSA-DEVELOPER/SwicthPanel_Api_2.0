namespace EASY_PASS_SWITCH_PANEL.FORMS.CONFIGURACION
{
    partial class CATALOGO_READER
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CATALOGO_READER));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.TXT_PATH = new System.Windows.Forms.Label();
            this.BTN_FileUpload = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.TXT_MODELO = new System.Windows.Forms.TextBox();
            this.BTN_GUARDAR_CATALOGO_READERS = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabControl3.SuspendLayout();
            this.tabPage7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(737, 43);
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
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(72, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(454, 26);
            this.label2.TabIndex = 4;
            this.label2.Text = "CONFIGURACION CATALOGO READER";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage2.Controls.Add(this.tabControl3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(712, 436);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Catálogo";
            // 
            // tabControl3
            // 
            this.tabControl3.Controls.Add(this.tabPage7);
            this.tabControl3.Location = new System.Drawing.Point(1, 6);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(706, 425);
            this.tabControl3.TabIndex = 25;
            // 
            // tabPage7
            // 
            this.tabPage7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage7.Controls.Add(this.TXT_PATH);
            this.tabPage7.Controls.Add(this.BTN_FileUpload);
            this.tabPage7.Controls.Add(this.label15);
            this.tabPage7.Controls.Add(this.TXT_MODELO);
            this.tabPage7.Controls.Add(this.BTN_GUARDAR_CATALOGO_READERS);
            this.tabPage7.Controls.Add(this.pictureBox1);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(698, 399);
            this.tabPage7.TabIndex = 1;
            this.tabPage7.Text = "Catalogo Reader";
            // 
            // TXT_PATH
            // 
            this.TXT_PATH.AutoSize = true;
            this.TXT_PATH.Enabled = false;
            this.TXT_PATH.Location = new System.Drawing.Point(139, 71);
            this.TXT_PATH.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TXT_PATH.Name = "TXT_PATH";
            this.TXT_PATH.Size = new System.Drawing.Size(0, 13);
            this.TXT_PATH.TabIndex = 43;
            // 
            // BTN_FileUpload
            // 
            this.BTN_FileUpload.Location = new System.Drawing.Point(15, 65);
            this.BTN_FileUpload.Margin = new System.Windows.Forms.Padding(2);
            this.BTN_FileUpload.Name = "BTN_FileUpload";
            this.BTN_FileUpload.Size = new System.Drawing.Size(118, 24);
            this.BTN_FileUpload.TabIndex = 41;
            this.BTN_FileUpload.Text = "Eligir Imagen";
            this.BTN_FileUpload.UseVisualStyleBackColor = true;
            this.BTN_FileUpload.Click += new System.EventHandler(this.BTN_FileUpload_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.DarkRed;
            this.label15.Location = new System.Drawing.Point(12, 30);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(126, 17);
            this.label15.TabIndex = 40;
            this.label15.Text = "Nombre Modelo:";
            // 
            // TXT_MODELO
            // 
            this.TXT_MODELO.Location = new System.Drawing.Point(142, 30);
            this.TXT_MODELO.Margin = new System.Windows.Forms.Padding(2);
            this.TXT_MODELO.Name = "TXT_MODELO";
            this.TXT_MODELO.Size = new System.Drawing.Size(210, 20);
            this.TXT_MODELO.TabIndex = 39;
            // 
            // BTN_GUARDAR_CATALOGO_READERS
            // 
            this.BTN_GUARDAR_CATALOGO_READERS.BackColor = System.Drawing.Color.DarkRed;
            this.BTN_GUARDAR_CATALOGO_READERS.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.BTN_GUARDAR_CATALOGO_READERS.FlatAppearance.BorderSize = 0;
            this.BTN_GUARDAR_CATALOGO_READERS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_GUARDAR_CATALOGO_READERS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_GUARDAR_CATALOGO_READERS.ForeColor = System.Drawing.Color.White;
            this.BTN_GUARDAR_CATALOGO_READERS.Location = new System.Drawing.Point(5, 356);
            this.BTN_GUARDAR_CATALOGO_READERS.Margin = new System.Windows.Forms.Padding(2);
            this.BTN_GUARDAR_CATALOGO_READERS.Name = "BTN_GUARDAR_CATALOGO_READERS";
            this.BTN_GUARDAR_CATALOGO_READERS.Size = new System.Drawing.Size(102, 38);
            this.BTN_GUARDAR_CATALOGO_READERS.TabIndex = 37;
            this.BTN_GUARDAR_CATALOGO_READERS.Text = "Guardar";
            this.BTN_GUARDAR_CATALOGO_READERS.UseVisualStyleBackColor = false;
            this.BTN_GUARDAR_CATALOGO_READERS.Click += new System.EventHandler(this.BTN_GUARDAR_CATALOGO_READERS_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(15, 105);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(124, 87);
            this.pictureBox1.TabIndex = 42;
            this.pictureBox1.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(5, 49);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(720, 462);
            this.tabControl1.TabIndex = 8;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // CATALOGO_READER
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 516);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CATALOGO_READER";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CATALOGO READER";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabControl3.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabControl tabControl3;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.Label TXT_PATH;
        private System.Windows.Forms.Button BTN_FileUpload;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox TXT_MODELO;
        private System.Windows.Forms.Button BTN_GUARDAR_CATALOGO_READERS;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}