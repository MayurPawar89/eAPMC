namespace eAPMC.UserControls
{
    partial class PincodeFinder
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvPincodes = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPincodes)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPincodes
            // 
            this.dgvPincodes.AllowUserToAddRows = false;
            this.dgvPincodes.AllowUserToDeleteRows = false;
            this.dgvPincodes.AllowUserToOrderColumns = true;
            this.dgvPincodes.AllowUserToResizeColumns = false;
            this.dgvPincodes.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(50)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Thistle;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvPincodes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPincodes.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.dgvPincodes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPincodes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvPincodes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPincodes.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(50)))), ((int)(((byte)(102)))));
            this.dgvPincodes.Location = new System.Drawing.Point(0, 0);
            this.dgvPincodes.MultiSelect = false;
            this.dgvPincodes.Name = "dgvPincodes";
            this.dgvPincodes.ReadOnly = true;
            this.dgvPincodes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(50)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Thistle;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvPincodes.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPincodes.Size = new System.Drawing.Size(475, 153);
            this.dgvPincodes.TabIndex = 1;
            this.dgvPincodes.SelectionChanged += new System.EventHandler(this.dgvPincodes_SelectionChanged);
            // 
            // PincodeFinder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvPincodes);
            this.Name = "PincodeFinder";
            this.Size = new System.Drawing.Size(475, 153);
            this.Load += new System.EventHandler(this.PincodeFinder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPincodes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvPincodes;


    }
}
