using CarRent.WinUI.Forms.Rents;
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

namespace CarRent.WinUI.Forms.User
{
    public partial class frmUserDetails : Form
    {
        protected APIService _userService = new APIService("User");
        protected APIService _rentService = new APIService("Rent");
        protected APIService _cityService = new APIService("City");
        protected APIService _roleService = new APIService("Role");
        private int id = 0;

        public frmUserDetails()
        {
            InitializeComponent();
        }

        public frmUserDetails(int result) : this()
        {
            id = result;
        }
        private async void GetData(List<Model.Rent> rentList = null)
        {
            if(id == 0)
            {
                await GetCity();
                await GetRole();
                txtUsername.ReadOnly = false;
                chActive.Checked = true;
            }
            else
            {
                txtPassword.Visible = false;
                txtPwConfirm.Visible = false;
                if (APIService.loggedUser.RoleId == 2)
                {
                    cbRole.Enabled = false;
                    chActive.Enabled = false;
                }
                if (dgvRents.Columns.Contains("btnReview"))
                {
                    dgvRents.Columns.Remove("btnReview");
                }

                if (dgvRents.Columns.Contains("btnCancel"))
                {
                    dgvRents.Columns.Remove("btnCancel");
                }
                var userreq = new Model.Requests.User.UserSearchRequest() { UserId = id };
                var user = await _userService.Get<List<Model.User>>(userreq);
                var rentreq = new Model.Requests.Rent.RentSearchRequest() { UserId = id };
                List<Model.Rent> rents;
                if (rentList != null)
                    rents = rentList;
                else
                    rents = await _rentService.Get<List<Model.Rent>>(rentreq);
                var dgvList = new List<Model.ViewModel.UserDetailsVM>();


                foreach (var rent in rents)
                {
                    var dgvItem = new Model.ViewModel.UserDetailsVM()
                    {
                        RentId = rent.Id,
                        VehicleName = rent.Vehicle.Name.ToString(),
                        fromDate = rent.StartDate.ToString(),
                        ToDate = rent.EndDate.ToString(),
                        DateCreated = rent.DateCreated.ToString(),
                        Status = (rent.IsReviewed == true ? "Reviewed" : "Not reviewed")
                    };
                    if (rent.IsCanceled)
                    {
                        dgvItem.Status = "Canceled";
                    }
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
                dgvRents.Columns[0].Visible = false;

                DataGridViewButtonColumn bcol = new DataGridViewButtonColumn();
                bcol.HeaderText = "Action";
                bcol.Text = "Review";
                bcol.Name = "btnReview";
                bcol.UseColumnTextForButtonValue = true;

                DataGridViewButtonColumn bcol2 = new DataGridViewButtonColumn();
                bcol2.HeaderText = "Action";
                bcol2.Text = "Cancel";
                bcol2.Name = "btnCancel";
                bcol2.UseColumnTextForButtonValue = true;

                if (!dgvRents.Columns.Contains("btnReview") && id == APIService.loggedUser.Id)
                    dgvRents.Columns.Add(bcol);
                if (!dgvRents.Columns.Contains("btnCancel") && id == APIService.loggedUser.Id)
                    dgvRents.Columns.Add(bcol2);
            }

        }
        private void frmUserDetails_Load(object sender, EventArgs e)
        {
            GetData();
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
        private bool ValidatePassword(string pw, string pwConf)
        {
            if(pw == null || pwConf == null)
            {
                err.SetError(txtPassword, "Required");
                err.SetError(txtPwConfirm, "Required");
                return false;
            }
            else
            {
                err.Clear();
            }
            if(pw != null && pwConf != null && pw != pwConf)
            {
                err.SetError(txtPassword, "Pasword does not match");
                err.SetError(txtPwConfirm, "Pasword does not match");
                return false;
            }
            else
            {
                err.Clear();
            }

            if(pw.Length < 8)
            {
                err.SetError(txtPassword, "Passowd must be at least 8 characters long.");
                return false;
            }
            else
            {
                err.Clear();
            }
            return true;
        }
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
            if (Validate(txtEmail) && Validate(txtFirstName) && Validate(txtLastName) && Validate(txtPhone) && Validate(cbCity) && Validate(cbRole) && ValidatePassword(txtPassword.Text,txtPwConfirm.Text))
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
                else
                {
                    request.Password = txtPassword.Text;
                    request.PasswordConfirmation = txtPwConfirm.Text;
                    await _userService.Insert<Model.User>(request);
                    MessageBox.Show($"User {txtUsername.Text} successfully added!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private async void dgvRents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                if (e.ColumnIndex == 6)
                {
                    var row = dgvRents.Rows[e.RowIndex].DataBoundItem as Model.ViewModel.UserDetailsVM;
                    if(row.Status == "Canceled" || row.Status == "Reviewed")
                    {
                        MessageBox.Show("Selected rent can not be reviewed.", "Message", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                    else
                    {
                        int result = int.Parse(dgvRents.Rows[e.RowIndex].Cells[0].Value.ToString());
                        if (result != 0)
                        {
                            frmAddReview frmReview = new frmAddReview(result);
                            frmReview.FormClosed += delegate
                            {
                                GetData();
                            };
                            frmReview.ShowDialog();
                        }
                    }
                }
                if(e.ColumnIndex == 7)
                {
                    int rentId = int.Parse(dgvRents.Rows[e.RowIndex].Cells["RentId"].Value.ToString());
                    var date = DateTime.Parse(dgvRents.Rows[e.RowIndex].Cells["fromDate"].Value.ToString());
                    var status = dgvRents.Rows[e.RowIndex].Cells["Status"].Value.ToString();
                    if (status == "Canceled")
                    {
                        MessageBox.Show("Reservation already canceled.", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if((date.Date - DateTime.Now.Date).Days < 3)
                    {
                        MessageBox.Show("Reservation must be at least 72h ahead to be canceled.", "Status", MessageBoxButtons.OK,MessageBoxIcon.Error);
                        return;
                    }
                    if (rentId != 0)
                    {
                        var s = await $"{Properties.Settings.Default.APIurl}/Rent/cancelreservation/{rentId}".WithBasicAuth(APIService.username, APIService.password).PatchJsonAsync(rentId).ReceiveJson<Model.Rent>();
                    }
                }
            }
        }

        private async void chbFutureRents_CheckedChanged(object sender, EventArgs e)
        {
            if (!chbFutureRents.Checked)
            {
                GetData();
            }
            else
            {

                var list = await $"{Properties.Settings.Default.APIurl}/Rent/futurerents/{id}".WithBasicAuth(APIService.username, APIService.password).GetJsonAsync<List<Model.Rent>>();
                GetData(list);
            }
        }
    }
}
