namespace EASY_PASS_SWITCH_PANEL
{
    partial class TESTING_READER
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TESTING_READER));
            this.label1 = new System.Windows.Forms.Label();
            this.CMB_PORTAL = new System.Windows.Forms.ComboBox();
            this.GV_TEST = new System.Windows.Forms.DataGridView();
            this.BTN_START = new System.Windows.Forms.Button();
            this.BTN_STOP = new System.Windows.Forms.Button();
            this.RB_ONLINE = new System.Windows.Forms.RadioButton();
            this.RB_OFFLINE = new System.Windows.Forms.RadioButton();
            this.LBL_ID_PORTAL = new System.Windows.Forms.Label();
            this.TIMER_TEST = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.GV_TEST)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(56, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "PORTAL:";
            // 
            // CMB_PORTAL
            // 
            this.CMB_PORTAL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CMB_PORTAL.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMB_PORTAL.FormattingEnabled = true;
            this.CMB_PORTAL.Location = new System.Drawing.Point(138, 31);
            this.CMB_PORTAL.Name = "CMB_PORTAL";
            this.CMB_PORTAL.Size = new System.Drawing.Size(265, 24);
            this.CMB_PORTAL.TabIndex = 1;
            this.CMB_PORTAL.SelectedIndexChanged += new System.EventHandler(this.CMB_PORTAL_SelectedIndexChanged);
            // 
            // GV_TEST
            // 
            this.GV_TEST.AllowUserToAddRows = false;
            this.GV_TEST.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GV_TEST.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.GV_TEST.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GV_TEST.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GV_TEST.GridColor = System.Drawing.Color.White;
            this.GV_TEST.Location = new System.Drawing.Point(0, 163);
            this.GV_TEST.Name = "GV_TEST";
            this.GV_TEST.ReadOnly = true;
            this.GV_TEST.RowHeadersVisible = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.GV_TEST.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.GV_TEST.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GV_TEST.Size = new System.Drawing.Size(720, 476);
            this.GV_TEST.TabIndex = 2;
            // 
            // BTN_START
            // 
            this.BTN_START.BackColor = System.Drawing.Color.Green;
            this.BTN_START.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BTN_START.FlatAppearance.BorderSize = 0;
            this.BTN_START.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.BTN_START.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BTN_START.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_START.ForeColor = System.Drawing.Color.White;
            this.BTN_START.Location = new System.Drawing.Point(417, 31);
            this.BTN_START.Name = "BTN_START";
            this.BTN_START.Size = new System.Drawing.Size(101, 51);
            this.BTN_START.TabIndex = 3;
            this.BTN_START.Text = "START";
            this.BTN_START.UseVisualStyleBackColor = false;
            this.BTN_START.Click += new System.EventHandler(this.button1_Click);
            // 
            // BTN_STOP
            // 
            this.BTN_STOP.BackColor = System.Drawing.Color.Maroon;
            this.BTN_STOP.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BTN_STOP.FlatAppearance.BorderSize = 0;
            this.BTN_STOP.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BTN_STOP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_STOP.ForeColor = System.Drawing.Color.White;
            this.BTN_STOP.Location = new System.Drawing.Point(524, 31);
            this.BTN_STOP.Name = "BTN_STOP";
            this.BTN_STOP.Size = new System.Drawing.Size(93, 51);
            this.BTN_STOP.TabIndex = 4;
            this.BTN_STOP.Text = "STOP";
            this.BTN_STOP.UseVisualStyleBackColor = false;
            this.BTN_STOP.Click += new System.EventHandler(this.BTN_STOP_Click);
            // 
            // RB_ONLINE
            // 
            this.RB_ONLINE.AutoSize = true;
            this.RB_ONLINE.Enabled = false;
            this.RB_ONLINE.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RB_ONLINE.Location = new System.Drawing.Point(178, 61);
            this.RB_ONLINE.Name = "RB_ONLINE";
            this.RB_ONLINE.Size = new System.Drawing.Size(86, 24);
            this.RB_ONLINE.TabIndex = 5;
            this.RB_ONLINE.TabStop = true;
            this.RB_ONLINE.Text = "ONLINE";
            this.RB_ONLINE.UseVisualStyleBackColor = true;
            // 
            // RB_OFFLINE
            // 
            this.RB_OFFLINE.AutoSize = true;
            this.RB_OFFLINE.Enabled = false;
            this.RB_OFFLINE.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RB_OFFLINE.Location = new System.Drawing.Point(270, 61);
            this.RB_OFFLINE.Name = "RB_OFFLINE";
            this.RB_OFFLINE.Size = new System.Drawing.Size(95, 24);
            this.RB_OFFLINE.TabIndex = 6;
            this.RB_OFFLINE.TabStop = true;
            this.RB_OFFLINE.Text = "OFFLINE";
            this.RB_OFFLINE.UseVisualStyleBackColor = true;
            // 
            // LBL_ID_PORTAL
            // 
            this.LBL_ID_PORTAL.AutoSize = true;
            this.LBL_ID_PORTAL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_ID_PORTAL.Location = new System.Drawing.Point(56, 63);
            this.LBL_ID_PORTAL.Name = "LBL_ID_PORTAL";
            this.LBL_ID_PORTAL.Size = new System.Drawing.Size(19, 20);
            this.LBL_ID_PORTAL.TabIndex = 7;
            this.LBL_ID_PORTAL.Text = "--";
            this.LBL_ID_PORTAL.Visible = false;
            // 
            // TIMER_TEST
            // 
            this.TIMER_TEST.Enabled = true;
            this.TIMER_TEST.Tick += new System.EventHandler(this.TIMER_TEST_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkRed;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 640);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(720, 39);
            this.panel1.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkRed;
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(720, 43);
            this.panel2.TabIndex = 11;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(14, 8);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(43, 27);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(72, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(284, 26);
            this.label2.TabIndex = 10;
            this.label2.Text = "TESTING DE LECTURAS\r\n";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel3.Controls.Add(this.CMB_PORTAL);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.BTN_START);
            this.panel3.Controls.Add(this.LBL_ID_PORTAL);
            this.panel3.Controls.Add(this.BTN_STOP);
            this.panel3.Controls.Add(this.RB_OFFLINE);
            this.panel3.Controls.Add(this.RB_ONLINE);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 43);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(720, 114);
            this.panel3.TabIndex = 12;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel4.Controls.Add(this.GV_TEST);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(720, 679);
            this.panel4.TabIndex = 13;
            // 
            // TESTING_READER
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(720, 679);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TESTING_READER";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TESTING READER";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Reader_Testing_FormClosed);
            this.Load += new System.EventHandler(this.Reader_Testing_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GV_TEST)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CMB_PORTAL;
        private System.Windows.Forms.DataGridView GV_TEST;
        private System.Windows.Forms.Button BTN_START;
        private System.Windows.Forms.Button BTN_STOP;
        private System.Windows.Forms.RadioButton RB_ONLINE;
        private System.Windows.Forms.RadioButton RB_OFFLINE;
        private System.Windows.Forms.Label LBL_ID_PORTAL;
        private System.Windows.Forms.Timer TIMER_TEST;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}