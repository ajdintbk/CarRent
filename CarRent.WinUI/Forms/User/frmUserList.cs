using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRent.WinUI.Forms.User
{
    public partial class frmUserList : Form
    {
        private readonly APIService _userService = new APIService("User");
        private readonly APIService _rentService = new APIService("Rent");
        
        public frmUserList()
        {
            InitializeComponent();
        }
        private async Task GetData(List<Model.User> users = null)
        {
            

            List<Model.User> list;

            if (dgvUserList.Columns.Contains("btnDetails"))
                dgvUserList.Columns.Remove("btnDetails");

            if (users == null)
                list = await _userService.Get<List<Model.User>>();
            else
                list = users;

            var gridList = new List<Model.ViewModel.UserListVM>();
            int activeNumber = 0;
            foreach (var item in list)
            {
                var request = new Model.Requests.Rent.RentSearchRequest()
                {
                    UserId = item.Id,
                    UserRentCount = true
                };

                if (item.Active)
                {
                    activeNumber++;
                }
                var number = await _rentService.Get<List<Model.Rent>>(request);

                var gridItem = new Model.ViewModel.UserListVM()
                {
                    Name = item.FirstName.ToString() + " " + item.LastName.ToString(),
                    Contact = item.Email,
                    NumberOfRents = number.Count,
                    Role = item.Role.Name.ToString(),
                    Status = (item.Active == true ? "Active" : "Disabled"),
                    UserId = item.Id
                };
                
                    gridList.Add(gridItem);

            }
            DataGridViewButtonColumn bcol = new DataGridViewButtonColumn();
            bcol.HeaderText = "Action";
            bcol.Text = "Details";
            bcol.Name = "btnDetails";

            dgvUserList.DataSource = gridList;
            dgvUserList.Columns[0].Visible = false;

            bcol.UseColumnTextForButtonValue = true;
            if (!dgvUserList.Columns.Contains("btnDetails"))
                dgvUserList.Columns.Add(bcol);

            lblActive.Text = "Active users: " + activeNumber.ToString();
            lblNumberOfRows.Text = "Number of rows: " + list.Count.ToString();


        }
        private async void frmUserList_Load(object sender, EventArgs e)
        {
            await GetData();
        }

        private void dgvUserList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                
            if(e.ColumnIndex == 6)
            {
                int result = int.Parse(dgvUserList.Rows[e.RowIndex].Cells[0].Value.ToString());
                if (result != 0)
                {
                    frmUserDetails frmAdd = new frmUserDetails(result);
                    frmAdd.FormClosed += async delegate {
                        if (!string.IsNullOrWhiteSpace(txtSearchName.Text))
                            SearchQuery(txtSearchName.Text);
                        else
                            await GetData();
                    };
                    frmAdd.ShowDialog();
                }
            }
            }
        }

        private async Task SearchQuery(string searchName)
        {
            if (!string.IsNullOrWhiteSpace(txtSearchName.Text))
            {
                var request = new Model.Requests.User.UserSearchRequest()
                {
                    FirstName = txtSearchName.Text,
                };
                await GetData(await _userService.Get<List<Model.User>>(request));
            }
        }
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            await SearchQuery(txtSearchName.Text);
        }

        private async void txtSearchName_TextChanged(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtSearchName.Text))
                await GetData();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmUserDetails frmUd = new frmUserDetails();
            frmUd.ShowDialog();
        }
    }
}
