namespace EASY_PASS_SWITCH_PANEL
{
    partial class VALIDAR_PROCESO
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VALIDAR_PROCESO));
            this.BTN_LOGIN_ENTER = new System.Windows.Forms.Button();
            this.LBL_LOGIN_PASSWORD = new System.Windows.Forms.Label();
            this.LBL_LOGIN_USER = new System.Windows.Forms.Label();
            this.TXT_LOGIN_PASSWORD = new System.Windows.Forms.TextBox();
            this.TXT_LOGIN_USER = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BTN_LOGIN_ENTER
            // 
            this.BTN_LOGIN_ENTER.BackColor = System.Drawing.Color.White;
            this.BTN_LOGIN_ENTER.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_LOGIN_ENTER.ForeColor = System.Drawing.Color.DarkRed;
            this.BTN_LOGIN_ENTER.Location = new System.Drawing.Point(116, 147);
            this.BTN_LOGIN_ENTER.Margin = new System.Windows.Forms.Padding(2);
            this.BTN_LOGIN_ENTER.Name = "BTN_LOGIN_ENTER";
            this.BTN_LOGIN_ENTER.Size = new System.Drawing.Size(137, 40);
            this.BTN_LOGIN_ENTER.TabIndex = 9;
            this.BTN_LOGIN_ENTER.Text = "Aceptar";
            this.BTN_LOGIN_ENTER.UseVisualStyleBackColor = false;
            this.BTN_LOGIN_ENTER.Click += new System.EventHandler(this.BTN_LOGIN_ENTER_Click);
            // 
            // LBL_LOGIN_PASSWORD
            // 
            this.LBL_LOGIN_PASSWORD.AutoSize = true;
            this.LBL_LOGIN_PASSWORD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_LOGIN_PASSWORD.ForeColor = System.Drawing.Color.White;
            this.LBL_LOGIN_PASSWORD.Location = new System.Drawing.Point(88, 86);
            this.LBL_LOGIN_PASSWORD.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LBL_LOGIN_PASSWORD.Name = "LBL_LOGIN_PASSWORD";
            this.LBL_LOGIN_PASSWORD.Size = new System.Drawing.Size(86, 20);
            this.LBL_LOGIN_PASSWORD.TabIndex = 8;
            this.LBL_LOGIN_PASSWORD.Text = "Password";
            // 
            // LBL_LOGIN_USER
            // 
            this.LBL_LOGIN_USER.AutoSize = true;
            this.LBL_LOGIN_USER.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_LOGIN_USER.ForeColor = System.Drawing.Color.White;
            this.LBL_LOGIN_USER.Location = new System.Drawing.Point(89, 29);
            this.LBL_LOGIN_USER.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LBL_LOGIN_USER.Name = "LBL_LOGIN_USER";
            this.LBL_LOGIN_USER.Size = new System.Drawing.Size(71, 20);
            this.LBL_LOGIN_USER.TabIndex = 7;
            this.LBL_LOGIN_USER.Text = "Usuario";
            // 
            // TXT_LOGIN_PASSWORD
            // 
            this.TXT_LOGIN_PASSWORD.BackColor = System.Drawing.Color.WhiteSmoke;
            this.TXT_LOGIN_PASSWORD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_LOGIN_PASSWORD.Location = new System.Drawing.Point(88, 108);
            this.TXT_LOGIN_PASSWORD.Margin = new System.Windows.Forms.Padding(2);
            this.TXT_LOGIN_PASSWORD.Name = "TXT_LOGIN_PASSWORD";
            this.TXT_LOGIN_PASSWORD.PasswordChar = '*';
            this.TXT_LOGIN_PASSWORD.Size = new System.Drawing.Size(200, 26);
            this.TXT_LOGIN_PASSWORD.TabIndex = 6;
            // 
            // TXT_LOGIN_USER
            // 
            this.TXT_LOGIN_USER.BackColor = System.Drawing.Color.WhiteSmoke;
            this.TXT_LOGIN_USER.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_LOGIN_USER.Location = new System.Drawing.Point(88, 56);
            this.TXT_LOGIN_USER.Margin = new System.Windows.Forms.Padding(2);
            this.TXT_LOGIN_USER.Name = "TXT_LOGIN_USER";
            this.TXT_LOGIN_USER.Size = new System.Drawing.Size(200, 26);
            this.TXT_LOGIN_USER.TabIndex = 5;
            // 
            // VALIDAR_PROCESO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkRed;
            this.ClientSize = new System.Drawing.Size(371, 212);
            this.Controls.Add(this.BTN_LOGIN_ENTER);
            this.Controls.Add(this.LBL_LOGIN_PASSWORD);
            this.Controls.Add(this.LBL_LOGIN_USER);
            this.Controls.Add(this.TXT_LOGIN_PASSWORD);
            this.Controls.Add(this.TXT_LOGIN_USER);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "VALIDAR_PROCESO";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Validar Proceso";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTN_LOGIN_ENTER;
        private System.Windows.Forms.Label LBL_LOGIN_PASSWORD;
        private System.Windows.Forms.Label LBL_LOGIN_USER;
        private System.Windows.Forms.TextBox TXT_LOGIN_PASSWORD;
        private System.Windows.Forms.TextBox TXT_LOGIN_USER;
    }
}