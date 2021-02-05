using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CarRent.MobileApp.Services;
using CarRent.MobileApp.Views;

namespace CarRent.MobileApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
