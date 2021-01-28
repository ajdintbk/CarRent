namespace CarRent.WinUI.Forms.Rents
{
    partial class frmRentCar
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblCarName = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.btnRent = new System.Windows.Forms.Button();
            this.lblAvailableStatus = new System.Windows.Forms.Label();
            this.err = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnAvailable = new System.Windows.Forms.Button();
            this.lblNextTime = new System.Windows.Forms.Label();
            this.txtTotalPrice = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.err)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(180, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select rental dates for";
            // 
            // lblCarName
            // 
            this.lblCarName.AutoSize = true;
            this.lblCarName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblCarName.Location = new System.Drawing.Point(318, 32);
            this.lblCarName.Name = "lblCarName";
            this.lblCarName.Size = new System.Drawing.Size(51, 16);
            this.lblCarName.TabIndex = 1;
            this.lblCarName.Text = "label2";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Location = new System.Drawing.Point(62, 94);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(200, 20);
            this.dtpFrom.TabIndex = 2;
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(332, 94);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(200, 20);
            this.dtpEnd.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "From";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(306, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "To";
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.AutoSize = true;
            this.lblTotalPrice.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblTotalPrice.Location = new System.Drawing.Point(381, 250);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(70, 13);
            this.lblTotalPrice.TabIndex = 6;
            this.lblTotalPrice.Text = "Total price is ";
            this.lblTotalPrice.Visible = false;
            // 
            // btnRent
            // 
            this.btnRent.BackColor = System.Drawing.Color.SteelBlue;
            this.btnRent.Enabled = false;
            this.btnRent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRent.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRent.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnRent.Location = new System.Drawing.Point(384, 206);
            this.btnRent.Name = "btnRent";
            this.btnRent.Size = new System.Drawing.Size(148, 35);
            this.btnRent.TabIndex = 17;
            this.btnRent.Text = "Rent";
            this.btnRent.UseVisualStyleBackColor = false;
            this.btnRent.Click += new System.EventHandler(this.btnRent_Click);
            // 
            // lblAvailableStatus
            // 
            this.lblAvailableStatus.AutoSize = true;
            this.lblAvailableStatus.Location = new System.Drawing.Point(404, 159);
            this.lblAvailableStatus.Name = "lblAvailableStatus";
            this.lblAvailableStatus.Size = new System.Drawing.Size(37, 13);
            this.lblAvailableStatus.TabIndex = 18;
            this.lblAvailableStatus.Text = "Status";
            this.lblAvailableStatus.Visible = false;
            // 
            // err
            // 
            this.err.ContainerControl = this;
            // 
            // btnAvailable
            // 
            this.btnAvailable.Location = new System.Drawing.Point(407, 124);
            this.btnAvailable.Name = "btnAvailable";
            this.btnAvailable.Size = new System.Drawing.Size(125, 23);
            this.btnAvailable.TabIndex = 19;
            this.btnAvailable.Text = "Check availability";
            this.btnAvailable.UseVisualStyleBackColor = true;
            this.btnAvailable.Click += new System.EventHandler(this.btnAvailable_ClickAsync);
            // 
            // lblNextTime
            // 
            this.lblNextTime.AutoSize = true;
            this.lblNextTime.Location = new System.Drawing.Point(372, 183);
            this.lblNextTime.Name = "lblNextTime";
            this.lblNextTime.Size = new System.Drawing.Size(37, 13);
            this.lblNextTime.TabIndex = 20;
            this.lblNextTime.Text = "Status";
            this.lblNextTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblNextTime.Visible = false;
            // 
            // txtTotalPrice
            // 
            this.txtTotalPrice.Location = new System.Drawing.Point(29, 243);
            this.txtTotalPrice.Name = "txtTotalPrice";
            this.txtTotalPrice.ReadOnly = true;
            this.txtTotalPrice.Size = new System.Drawing.Size(100, 20);
            this.txtTotalPrice.TabIndex = 21;
            this.txtTotalPrice.Visible = false;
            // 
            // frmRentCar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 286);
            this.Controls.Add(this.txtTotalPrice);
            this.Controls.Add(this.lblNextTime);
            this.Controls.Add(this.btnAvailable);
            this.Controls.Add(this.lblAvailableStatus);
            this.Controls.Add(this.btnRent);
            this.Controls.Add(this.lblTotalPrice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.lblCarName);
            this.Controls.Add(this.label1);
            this.Name = "frmRentCar";
            this.Text = "frmRentCar";
            this.Load += new System.EventHandler(this.frmRentCar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.err)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCarName;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.Button btnRent;
        private System.Windows.Forms.Label lblAvailableStatus;
        private System.Windows.Forms.ErrorProvider err;
        private System.Windows.Forms.Button btnAvailable;
        private System.Windows.Forms.Label lblNextTime;
        private System.Windows.Forms.TextBox txtTotalPrice;
    }
}