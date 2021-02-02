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

        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            try
            {
                APIService.username = txtUsername.Text;
                APIService.password = txtPassword.Text;

                if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
                {
                    MessageBox.Show("All fields are required! Try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    if(user != null)
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
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Wrong username or password", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
