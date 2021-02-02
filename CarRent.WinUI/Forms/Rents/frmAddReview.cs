using Flurl.Http;
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
    public partial class frmAddReview : Form
    {
        protected APIService _rentService= new APIService("Rent");
        protected APIService _reviewService= new APIService("Review");
        Model.Rent rent;

        int numberOfStars = 0;
        int rentId;
        public frmAddReview()
        {
            InitializeComponent();
        }
        public frmAddReview(int rentId) :this()
        {
            this.rentId = rentId;
        }

        private async void frmAddReview_Load(object sender, EventArgs e)
        {
            rent = await _rentService.GetById<Model.Rent>(rentId);
            var req = new Model.Requests.Review.ReviewSearchRequest()
            {
                VehicleId = rent.VehicleId
            };
            var review = await _reviewService.Get<List<Model.Review>>(req);
            double rating = 0;
            if (review.Count > 0)
            {
                rating = review.Average(x => x.NumberOfStars);
            }

            lblVehicle.Text += " " +rent.Vehicle.Name;
            lblRating.Text = Math.Round(rating,1).ToString() + " average score";
            lblCount.Text = review.Count.ToString() + " review(s)";
        }
        private bool ValidateRating()
        {
            if (richTextBox1.Text.Length < 10)
            {
                errorProvider1.SetError(richTextBox1, "Comment must be at least 10 characters long.");
                return false;
            }
                errorProvider1.Clear();
            if (!rb1.Checked && !rb2.Checked && !rb3.Checked && !rb4.Checked && !rb5.Checked)
            {
                errorProvider1.SetError(rb5, "Rate from 1 to 5");
                return false;
            }
            
                errorProvider1.Clear();
                return true;
            
        }
        private async void btnAddReview_Click(object sender, EventArgs e)
        {
            if (ValidateRating())
            {
                var req = new Model.Requests.Review.ReviewInsert()
                {
                    Comment = richTextBox1.Text,
                    DatePosted = DateTime.Now,
                    NumberOfStars = numberOfStars,
                    UserId = APIService.loggedUser.Id,
                    VehicleId = rent.VehicleId
                };
                try
                {
                    var response = await _reviewService.Insert<Model.Review>(req);
                    var reqRent = new Model.Requests.Rent.RentInsert()
                    {
                         DateCreated = rent.DateCreated,
                         EndDate = rent.EndDate,
                         IsCanceled = rent.IsCanceled,
                         StartDate = rent.StartDate,
                         TotalPrice = rent.TotalPrice,
                         UserId = rent.UserId,
                         VehicleId  = rent.VehicleId,
                        IsReviewed = true
                    };
                    var rentupdate = await _rentService.Update<Model.Rent>(rent.Id, reqRent);
                    if (response != null)
                    {
                        MessageBox.Show("Review is submitted!");
                        this.Close();
                    }
                }
                catch (Exception exc)
                {

                    MessageBox.Show(exc.Message, "Status",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                
            }
        }

        private void rb1_CheckedChanged(object sender, EventArgs e)
        {
            numberOfStars = 1;
        }

        private void rb2_CheckedChanged(object sender, EventArgs e)
        {
            numberOfStars = 2;
        }

        private void rb3_CheckedChanged(object sender, EventArgs e)
        {
            numberOfStars = 3;

        }

        private void rb4_CheckedChanged(object sender, EventArgs e)
        {
            numberOfStars = 4;

        }

        private void rb5_CheckedChanged(object sender, EventArgs e)
        {
            numberOfStars = 5;

        }
    }
}
