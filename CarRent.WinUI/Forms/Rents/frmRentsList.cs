﻿using System;
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
    public partial class frmRentsList : Form
    {
        protected APIService _serviceRent = new APIService("Rent");
        public frmRentsList()
        {
            InitializeComponent();
        }
        private async Task GetData(List<Model.Rent> searchList = null)
        {
            if (dgvRents.Columns.Contains("btnView"))
                dgvRents.Columns.Remove("btnView");

            if (dgvRents.Columns.Contains("btnExtend"))
                dgvRents.Columns.Remove("btnExtend");
            List<Model.Rent> list;
            if (searchList == null)
                list = await _serviceRent.Get<List<Model.Rent>>();
            else
                list = searchList;
            var DataGridList = new List<Model.ViewModel.RentListItemVM>();
            foreach (var rent in list)
            {
                var dataItem = new Model.ViewModel.RentListItemVM()
                {
                    RentId = rent.Id,
                    FromDate = rent.StartDate.ToString("dd/MM/yyyy"),
                    ToDate = rent.EndDate.ToString("dd/MM/yyyy"),
                    Username = rent.User.FirstName + " " + rent.User.LastName,
                    VehicleName = rent.Vehicle.Name + " " + rent.Vehicle.VehicleModel.Name,
                    TotalPrice = rent.TotalPrice.ToString() + " KM"
                };
                DataGridList.Add(dataItem);
            }
            dgvRents.DataSource = DataGridList;
            dgvRents.Columns[0].Visible = false;
            

            DataGridViewButtonColumn viewRent = new DataGridViewButtonColumn();
            viewRent.HeaderText = "Action";
            viewRent.Text = "View";
            viewRent.Name = "btnView";
            viewRent.UseColumnTextForButtonValue = true;

            DataGridViewButtonColumn extendRent = new DataGridViewButtonColumn();
            extendRent.HeaderText = "Action";
            extendRent.Text = "Extend rent";
            extendRent.Name = "btnExtend";
            extendRent.UseColumnTextForButtonValue = true;

            if (!dgvRents.Columns.Contains("btnView"))
                dgvRents.Columns.Add(viewRent);

            if(!dgvRents.Columns.Contains("btnExtend"))
                dgvRents.Columns.Add(extendRent);

            dgvRents.Columns[1].HeaderText = "User";
            dgvRents.Columns[2].HeaderText = "Vehicle name";
            dgvRents.Columns[3].HeaderText = "Start date";
            dgvRents.Columns[4].HeaderText = "End date";
            dgvRents.Columns[5].HeaderText = "Total price";
            dgvRents.Columns[6].HeaderText = "Action";


        }
        private async void frmRentsList_LoadAsync(object sender, EventArgs e)
        {
            await GetData();

        }

        private async void dgvRents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if(e.ColumnIndex == 7)
                {
                    int rentId = int.Parse(dgvRents.Rows[e.RowIndex].Cells[0].Value.ToString());
                    var rent = await _serviceRent.GetById<Model.Rent>(rentId);
                    if (rent != null)
                    {
                        frmExtendRent frmExtend = new frmExtendRent(rent);
                        frmExtend.FormClosed += async delegate { await GetData(); };
                        frmExtend.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Error");
                    }
                }

                if (e.ColumnIndex == 6)
                {
                    int rent = int.Parse(dgvRents.Rows[e.RowIndex].Cells[0].Value.ToString());
                    frmRentDetails frmDetails = new frmRentDetails(rent);
                    frmDetails.ShowDialog();
                }
            }
        }

        private async void txtBtnSearch_Click(object sender, EventArgs e)
        {
            var search = new Model.Requests.Rent.RentSearchRequest();
            if (dtpEnd.Value.Date < dtpStart.Value.Date)
            {
                errorProvider1.SetError(dtpEnd, "End date can not be smaller then start date");
            }
            else
            {
                errorProvider1.Clear();
            }

            if (dtpStart.Value.Date < dtpEnd.Value.Date)
            {
                search.StartDate = dtpStart.Value.Date;
                search.EndDate = dtpEnd.Value.Date;
            }
            if (!string.IsNullOrWhiteSpace(txtName.Text))
                search.UserName = txtName.Text;
            if (!string.IsNullOrWhiteSpace(txtVehicleName.Text))
                search.VehicleName = txtVehicleName.Text;

            var list = await _serviceRent.Get<List<Model.Rent>>(search);
            if(list == null || list.Count == 0)
                MessageBox.Show("No result for that search query.","Status", MessageBoxButtons.OK,MessageBoxIcon.Information);
            await GetData(list);
        }
    }
}
