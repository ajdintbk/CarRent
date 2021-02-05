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
    public partial class RentPaymentPage : ContentPage
    {
        private RentPaymentViewModel model = null;
        public RentPaymentPage()
        {
            InitializeComponent();
            BindingContext = model = new RentPaymentViewModel()
            {
                Vehicle = CheckoutService._vehicle,
                EndDate = CheckoutService._endDate,
                StartDate = CheckoutService._stardDate,
                TotalPrice = Math.Round((CheckoutService._vehicle.Price * (CheckoutService._endDate.Date - CheckoutService._stardDate.Date).Days), 2),
                NumberOfDays = (CheckoutService._endDate.Date - CheckoutService._stardDate.Date).Days
            };
        }
        
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}