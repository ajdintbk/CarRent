using Acr.UserDialogs;
using CarRent.MobileApp.ViewModels;
using CarRent.Model;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarRent.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VehicleDetailsPage : ContentPage
    {
        private VehicleDetailsViewModel model = null;
        public VehicleDetailsPage(Vehicle vehicle)
        {
            InitializeComponent();
            BindingContext = model = new VehicleDetailsViewModel()
            {
                Vehicle = vehicle
            };
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Recommendation();
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RentPaymentPage());
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Vehicle;
            await Navigation.PushAsync(new VehicleDetailsPage(item));
        }
    }
}