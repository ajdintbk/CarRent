using CarRent.WinUI.Forms.Rents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRent.WinUI.Forms.Favorites
{
    public partial class frmFavoriteList : Form
    {
        protected APIService _favVehicle = new APIService("Favorites");
        protected APIService _serviceVehicle = new APIService("Vehicle");

        public frmFavoriteList()
        {
            InitializeComponent();
        }

        private async void frmFavoriteList_Load(object sender, EventArgs e)
        {
            var favReq = new Model.Requests.Favorites.FavoritesSearchRequest()
            {
                UserId = APIService.loggedUser.Id
            };
            var favoritesList = await _favVehicle.Get<List<Model.Favorites>>(favReq);
            if(favoritesList.Count == 0)
            {
                lblNo.Visible = true;
                dgvFavorites.Visible = false;
            }
            if(favoritesList.Count > 0)
            {
                var vehiclesList = new List<Model.ViewModel.VehicleListVM>();

                foreach (var item in favoritesList)
                {
                    var car = await _serviceVehicle.GetById<Model.Vehicle>(item.VehicleId);
                    var temp = new Model.ViewModel.VehicleListVM()
                    {
                        Brand = car.Brand.Name,
                        Description = car.Description,
                        Fuel = car.Fuel.Name,
                        Id = car.Id,
                        IsActive = car.IsActive.Value,
                        Name = car.Name,
                        NumberOfSeats = car.NumberOfSeats,
                        Price = car.Price.ToString(),
                        Transmission = car.Transmission,
                        VehicleModel = car.VehicleModel.Name,
                        YearManufactured = car.YearManufactured
                    };
                    vehiclesList.Add(temp);
                }
                
                dgvFavorites.DataSource = vehiclesList;
                dgvFavorites.Columns[8].Visible = false;
                dgvFavorites.Columns[0].Visible = false;
                DataGridViewButtonColumn bcol = new DataGridViewButtonColumn();
                bcol.HeaderText = "Action";
                bcol.Text = "Rent";
                bcol.Name = "btnRent";
                bcol.UseColumnTextForButtonValue = true;

                if (!dgvFavorites.Columns.Contains("btnRent"))
                    dgvFavorites.Columns.Add(bcol);
            }
        }

        private void dgvFavorites_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                if (e.ColumnIndex == 11)
                {
                    var result = dgvFavorites.Rows[e.RowIndex].DataBoundItem as Model.ViewModel.VehicleListVM;
                    if (result != null)
                    {
                        frmRentCar frm = new frmRentCar(result.Id, double.Parse(result.Price));
                        frm.ShowDialog();
                    }
                }
            }
        }
    }
}
