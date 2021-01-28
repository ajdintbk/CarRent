using CarRent.Model;
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
    public partial class frmExtendRent : Form
    {
        private Rent rent;
        protected APIService _serviceRent = new APIService("Rent");

        public frmExtendRent()
        {
            InitializeComponent();
        }

        public frmExtendRent(Rent rent) : this()
        {
            this.rent = rent;
        }
        private bool Validate(TextBox obj)
        {
            int temp;
            if (!string.IsNullOrEmpty(obj.Text) && int.TryParse(obj.Text, out temp))
            {
                if (int.Parse(obj.Text) > 0)
                    return true;
            }
            errorProvider1.SetError(obj, "Value is not valid!");
            return false;
        }
        private void frmExtendRent_Load(object sender, EventArgs e)
        {
            
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Validate(txtNumberOfDays))
            {
                var days = int.Parse(txtNumberOfDays.Text);
                var newEndDate = rent.EndDate.AddDays(days);
                var newPrice = (rent.TotalPrice / (rent.EndDate - rent.StartDate).TotalDays) * (newEndDate - rent.StartDate).TotalDays;
                if (DateTime.Now > rent.EndDate)
                {
                    MessageBox.Show("Can not extend reservation that is completed.", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    var request = new Model.Requests.Rent.RentInsert()
                    {
                        DateCreated = rent.DateCreated,
                        EndDate = rent.EndDate.AddDays(days),
                        IsPayed = rent.IsPayed,
                        StartDate = rent.StartDate,
                        UserId = rent.UserId,
                        VehicleId = rent.VehicleId,
                        TotalPrice= newPrice
                    };
                    var updatedRent = await _serviceRent.Update<Rent>(rent.Id, request);
                    if (updatedRent != null)
                    {
                        MessageBox.Show($"Rent number {rent.Id} succesfully extended", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                    else
                    {
                        MessageBox.Show($"Rent number {rent.Id} could not be extended", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                }
            }
        }
    }
}
