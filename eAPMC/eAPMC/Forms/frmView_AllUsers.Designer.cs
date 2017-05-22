namespace eAPMC.Forms
{
    partial class frmView_AllUsers
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdAllUsers = new System.Windows.Forms.RadioButton();
            this.rdActiveUsers = new System.Windows.Forms.RadioButton();
            this.rdBlockedUsers = new System.Windows.Forms.RadioButton();
            this.dgvUsersList = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsersList)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvUsersList);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 53);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(809, 556);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdBlockedUsers);
            this.groupBox1.Controls.Add(this.rdActiveUsers);
            this.groupBox1.Controls.Add(this.rdAllUsers);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(809, 53);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "User Type";
            // 
            // rdAllUsers
            // 
            this.rdAllUsers.AutoSize = true;
            this.rdAllUsers.Location = new System.Drawing.Point(59, 19);
            this.rdAllUsers.Name = "rdAllUsers";
            this.rdAllUsers.Size = new System.Drawing.Size(66, 17);
            this.rdAllUsers.TabIndex = 0;
            this.rdAllUsers.Text = "All Users";
            this.rdAllUsers.UseVisualStyleBackColor = true;
            this.rdAllUsers.CheckedChanged += new System.EventHandler(this.rdAllUsers_CheckedChanged);
            // 
            // rdActiveUsers
            // 
            this.rdActiveUsers.AutoSize = true;
            this.rdActiveUsers.Location = new System.Drawing.Point(140, 19);
            this.rdActiveUsers.Name = "rdActiveUsers";
            this.rdActiveUsers.Size = new System.Drawing.Size(85, 17);
            this.rdActiveUsers.TabIndex = 1;
            this.rdActiveUsers.Text = "Active Users";
            this.rdActiveUsers.UseVisualStyleBackColor = true;
            this.rdActiveUsers.CheckedChanged += new System.EventHandler(this.rdActiveUsers_CheckedChanged);
            // 
            // rdBlockedUsers
            // 
            this.rdBlockedUsers.AutoSize = true;
            this.rdBlockedUsers.Location = new System.Drawing.Point(240, 19);
            this.rdBlockedUsers.Name = "rdBlockedUsers";
            this.rdBlockedUsers.Size = new System.Drawing.Size(94, 17);
            this.rdBlockedUsers.TabIndex = 2;
            this.rdBlockedUsers.Text = "Blocked Users";
            this.rdBlockedUsers.UseVisualStyleBackColor = true;
            this.rdBlockedUsers.CheckedChanged += new System.EventHandler(this.rdBlockedUsers_CheckedChanged);
            // 
            // dgvUsersList
            // 
            this.dgvUsersList.AllowUserToAddRows = false;
            this.dgvUsersList.AllowUserToDeleteRows = false;
            this.dgvUsersList.AllowUserToOrderColumns = true;
            this.dgvUsersList.AllowUserToResizeRows = false;
            this.dgvUsersList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsersList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsersList.Location = new System.Drawing.Point(0, 0);
            this.dgvUsersList.MultiSelect = false;
            this.dgvUsersList.Name = "dgvUsersList";
            this.dgvUsersList.ReadOnly = true;
            this.dgvUsersList.Size = new System.Drawing.Size(809, 556);
            this.dgvUsersList.TabIndex = 0;
            // 
            // frmView_AllUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 609);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmView_AllUsers";
            this.Text = "frmView_AllUsers";
            this.Load += new System.EventHandler(this.frmView_AllUsers_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsersList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvUsersList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdBlockedUsers;
        private System.Windows.Forms.RadioButton rdActiveUsers;
        private System.Windows.Forms.RadioButton rdAllUsers;
    }
}