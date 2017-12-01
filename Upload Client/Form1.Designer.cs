namespace Upload_Client
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
            this.btn_login = new System.Windows.Forms.Button();
            this.t_username = new System.Windows.Forms.TextBox();
            this.t_password = new System.Windows.Forms.TextBox();
            this.btn_upload = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_login
            // 
            this.btn_login.Location = new System.Drawing.Point(12, 65);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(100, 23);
            this.btn_login.TabIndex = 0;
            this.btn_login.Text = "Login";
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.btn_get_token_Click);
            // 
            // t_username
            // 
            this.t_username.Location = new System.Drawing.Point(12, 13);
            this.t_username.Name = "t_username";
            this.t_username.Size = new System.Drawing.Size(100, 20);
            this.t_username.TabIndex = 1;
            this.t_username.Text = "Username";
            this.t_username.Enter += new System.EventHandler(this.t_username_Enter);
            this.t_username.Leave += new System.EventHandler(this.t_username_Leave);
            // 
            // t_password
            // 
            this.t_password.Location = new System.Drawing.Point(12, 39);
            this.t_password.Name = "t_password";
            this.t_password.PasswordChar = '*';
            this.t_password.Size = new System.Drawing.Size(100, 20);
            this.t_password.TabIndex = 2;
            this.t_password.Text = "Password";
            this.t_password.Enter += new System.EventHandler(this.t_password_Enter);
            this.t_password.Leave += new System.EventHandler(this.t_password_Leave);
            // 
            // btn_upload
            // 
            this.btn_upload.Location = new System.Drawing.Point(12, 95);
            this.btn_upload.Name = "btn_upload";
            this.btn_upload.Size = new System.Drawing.Size(100, 23);
            this.btn_upload.TabIndex = 3;
            this.btn_upload.Text = "Upload";
            this.btn_upload.UseVisualStyleBackColor = true;
            this.btn_upload.Click += new System.EventHandler(this.btn_upload_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btn_upload);
            this.Controls.Add(this.t_password);
            this.Controls.Add(this.t_username);
            this.Controls.Add(this.btn_login);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.TextBox t_username;
        private System.Windows.Forms.TextBox t_password;
        private System.Windows.Forms.Button btn_upload;
    }
}

