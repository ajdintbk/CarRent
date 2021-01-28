﻿namespace CarRent.WinUI.Forms
{
    partial class frmHome
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
            this.btnVehicles = new System.Windows.Forms.Button();
            this.btnUsers = new System.Windows.Forms.Button();
            this.btnRents = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnVehicles
            // 
            this.btnVehicles.BackColor = System.Drawing.Color.SlateGray;
            this.btnVehicles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVehicles.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnVehicles.ForeColor = System.Drawing.Color.White;
            this.btnVehicles.Location = new System.Drawing.Point(15, 15);
            this.btnVehicles.Name = "btnVehicles";
            this.btnVehicles.Size = new System.Drawing.Size(110, 42);
            this.btnVehicles.TabIndex = 0;
            this.btnVehicles.Text = "Vehicles";
            this.btnVehicles.UseVisualStyleBackColor = false;
            this.btnVehicles.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnUsers
            // 
            this.btnUsers.BackColor = System.Drawing.Color.SlateGray;
            this.btnUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnUsers.ForeColor = System.Drawing.Color.White;
            this.btnUsers.Location = new System.Drawing.Point(131, 15);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(110, 42);
            this.btnUsers.TabIndex = 1;
            this.btnUsers.Text = "Users";
            this.btnUsers.UseVisualStyleBackColor = false;
            this.btnUsers.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnRents
            // 
            this.btnRents.BackColor = System.Drawing.Color.SlateGray;
            this.btnRents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRents.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRents.ForeColor = System.Drawing.Color.Transparent;
            this.btnRents.Location = new System.Drawing.Point(247, 15);
            this.btnRents.Name = "btnRents";
            this.btnRents.Size = new System.Drawing.Size(110, 42);
            this.btnRents.TabIndex = 2;
            this.btnRents.Text = "Rents";
            this.btnRents.UseVisualStyleBackColor = false;
            this.btnRents.Click += new System.EventHandler(this.btnRents_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSlateGray;
            this.panel1.Controls.Add(this.btnVehicles);
            this.panel1.Controls.Add(this.btnRents);
            this.panel1.Controls.Add(this.btnUsers);
            this.panel1.Location = new System.Drawing.Point(-3, -3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(807, 72);
            this.panel1.TabIndex = 3;
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.label1);
            this.pnlContent.Location = new System.Drawing.Point(-3, 75);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(807, 436);
            this.pnlContent.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(330, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose item from menu";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // frmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 543);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.panel1);
            this.Name = "frmHome";
            this.Text = "frmHome";
            this.panel1.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnVehicles;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btnRents;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Label label1;
    }
}