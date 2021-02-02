namespace CarRent.WinUI.Forms.Favorites
{
    partial class frmFavoriteList
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
            this.dgvFavorites = new System.Windows.Forms.DataGridView();
            this.lblNo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFavorites)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvFavorites
            // 
            this.dgvFavorites.AllowUserToAddRows = false;
            this.dgvFavorites.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFavorites.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFavorites.Location = new System.Drawing.Point(12, 106);
            this.dgvFavorites.Name = "dgvFavorites";
            this.dgvFavorites.Size = new System.Drawing.Size(776, 210);
            this.dgvFavorites.TabIndex = 0;
            this.dgvFavorites.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFavorites_CellClick);
            // 
            // lblNo
            // 
            this.lblNo.AutoSize = true;
            this.lblNo.Location = new System.Drawing.Point(305, 194);
            this.lblNo.Name = "lblNo";
            this.lblNo.Size = new System.Drawing.Size(143, 13);
            this.lblNo.TabIndex = 1;
            this.lblNo.Text = "There is no favorite vehicles.";
            this.lblNo.Visible = false;
            // 
            // frmFavoriteList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblNo);
            this.Controls.Add(this.dgvFavorites);
            this.Name = "frmFavoriteList";
            this.Text = "frmFavoriteList";
            this.Load += new System.EventHandler(this.frmFavoriteList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFavorites)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvFavorites;
        private System.Windows.Forms.Label lblNo;
    }
}