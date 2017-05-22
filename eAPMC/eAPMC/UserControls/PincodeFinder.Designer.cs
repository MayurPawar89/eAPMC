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
            this.dgvPincodes = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPincodes)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPincodes
            // 
            this.dgvPincodes.AllowUserToAddRows = false;
            this.dgvPincodes.AllowUserToDeleteRows = false;
            this.dgvPincodes.AllowUserToOrderColumns = true;
            this.dgvPincodes.AllowUserToResizeRows = false;
            this.dgvPincodes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvPincodes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPincodes.Location = new System.Drawing.Point(0, 0);
            this.dgvPincodes.MultiSelect = false;
            this.dgvPincodes.Name = "dgvPincodes";
            this.dgvPincodes.ReadOnly = true;
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
