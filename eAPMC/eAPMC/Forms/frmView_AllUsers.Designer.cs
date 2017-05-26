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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmView_AllUsers));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvUsersList = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.rdBlockedUsers = new System.Windows.Forms.RadioButton();
            this.rdActiveUsers = new System.Windows.Forms.RadioButton();
            this.rdAllUsers = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pnlBottomButton = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsersList)).BeginInit();
            this.panel3.SuspendLayout();
            this.pnlBottomButton.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 40);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.panel1.Size = new System.Drawing.Size(944, 566);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.dgvUsersList);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(938, 563);
            this.panel2.TabIndex = 59;
            // 
            // dgvUsersList
            // 
            this.dgvUsersList.AllowUserToAddRows = false;
            this.dgvUsersList.AllowUserToDeleteRows = false;
            this.dgvUsersList.AllowUserToOrderColumns = true;
            this.dgvUsersList.AllowUserToResizeRows = false;
            this.dgvUsersList.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvUsersList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUsersList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsersList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsersList.Location = new System.Drawing.Point(1, 1);
            this.dgvUsersList.MultiSelect = false;
            this.dgvUsersList.Name = "dgvUsersList";
            this.dgvUsersList.ReadOnly = true;
            this.dgvUsersList.Size = new System.Drawing.Size(936, 561);
            this.dgvUsersList.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(41)))), ((int)(((byte)(146)))));
            this.label1.Location = new System.Drawing.Point(1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(936, 1);
            this.label1.TabIndex = 45;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(50)))), ((int)(((byte)(102)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(41)))), ((int)(((byte)(146)))));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1, 562);
            this.label2.TabIndex = 44;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(50)))), ((int)(((byte)(102)))));
            this.label3.Dock = System.Windows.Forms.DockStyle.Right;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(41)))), ((int)(((byte)(146)))));
            this.label3.Location = new System.Drawing.Point(937, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1, 562);
            this.label3.TabIndex = 43;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(50)))), ((int)(((byte)(102)))));
            this.label4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(41)))), ((int)(((byte)(146)))));
            this.label4.Location = new System.Drawing.Point(0, 562);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(938, 1);
            this.label4.TabIndex = 42;
            this.label4.Text = "label4";
            // 
            // rdBlockedUsers
            // 
            this.rdBlockedUsers.AutoSize = true;
            this.rdBlockedUsers.Location = new System.Drawing.Point(229, 8);
            this.rdBlockedUsers.Name = "rdBlockedUsers";
            this.rdBlockedUsers.Size = new System.Drawing.Size(100, 18);
            this.rdBlockedUsers.TabIndex = 2;
            this.rdBlockedUsers.Text = "Blocked Users";
            this.rdBlockedUsers.UseVisualStyleBackColor = true;
            this.rdBlockedUsers.CheckedChanged += new System.EventHandler(this.rdBlockedUsers_CheckedChanged);
            // 
            // rdActiveUsers
            // 
            this.rdActiveUsers.AutoSize = true;
            this.rdActiveUsers.Location = new System.Drawing.Point(112, 8);
            this.rdActiveUsers.Name = "rdActiveUsers";
            this.rdActiveUsers.Size = new System.Drawing.Size(92, 18);
            this.rdActiveUsers.TabIndex = 1;
            this.rdActiveUsers.Text = "Active Users";
            this.rdActiveUsers.UseVisualStyleBackColor = true;
            this.rdActiveUsers.CheckedChanged += new System.EventHandler(this.rdActiveUsers_CheckedChanged);
            // 
            // rdAllUsers
            // 
            this.rdAllUsers.AutoSize = true;
            this.rdAllUsers.Location = new System.Drawing.Point(18, 8);
            this.rdAllUsers.Name = "rdAllUsers";
            this.rdAllUsers.Size = new System.Drawing.Size(70, 18);
            this.rdAllUsers.TabIndex = 0;
            this.rdAllUsers.Text = "All Users";
            this.rdAllUsers.UseVisualStyleBackColor = true;
            this.rdAllUsers.CheckedChanged += new System.EventHandler(this.rdAllUsers_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pnlBottomButton);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 606);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.panel3.Size = new System.Drawing.Size(944, 50);
            this.panel3.TabIndex = 63;
            // 
            // pnlBottomButton
            // 
            this.pnlBottomButton.BackColor = System.Drawing.Color.Transparent;
            this.pnlBottomButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlBottomButton.BackgroundImage")));
            this.pnlBottomButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlBottomButton.Controls.Add(this.button3);
            this.pnlBottomButton.Controls.Add(this.btnNext);
            this.pnlBottomButton.Controls.Add(this.label16);
            this.pnlBottomButton.Controls.Add(this.button1);
            this.pnlBottomButton.Controls.Add(this.label18);
            this.pnlBottomButton.Controls.Add(this.label22);
            this.pnlBottomButton.Controls.Add(this.label30);
            this.pnlBottomButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBottomButton.Location = new System.Drawing.Point(3, 0);
            this.pnlBottomButton.Name = "pnlBottomButton";
            this.pnlBottomButton.Size = new System.Drawing.Size(938, 47);
            this.pnlBottomButton.TabIndex = 60;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(50)))), ((int)(((byte)(102)))));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(41)))), ((int)(((byte)(146)))));
            this.button3.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(41)))), ((int)(((byte)(146)))));
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(41)))), ((int)(((byte)(146)))));
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(41)))), ((int)(((byte)(146)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(838, 9);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(80, 30);
            this.button3.TabIndex = 55;
            this.button3.Text = "Cancel";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(50)))), ((int)(((byte)(102)))));
            this.btnNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(41)))), ((int)(((byte)(146)))));
            this.btnNext.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(41)))), ((int)(((byte)(146)))));
            this.btnNext.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(41)))), ((int)(((byte)(146)))));
            this.btnNext.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(41)))), ((int)(((byte)(146)))));
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.Location = new System.Drawing.Point(663, 9);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(80, 30);
            this.btnNext.TabIndex = 50;
            this.btnNext.Text = "Block";
            this.btnNext.UseVisualStyleBackColor = false;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Black;
            this.label16.Dock = System.Windows.Forms.DockStyle.Top;
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(41)))), ((int)(((byte)(146)))));
            this.label16.Location = new System.Drawing.Point(1, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(936, 1);
            this.label16.TabIndex = 45;
            this.label16.Text = "label16";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(50)))), ((int)(((byte)(102)))));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(41)))), ((int)(((byte)(146)))));
            this.button1.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(41)))), ((int)(((byte)(146)))));
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(41)))), ((int)(((byte)(146)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(41)))), ((int)(((byte)(146)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(750, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 30);
            this.button1.TabIndex = 51;
            this.button1.Text = "Updated";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(50)))), ((int)(((byte)(102)))));
            this.label18.Dock = System.Windows.Forms.DockStyle.Left;
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(41)))), ((int)(((byte)(146)))));
            this.label18.Location = new System.Drawing.Point(0, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(1, 46);
            this.label18.TabIndex = 44;
            this.label18.Text = "label18";
            // 
            // label22
            // 
            this.label22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(50)))), ((int)(((byte)(102)))));
            this.label22.Dock = System.Windows.Forms.DockStyle.Right;
            this.label22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(41)))), ((int)(((byte)(146)))));
            this.label22.Location = new System.Drawing.Point(937, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(1, 46);
            this.label22.TabIndex = 43;
            this.label22.Text = "label22";
            // 
            // label30
            // 
            this.label30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(50)))), ((int)(((byte)(102)))));
            this.label30.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label30.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(41)))), ((int)(((byte)(146)))));
            this.label30.Location = new System.Drawing.Point(0, 46);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(938, 1);
            this.label30.TabIndex = 42;
            this.label30.Text = "label30";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(3);
            this.panel4.Size = new System.Drawing.Size(944, 40);
            this.panel4.TabIndex = 60;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Transparent;
            this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel5.Controls.Add(this.rdBlockedUsers);
            this.panel5.Controls.Add(this.rdActiveUsers);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Controls.Add(this.label6);
            this.panel5.Controls.Add(this.rdAllUsers);
            this.panel5.Controls.Add(this.label7);
            this.panel5.Controls.Add(this.label8);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(938, 34);
            this.panel5.TabIndex = 59;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Black;
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(41)))), ((int)(((byte)(146)))));
            this.label5.Location = new System.Drawing.Point(1, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(936, 1);
            this.label5.TabIndex = 45;
            this.label5.Text = "label5";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(50)))), ((int)(((byte)(102)))));
            this.label6.Dock = System.Windows.Forms.DockStyle.Left;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(41)))), ((int)(((byte)(146)))));
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(1, 33);
            this.label6.TabIndex = 44;
            this.label6.Text = "label6";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(50)))), ((int)(((byte)(102)))));
            this.label7.Dock = System.Windows.Forms.DockStyle.Right;
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(41)))), ((int)(((byte)(146)))));
            this.label7.Location = new System.Drawing.Point(937, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(1, 33);
            this.label7.TabIndex = 43;
            this.label7.Text = "label7";
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(50)))), ((int)(((byte)(102)))));
            this.label8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(41)))), ((int)(((byte)(146)))));
            this.label8.Location = new System.Drawing.Point(0, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(938, 1);
            this.label8.TabIndex = 42;
            this.label8.Text = "label8";
            // 
            // frmView_AllUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(944, 656);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(50)))), ((int)(((byte)(102)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmView_AllUsers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmView_AllUsers";
            this.Load += new System.EventHandler(this.frmView_AllUsers_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsersList)).EndInit();
            this.panel3.ResumeLayout(false);
            this.pnlBottomButton.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvUsersList;
        private System.Windows.Forms.RadioButton rdBlockedUsers;
        private System.Windows.Forms.RadioButton rdActiveUsers;
        private System.Windows.Forms.RadioButton rdAllUsers;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel pnlBottomButton;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Button button3;
        internal System.Windows.Forms.Button btnNext;
        internal System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}