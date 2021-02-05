using CarRent.Model;
using Flurl.Http;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CarRent.MobileApp.ViewModels
{
    public class VehicleDetailsViewModel : BaseViewModel
    {
        private readonly APIService _service = new APIService("Rent");
        private readonly APIService _serviceCheck = new APIService("Rent/checkavailability");
        public VehicleDetailsViewModel()
        {
            RentCommand = new Command(async () => await RentVehicle());
            refreshCommand = new Command( () =>  Refresh());
        }

        private void Refresh()
        {
            if (!CheckoutService.IsPayed)
            {
                StartDate = DateTime.Now;
                EndDate = DateTime.Now;
                RentAvailable = false;
                RentButton = true;
                RentStatus = "";
            }
        }

        private async Task RentVehicle()
        {
            if (EndDate.Date < StartDate.Date)
            {
                await Application.Current.MainPage.DisplayAlert("Status", "End date can not be lower then start date.", "Try again");
                return;
            }
            if(EndDate.Date == StartDate.Date)
            {
                await Application.Current.MainPage.DisplayAlert("Status", "End date can not be same as start date.", "Try again");
                return;
            }
            var request = new Model.Requests.Rent.RentSearchRequest()
            {
                VehicleId = Vehicle.Id,
                EndDate = EndDate.Date,
                StartDate = StartDate.Date
            };
            var rent = await _serviceCheck.CheckAvailibility<List<Rent>>(request);
            if(rent == null || rent.Count == 0)
            {
                RentStatus = "Available. Proceed to checkout.";
                RentAvailable = true;
                RentButton = false;
                CheckoutService._vehicle = Vehicle;
                CheckoutService._stardDate = StartDate;
                CheckoutService._endDate = EndDate;
            }
            else
            {
                DateTime next = rent[0].EndDate;
                for (int i = 0; i < rent.Count - 1; ++i)
                {
                    if (next < rent[i + 1].EndDate)
                        next = rent[i + 1].EndDate;
                }
                RentStatus = "Available after " + next.Date.ToString().Substring(0, 9);
            }
        }

        public Vehicle Vehicle { get; set; }
        bool _rentButton = true;
        public bool RentButton
        {
            get { return _rentButton; }
            set { SetProperty(ref _rentButton, value); }
        }
        bool _rentAvailable = false;
        public bool RentAvailable
        {
            get { return _rentAvailable; }
            set { SetProperty(ref _rentAvailable, value); }
        }
        string _rentStatus = string.Empty;
        public string RentStatus
        {
            get { return _rentStatus; }
            set { SetProperty(ref _rentStatus, value); }
        }
        DateTime _startDate = DateTime.Now;
        public DateTime StartDate
        {
            get { return _startDate; }
            set { SetProperty(ref _startDate, value); }
        }
        DateTime _endDate = DateTime.Now;
        public DateTime EndDate
        {
            get { return _endDate; }
            set { SetProperty(ref _endDate, value); }
        }
        public ICommand RentCommand { get; set; }
        public ICommand refreshCommand { get; set; }
    }
}
