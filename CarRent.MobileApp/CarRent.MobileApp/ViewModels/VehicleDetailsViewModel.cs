using CarRent.Model;
using CarRent.Model.Requests.Recommend;
using Flurl.Http;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CarRent.MobileApp.ViewModels
{
    public class VehicleDetailsViewModel : BaseViewModel
    {
        private readonly APIService _service = new APIService("Rent");
        private readonly APIService _serviceRating = new APIService("Review");
        private readonly APIService _serviceRecommend = new APIService("Recommend");
        private readonly APIService _serviceCheck = new APIService("Rent/checkavailability");
        public VehicleDetailsViewModel()
        {
            RentCommand = new Command(async () => await RentVehicle());
            refreshCommand = new Command( () =>  Refresh());
            RecommendComand = new Command(async () => await Recommendation());
        }

        private string _rating = string.Empty;
        public string AverageRating
        {
            get { return _rating; }
            set { SetProperty(ref _rating, value); }
        }
        private bool _recommendBusy = false;
        public bool RecommendBusy
        {
            get { return _recommendBusy; }
            set { SetProperty(ref _recommendBusy, value); }
        }
        public ObservableCollection<Model.Vehicle> RecommendedVehicleList { get; set; } = new ObservableCollection<Model.Vehicle>();

        public async Task Recommendation()
        {
            if(RecommendedVehicleList == null || RecommendedVehicleList.Count == 0)
            {
                RecommendBusy = true;
                var allRatings = await _serviceRating.Get<List<Model.Review>>(null);
                var request = new RecommendSearchRequest
                {
                    VehicleId = Vehicle.Id
                };

                List<Model.Vehicle> recList = await _serviceRecommend.Get<List<Model.Vehicle>>(request);
                RecommendedVehicleList.Clear();

                foreach (var item in recList)
                {
                    RecommendedVehicleList.Add(item);
                }
                RecommendBusy = false;

                float avgRating = 0;
                int i = 0;
                foreach (var item in allRatings)
                {
                    if (Vehicle.Id == item.VehicleId)
                    {
                        avgRating += item.NumberOfStars;
                        i++;
                    }
                }
                if (avgRating == 0)
                {
                    AverageRating = "The car has no ratings yet";
                    return;
                }
                AverageRating = (avgRating / i).ToString();
            }

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
        public ICommand RecommendComand { get; set; }
    }
}
