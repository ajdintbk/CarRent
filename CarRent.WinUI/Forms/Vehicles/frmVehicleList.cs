using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flurl.Http;
using CarRent.Model;
using CarRent.Model.ViewModel;

namespace CarRent.WinUI.Forms.Vehicles
{
    public partial class frmVehicleList : Form
    {
        private readonly APIService _apiService = new APIService("Vehicle");
        protected APIService _serviceBrand = new APIService("Brand");
        public frmVehicleList()
        {
            InitializeComponent();
        }

        public async Task GetData()
        {
            
            dgvVehicleList.DataSource = null;
            List<Model.Vehicle> list;
            if (dgvVehicleList.Columns.Contains("btnDetails"))
            {
                dgvVehicleList.Columns.Remove("btnDetails");
            }
            int cmb = 0;
            if (cbBrand.SelectedValue != null)
            {
                cmb = int.Parse(cbBrand.SelectedValue.ToString());
            }

            if (!string.IsNullOrWhiteSpace(txtName.Text) || cmb > 0 || checkBox1.Checked || !checkBox1.Checked)
            {
                Model.Requests.Vehicle.VehicleSearchRequest searchString = new Model.Requests.Vehicle.VehicleSearchRequest()
                {
                    Name = txtName?.Text,
                    BrandId = cmb
                };

                if(checkBox1.CheckState == CheckState.Checked || checkBox1.CheckState == CheckState.Unchecked)
                    searchString.IsActive = checkBox1.Checked;
                list = await _apiService.Get<List<Model.Vehicle>>(searchString);
            }
            else
            {
                list = await _apiService.Get<List<Model.Vehicle>>();

            }


            List<VehicleListVM> listvm = new List<VehicleListVM>();
            foreach (var item in list)
            {
                VehicleListVM vmitem = new VehicleListVM()
                {
                    Id = item.Id,
                    Brand = item.Brand.Name,
                    Name = item.Name,
                    Price = item.Price.ToString() + "KM",
                    VehicleModel = item.VehicleModel.Name,
                    NumberOfSeats = item.NumberOfSeats,
                    Description = item.Description,
                    YearManufactured = item.YearManufactured,
                    Fuel = item.Fuel.Name,
                    Transmission = item.Transmission,
                    IsActive = bool.Parse(item.IsActive.ToString())
                };

                listvm.Add(vmitem);

            }
            lblNoOfCars.Text = "Number of cars: " + listvm.Count();
            dgvVehicleList.DataSource = listvm;
            dgvVehicleList.Columns[0].Visible = false;

            DataGridViewButtonColumn bcol = new DataGridViewButtonColumn();
            bcol.HeaderText = "Action";
            bcol.Text = "Details";
            bcol.Name = "btnDetails";

            bcol.UseColumnTextForButtonValue = true;
            if (!dgvVehicleList.Columns.Contains("btnDetails"))
                dgvVehicleList.Columns.Add(bcol);

            if(dgvVehicleList.RowCount == 0)
                MessageBox.Show("No vehicles with that search query.", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private async void frmVehicleList_Load(object sender, EventArgs e)
        {
            if (APIService.loggedUser.RoleId == 2)
            {
                btnAddVehicle.Visible = false;
            }
            await GetBrand();

        }


        //add vehicle button
        private void button1_Click(object sender, EventArgs e)
        {
            frmAddVehicle frmAddVehicle = new frmAddVehicle();
            frmAddVehicle.FormClosed += async delegate {
                await GetData();
            };
            frmAddVehicle.ShowDialog();

        }
        private async Task GetBrand()
        {
            var list = await _serviceBrand.Get<List<Model.Brand>>();
            list.Insert(0, new Model.Brand()
            {
                Name = " "
            });

            cbBrand.ValueMember = "Id";
            cbBrand.DisplayMember = "Name";

            cbBrand.DataSource = list;
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await GetBrand();
        }

        private void dgvVehicleList_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {

            if (e.ColumnIndex == 11)
            {
                int result = int.Parse(dgvVehicleList.Rows[e.RowIndex].Cells[0].Value.ToString());
                if (result != 0)
                {
                    frmAddVehicle frmAdd = new frmAddVehicle(result);
                        frmAdd.FormClosed += async delegate {
                            await GetBrand();
                        };
                        frmAdd.ShowDialog();
                }
            }
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            await GetData();
        }

        private async void txtName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                await GetData();
            }
        }

        private async void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            await GetData();
        }

        private async void cbBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            await GetData();
        }
    }
}
