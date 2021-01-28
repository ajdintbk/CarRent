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
        private async Task GetData()
        {
            if (dgvUserList.Columns.Contains("btnDetails"))
                dgvUserList.Columns.Remove("btnDetails");

            var list = await _userService.Get<List<Model.User>>();
            var gridList = new List<Model.ViewModel.UserListVM>();

            foreach (var item in list)
            {
                var request = new Model.Requests.Rent.RentSearchRequest()
                {
                    UserId = item.Id,
                    UserRentCount = true
                };
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
                        await GetData();
                    };
                    frmAdd.ShowDialog();
                }
            }
            }
        }
    }
}
