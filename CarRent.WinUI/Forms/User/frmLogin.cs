using CarRent.WinUI.Forms.Vehicles;
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
    public partial class frmLogin : Form
    {
        protected APIService _service = new APIService("User");

        public frmLogin()
        {
            InitializeComponent();
        }

        private async void Login() {
            try
            {
                button1.Enabled = false;
                APIService.username = txtUsername.Text;
                APIService.password = txtPassword.Text;

                if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
                {
                    MessageBox.Show("All fields are required! Try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    button1.Enabled = true;
                    return;
                }

                else
                {
                    var request = new Model.Requests.User.UserLoginRequest
                    {
                        Username = txtUsername.Text,
                        Password = txtPassword.Text
                    };
                    var url = $"{Properties.Settings.Default.APIurl}/User/Login";
                    var response = await url.PostJsonAsync(request);
                    var findUser = new Model.Requests.User.UserSearchRequest()
                    {
                        Username = txtUsername.Text
                    };
                    var user = await _service.Get<List<Model.User>>(findUser);
                    if (user != null)
                    {
                        APIService.loggedUser = user[0];
                    }

                    MessageBox.Show($"Welcome {user[0].Username}", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    frmHome home = new frmHome();
                    home.Closed += (s, args) => this.Close();
                    home.Show();
                }
            }
            catch (Exception)
            {
                button1.Enabled = true;
                MessageBox.Show("Wrong username or password", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void button1_ClickAsync(object sender, EventArgs e)
        {
            Login();
        }

        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Login();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Login();
        }
    }
}
