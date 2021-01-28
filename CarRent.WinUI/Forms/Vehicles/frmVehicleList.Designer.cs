namespace CarRent.WinUI.Forms.Vehicles
{
    partial class frmVehicleList
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
            this.dgvVehicleList = new System.Windows.Forms.DataGridView();
            this.btnAddVehicle = new System.Windows.Forms.Button();
            this.lblNoOfCars = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.Pretraga = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbBrand = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehicleList)).BeginInit();
            this.Pretraga.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvVehicleList
            // 
            this.dgvVehicleList.AllowUserToAddRows = false;
            this.dgvVehicleList.AllowUserToDeleteRows = false;
            this.dgvVehicleList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVehicleList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVehicleList.GridColor = System.Drawing.SystemColors.Menu;
            this.dgvVehicleList.Location = new System.Drawing.Point(12, 89);
            this.dgvVehicleList.Name = "dgvVehicleList";
            this.dgvVehicleList.ReadOnly = true;
            this.dgvVehicleList.Size = new System.Drawing.Size(776, 270);
            this.dgvVehicleList.TabIndex = 0;
            this.dgvVehicleList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVehicleList_CellClick_1);
            // 
            // btnAddVehicle
            // 
            this.btnAddVehicle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnAddVehicle.Location = new System.Drawing.Point(529, 365);
            this.btnAddVehicle.Name = "btnAddVehicle";
            this.btnAddVehicle.Size = new System.Drawing.Size(142, 32);
            this.btnAddVehicle.TabIndex = 1;
            this.btnAddVehicle.Text = "Add vehicle";
            this.btnAddVehicle.UseVisualStyleBackColor = true;
            this.btnAddVehicle.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblNoOfCars
            // 
            this.lblNoOfCars.AutoSize = true;
            this.lblNoOfCars.Location = new System.Drawing.Point(9, 376);
            this.lblNoOfCars.Name = "lblNoOfCars";
            this.lblNoOfCars.Size = new System.Drawing.Size(85, 13);
            this.lblNoOfCars.TabIndex = 3;
            this.lblNoOfCars.Text = "Number of cars: ";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRefresh.Location = new System.Drawing.Point(677, 365);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(111, 32);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Refresh list";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(44, 37);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(222, 20);
            this.txtName.TabIndex = 5;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // Pretraga
            // 
            this.Pretraga.Controls.Add(this.btnSearch);
            this.Pretraga.Controls.Add(this.checkBox1);
            this.Pretraga.Controls.Add(this.label2);
            this.Pretraga.Controls.Add(this.cbBrand);
            this.Pretraga.Controls.Add(this.label1);
            this.Pretraga.Controls.Add(this.txtName);
            this.Pretraga.Location = new System.Drawing.Point(176, 12);
            this.Pretraga.Name = "Pretraga";
            this.Pretraga.Size = new System.Drawing.Size(612, 71);
            this.Pretraga.TabIndex = 6;
            this.Pretraga.TabStop = false;
            this.Pretraga.Text = "Search";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(521, 34);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.checkBox1.Location = new System.Drawing.Point(447, 36);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(56, 17);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.Text = "Active";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(290, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Brand";
            // 
            // cbBrand
            // 
            this.cbBrand.FormattingEnabled = true;
            this.cbBrand.Location = new System.Drawing.Point(293, 36);
            this.cbBrand.Name = "cbBrand";
            this.cbBrand.Size = new System.Drawing.Size(139, 21);
            this.cbBrand.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Name of vehicle";
            // 
            // frmVehicleList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 440);
            this.Controls.Add(this.Pretraga);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblNoOfCars);
            this.Controls.Add(this.btnAddVehicle);
            this.Controls.Add(this.dgvVehicleList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmVehicleList";
            this.Text = "frmVehicleList";
            this.Load += new System.EventHandler(this.frmVehicleList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehicleList)).EndInit();
            this.Pretraga.ResumeLayout(false);
            this.Pretraga.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvVehicleList;
        private System.Windows.Forms.Button btnAddVehicle;
        private System.Windows.Forms.Label lblNoOfCars;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.GroupBox Pretraga;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbBrand;
        private System.Windows.Forms.Button btnSearch;
    }
}