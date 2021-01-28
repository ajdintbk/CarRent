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
    public partial class frmUserDetails : Form
    {
        protected APIService _userService = new APIService("User");
        protected APIService _rentService = new APIService("Rent");
        protected APIService _cityService = new APIService("City");
        protected APIService _roleService = new APIService("Role");
        private int id;

        public frmUserDetails()
        {
            InitializeComponent();
        }

        public frmUserDetails(int result) : this()
        {
            id = result;
        }
        private async void frmUserDetails_Load(object sender, EventArgs e)
        {
            var userreq = new Model.Requests.User.UserSearchRequest(){UserId = id};
            var user = await _userService.Get<List<Model.User>>(userreq);
            var rentreq = new Model.Requests.Rent.RentSearchRequest(){UserId = id};
            var rents = await _rentService.Get<List<Model.Rent>>(rentreq);
            var dgvList = new List<Model.ViewModel.UserDetailsVM>();

            foreach (var rent in rents)
            {
                var dgvItem = new Model.ViewModel.UserDetailsVM()
                {
                    VehicleName = rent.Vehicle.Name.ToString(),
                    fromDate = rent.StartDate.ToString(),
                    ToDate = rent.EndDate.ToString(),
                    DateCreated = rent.DateCreated.ToString(),
                    Status = (rent.IsPayed == true ? "Payed" : "Not payed")
                };
                dgvList.Add(dgvItem);
            }

            txtFirstName.Text = user[0].FirstName.ToString();
            txtLastName.Text = user[0].LastName.ToString();
            txtUsername.Text = user[0].Username.ToString();
            txtEmail.Text = user[0].Email.ToString();
            txtPhone.Text = user[0].Phone.ToString();
            await GetCity();
            await GetRole();

            cbCity.SelectedIndex = user[0].CityId;
            cbRole.SelectedIndex = user[0].RoleId;
            chActive.Checked = user[0].Active;

            dgvRents.DataSource = dgvList;
        }
        private async Task GetCity()
        {
            var list = await _cityService.Get<List<Model.City>>();
            list.Insert(0, new Model.City()
            {
                Name = " "
            });

            cbCity.ValueMember = "Id";
            cbCity.DisplayMember = "Name";

            cbCity.DataSource = list;
        }
        private async Task GetRole()
        {
            var list = await _roleService.Get<List<Model.Role>>();
            list.Insert(0, new Model.Role()
            {
                Name = " "
            });

            cbRole.ValueMember = "Id";
            cbRole.DisplayMember = "Name";

            cbRole.DataSource = list;
        }
        Model.Requests.AddUserRequest request = new Model.Requests.AddUserRequest();
        private bool Validate(Control obj)
        {
            if (obj is ComboBox && int.Parse((obj as ComboBox).SelectedValue.ToString()) == 0)
            {
                err.SetError(obj, "This field is required!");
                obj.Focus();
                return false;
            }
            else if (obj is TextBox && string.IsNullOrWhiteSpace((obj as TextBox).Text))
            {
                err.SetError(obj, "This field is required!");
                obj.Focus();
                return false;
            }
            err.Clear();
            return true;
        }
        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (Validate(txtEmail) && Validate(txtFirstName) && Validate(txtLastName) && Validate(txtPhone) && Validate(cbCity) && Validate(cbRole))
            {
                request.CityId = int.Parse(cbCity.SelectedValue.ToString());
                request.RoleId = int.Parse(cbRole.SelectedValue.ToString());
                request.Username = txtUsername.Text;
                request.Email = txtEmail.Text;
                request.FirstName = txtFirstName.Text;
                request.LastName = txtLastName.Text;
                request.Phone = txtPhone.Text;
                request.Active = chActive.Checked;

                if (id != 0)
                {
                    await _userService.Update<Model.User>(id, request);
                    MessageBox.Show($"User {txtUsername.Text} successfully updated!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var msg = MessageBox.Show("Are you sure?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (msg == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}
