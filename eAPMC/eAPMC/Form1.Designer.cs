namespace eAPMC
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
            this.pnlLoginButton = new System.Windows.Forms.Panel();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlDataBase = new System.Windows.Forms.Panel();
            this.lblDataBase = new System.Windows.Forms.Label();
            this.cmbDatabaseName = new System.Windows.Forms.ComboBox();
            this.pnlUser = new System.Windows.Forms.Panel();
            this.Label4 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.pnlLogin = new System.Windows.Forms.Panel();
            this.pnlLoginButton.SuspendLayout();
            this.pnlDataBase.SuspendLayout();
            this.pnlUser.SuspendLayout();
            this.pnlLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLoginButton
            // 
            this.pnlLoginButton.BackColor = System.Drawing.Color.Transparent;
            this.pnlLoginButton.Controls.Add(this.btnCancel);
            this.pnlLoginButton.Controls.Add(this.btnLogin);
            this.pnlLoginButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlLoginButton.Location = new System.Drawing.Point(0, 98);
            this.pnlLoginButton.Name = "pnlLoginButton";
            this.pnlLoginButton.Size = new System.Drawing.Size(221, 35);
            this.pnlLoginButton.TabIndex = 22;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(83)))), ((int)(((byte)(188)))));
            this.btnLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnLogin.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(41)))), ((int)(((byte)(146)))));
            this.btnLogin.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(41)))), ((int)(((byte)(146)))));
            this.btnLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(41)))), ((int)(((byte)(146)))));
            this.btnLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(41)))), ((int)(((byte)(146)))));
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(72, 5);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(69, 23);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "&Login";
            this.btnLogin.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLogin.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(83)))), ((int)(((byte)(188)))));
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(41)))), ((int)(((byte)(146)))));
            this.btnCancel.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(41)))), ((int)(((byte)(146)))));
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(41)))), ((int)(((byte)(146)))));
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(41)))), ((int)(((byte)(146)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(144, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(69, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // pnlDataBase
            // 
            this.pnlDataBase.BackColor = System.Drawing.Color.Transparent;
            this.pnlDataBase.Controls.Add(this.cmbDatabaseName);
            this.pnlDataBase.Controls.Add(this.lblDataBase);
            this.pnlDataBase.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlDataBase.Location = new System.Drawing.Point(0, 68);
            this.pnlDataBase.Name = "pnlDataBase";
            this.pnlDataBase.Size = new System.Drawing.Size(221, 30);
            this.pnlDataBase.TabIndex = 21;
            // 
            // lblDataBase
            // 
            this.lblDataBase.AutoSize = true;
            this.lblDataBase.BackColor = System.Drawing.Color.Transparent;
            this.lblDataBase.Font = new System.Drawing.Font("Arial", 7.95F, System.Drawing.FontStyle.Bold);
            this.lblDataBase.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(25)))), ((int)(((byte)(130)))));
            this.lblDataBase.Location = new System.Drawing.Point(1, 6);
            this.lblDataBase.MaximumSize = new System.Drawing.Size(71, 14);
            this.lblDataBase.MinimumSize = new System.Drawing.Size(71, 14);
            this.lblDataBase.Name = "lblDataBase";
            this.lblDataBase.Size = new System.Drawing.Size(71, 14);
            this.lblDataBase.TabIndex = 14;
            this.lblDataBase.Text = "DATABASE:";
            this.lblDataBase.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbDatabaseName
            // 
            this.cmbDatabaseName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDatabaseName.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDatabaseName.FormattingEnabled = true;
            this.cmbDatabaseName.IntegralHeight = false;
            this.cmbDatabaseName.ItemHeight = 14;
            this.cmbDatabaseName.Location = new System.Drawing.Point(72, 2);
            this.cmbDatabaseName.Name = "cmbDatabaseName";
            this.cmbDatabaseName.Size = new System.Drawing.Size(141, 22);
            this.cmbDatabaseName.TabIndex = 2;
            // 
            // pnlUser
            // 
            this.pnlUser.BackColor = System.Drawing.Color.Transparent;
            this.pnlUser.Controls.Add(this.txtPassword);
            this.pnlUser.Controls.Add(this.Label3);
            this.pnlUser.Controls.Add(this.txtUserName);
            this.pnlUser.Controls.Add(this.Label4);
            this.pnlUser.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlUser.Location = new System.Drawing.Point(0, 0);
            this.pnlUser.Name = "pnlUser";
            this.pnlUser.Size = new System.Drawing.Size(221, 68);
            this.pnlUser.TabIndex = 20;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.BackColor = System.Drawing.Color.Transparent;
            this.Label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(25)))), ((int)(((byte)(130)))));
            this.Label4.Location = new System.Drawing.Point(1, 11);
            this.Label4.MaximumSize = new System.Drawing.Size(71, 14);
            this.Label4.MinimumSize = new System.Drawing.Size(71, 14);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(71, 14);
            this.Label4.TabIndex = 9;
            this.Label4.Text = "USERNAME:";
            this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.SystemColors.Window;
            this.txtUserName.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(72, 8);
            this.txtUserName.MaxLength = 50;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(141, 20);
            this.txtUserName.TabIndex = 0;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.BackColor = System.Drawing.Color.Transparent;
            this.Label3.Font = new System.Drawing.Font("Arial", 7.95F, System.Drawing.FontStyle.Bold);
            this.Label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(25)))), ((int)(((byte)(130)))));
            this.Label3.Location = new System.Drawing.Point(1, 43);
            this.Label3.MaximumSize = new System.Drawing.Size(71, 14);
            this.Label3.MinimumSize = new System.Drawing.Size(71, 14);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(71, 14);
            this.Label3.TabIndex = 10;
            this.Label3.Text = "PASSWORD:";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.SystemColors.Window;
            this.txtPassword.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(72, 39);
            this.txtPassword.MaxLength = 100;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(141, 20);
            this.txtPassword.TabIndex = 1;
            // 
            // pnlLogin
            // 
            this.pnlLogin.Controls.Add(this.pnlUser);
            this.pnlLogin.Controls.Add(this.pnlDataBase);
            this.pnlLogin.Controls.Add(this.pnlLoginButton);
            this.pnlLogin.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlLogin.Location = new System.Drawing.Point(12, 12);
            this.pnlLogin.Name = "pnlLogin";
            this.pnlLogin.Size = new System.Drawing.Size(221, 133);
            this.pnlLogin.TabIndex = 158;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 711);
            this.Controls.Add(this.pnlLogin);
            this.Name = "Form1";
            this.Text = "Form1";
            this.pnlLoginButton.ResumeLayout(false);
            this.pnlDataBase.ResumeLayout(false);
            this.pnlDataBase.PerformLayout();
            this.pnlUser.ResumeLayout(false);
            this.pnlUser.PerformLayout();
            this.pnlLogin.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLoginButton;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Panel pnlDataBase;
        internal System.Windows.Forms.ComboBox cmbDatabaseName;
        internal System.Windows.Forms.Label lblDataBase;
        private System.Windows.Forms.Panel pnlUser;
        internal System.Windows.Forms.TextBox txtPassword;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox txtUserName;
        internal System.Windows.Forms.Label Label4;
        private System.Windows.Forms.Panel pnlLogin;

    }
}

