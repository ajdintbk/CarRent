using CarRent.MobileApp.ViewModels;
using CarRent.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarRent.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VehicleListPage : ContentPage
    {
        VehicleListViewModel model = null;
        public VehicleListPage()
        {
            InitializeComponent();
            BindingContext = model = new VehicleListViewModel();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Vehicle;
            //await Navigation.PopToRootAsync();
            await Navigation.PushAsync(new VehicleDetailsPage(item));
        }
    }
}