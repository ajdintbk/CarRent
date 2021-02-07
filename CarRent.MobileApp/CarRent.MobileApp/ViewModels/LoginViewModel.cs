using CarRent.MobileApp.Views;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
namespace CarRent.MobileApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly APIService _service = new APIService("User");
        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await Login());
        }
        string _username = string.Empty;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        string _password = string.Empty;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        public ICommand LoginCommand { get; set; }
        

        async Task Login()
        {
            IsBusy = true;
            APIService.username = Username;
            APIService.password = Password;

            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "All fields are required", "Try again");
                return;
            }

            try
            {
                List<Model.User> list = await _service.Get<List<Model.User>>(new Model.Requests.User.UserLoginRequest
                {
                    Username = Username,
                    Password = Password
                });

                if (list.Count == 0)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Wrong username or password", "Try again");
                    return;
                }

                foreach (var item in list)
                {

                    var request = new Model.Requests.User.UserLoginRequest
                    {
                        Username = Username,
                        Password = Password
                    };
                    var url = $"http://localhost:55208/api/User/Login";
                    var response = await url.PostJsonAsync(request);

                    if (item.Username == Username)
                    {
                        APIService.UserId = item.Id;
                        APIService.Role = item.Role.Name;
                    }
                }
                //await _service.Get<dynamic>(null);
                Application.Current.MainPage = new MainPage();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Wrong username or password", "Try again");
            }
            IsBusy = false;
        }
    }
}
