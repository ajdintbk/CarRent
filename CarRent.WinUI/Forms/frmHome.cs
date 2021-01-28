using CarRent.WinUI.Forms.Rents;
using CarRent.WinUI.Forms.User;
using CarRent.WinUI.Forms.Vehicles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRent.WinUI.Forms
{
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmVehicleList vehiclesList = new frmVehicleList();
            vehiclesList.TopLevel = false;
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(vehiclesList);
            vehiclesList.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            frmUserList userList = new frmUserList();
            userList.TopLevel = false;
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(userList);
            userList.Show();
        }

        private void btnRents_Click(object sender, EventArgs e)
        {
            frmRentsList frmRents = new frmRentsList();
            frmRents.TopLevel = false;
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(frmRents);
            frmRents.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
