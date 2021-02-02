using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRent.WinUI.Forms.Rents
{
    public partial class frmRentCar : Form
    {
        private int id;
        protected APIService _serviceVehicle = new APIService("Vehicle");
        protected APIService _serviceAddRent = new APIService("Rent");
        protected APIService _serviceRentCheck = new APIService("Rent/checkavailability");
        private double price;

        public frmRentCar()
        {
            InitializeComponent();
        }

        public frmRentCar(int id, double price) : this()
        {
            this.id = id;
            this.price = price;
        }

        private async void frmRentCar_Load(object sender, EventArgs e)
        {
            var car = await _serviceVehicle.GetById<Model.Vehicle>(id);
            if (car != null)
            {
                lblCarName.Text = car.Name;
            }
        }

        private async Task<bool> ValidateRent()
        {
            if (dtpEnd.Value.Date <= dtpFrom.Value.Date)
            {
                err.SetError(dtpEnd, "End date can not be in past or same as start day.");
                return false;
            }else if(dtpFrom.Value.Date < DateTime.Now.Date)
            {
                err.SetError(dtpFrom, "Start day can not be in past.");
                return false;
            }
            else
            {
                lblInfo.Visible = false;
                err.Clear();
                var request = new Model.Requests.Rent.RentSearchRequest()
                {
                    VehicleId = id,
                    EndDate = dtpEnd.Value,
                    StartDate = dtpFrom.Value
                };
                var rent = await _serviceRentCheck.Get<List<Model.Rent>>(request);
                if (rent == null)
                {
                    lblNextTime.Visible = false;
                    lblAvailableStatus.Visible = true;
                    lblAvailableStatus.ForeColor = Color.Green;
                    lblAvailableStatus.Text = "Available";
                    var days = (dtpEnd.Value - dtpFrom.Value).Days + 1;
                    lblTotalPrice.Text = "Total price is " + Math.Round((price * days), 2).ToString() + " BAM";
                    lblTotalPrice.Visible = true;
                    return true;
                }
                else
                {
                    DateTime next = rent[0].EndDate;
                    for (int i = 0; i < rent.Count - 1; ++i)
                    {
                        if (next < rent[i + 1].EndDate)
                            next = rent[i + 1].EndDate;
                    }
                    lblNextTime.Visible = true;
                    lblNextTime.Text = "Available after: " + next.Date.ToString().Substring(0, 9);
                    lblAvailableStatus.Visible = true;
                    lblAvailableStatus.ForeColor = Color.Red;
                    lblAvailableStatus.Text = "Unavailable";
                    return false;
                }
            }
        }
        private async void btnAvailable_ClickAsync(object sender, EventArgs e)
        {
            if (await ValidateRent())
            {
                btnRent.Enabled = true;
            }
        }

        private async void btnRent_Click(object sender, EventArgs e)
        {
            if (await ValidateRent())
            {
                btnRent.Enabled = true;
                var days = (dtpEnd.Value - dtpFrom.Value).Days + 1;
                Model.Requests.Rent.RentInsert request = new Model.Requests.Rent.RentInsert()
                {
                    DateCreated = DateTime.Now,
                    EndDate = dtpEnd.Value,
                    IsReviewed = false,
                    StartDate = dtpFrom.Value,
                    TotalPrice = Math.Round((price * days), 2),
                    UserId = APIService.loggedUser.Id,
                    VehicleId = id
                };

                try
                {
                    var result = await _serviceAddRent.Insert<Model.Rent>(request);
                    if(result != null)
                    {
                        MessageBox.Show("Vehicle successfully rented!", "Status", MessageBoxButtons.OK,MessageBoxIcon.Information);
                        Close();
                    }
                }
                catch (Exception exx)
                {
                    MessageBox.Show(exx.Message, "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                
            }
        }
    }
}
