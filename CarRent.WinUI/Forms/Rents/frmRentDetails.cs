using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRent.WinUI.Forms.Rents
{
    public partial class frmRentDetails : Form
    {
        protected APIService _serviceRent = new APIService("Rent");
        private int rent;

        public frmRentDetails()
        {
            InitializeComponent();
        }

        public frmRentDetails(int rent):this()
        {
            this.rent = rent;
        }

        private Image GetImage(byte[] img)
        {
            using (MemoryStream ms = new MemoryStream(img))
                return Image.FromStream(ms);
        }
        private async void frmRentDetails_Load(object sender, EventArgs e)
        {
            var rentDetails = await _serviceRent.GetById<Model.Rent>(rent);
            if (rentDetails != null)
            {
                txtName.Text = rentDetails.Vehicle.Name;
                txtPrice.Text = rentDetails.Vehicle.Price.ToString();
                txtTotalPrice.Text = rentDetails.TotalPrice.ToString();
                txtTransmission.Text = rentDetails.Vehicle.Transmission;
                txtYear.Text = rentDetails.Vehicle.YearManufactured.ToString();
                txtFullName.Text = rentDetails.User.FirstName + " " + rentDetails.User.LastName;
                txtEmail.Text = rentDetails.User.Email;
                txtPhone.Text = rentDetails.User.Phone;

                dtpFrom.Value = rentDetails.StartDate;
                dtpTo.Value = rentDetails.EndDate;
                chbPayed.Checked = rentDetails.IsPayed;

                if(rentDetails.Vehicle.Image.Length > 0)
                    pictureBox1.Image = GetImage(rentDetails.Vehicle.Image);

                if (DateTime.Now < rentDetails.EndDate)
                {
                    lblStatus.Text = "Status: Still reserved";
                    lblStatus.ForeColor = Color.Red;
                }
                else
                {
                    lblStatus.Text = "Status: Reservation ended";
                    lblStatus.ForeColor = Color.Green;
                }
            }
        }
    }
}
