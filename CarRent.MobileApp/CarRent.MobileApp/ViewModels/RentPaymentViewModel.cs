using Acr.UserDialogs;
using CarRent.Model;
using Stripe;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CarRent.MobileApp.ViewModels
{
    public class RentPaymentViewModel : BaseViewModel
    {
        private readonly APIService _service = new APIService("Rent");
        public RentPaymentViewModel()
        {
            PayRent = new Command(async () => await PayAndRent());
        }
        public ICommand PayRent { get; set; }

        double _totalPrice;
        public double TotalPrice
        {
            get { return _totalPrice; }
            set { SetProperty(ref _totalPrice, value); }
        }

        Vehicle _vehicle;
        public Vehicle Vehicle
        {
            get { return _vehicle; }
            set { SetProperty(ref _vehicle, value); }
        }
        DateTime _startDate;
        public DateTime StartDate
        {
            get { return _startDate; }
            set { SetProperty(ref _startDate, value); }
        }
        DateTime _endDate;
        public DateTime EndDate
        {
            get { return _endDate; }
            set { SetProperty(ref _endDate, value); }
        }
        int _numberOfDays;
        public int NumberOfDays
        {
            get { return _numberOfDays; }
            set { SetProperty(ref _numberOfDays, value); }
        }

        //stripepaymentstart
        public Token stripeToken;
        public TokenService TokenService;
        public string TestApiKey = "pk_test_51IHCoQHSzA0XyAaonBY6KdBNeoCnQ079Sv4iDbOOGAIvVY4HOulbGQDuxPY9Ni7AXa4hLFnFZomU4jxPWMYmwXGy005TCQ5Yzu";
        bool IsTransactionSuccess = false;
        
        public async Task Payment()
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;
            try
            {
                UserDialogs.Instance.ShowLoading("Payment proccessing...");
                await Task.Run(async () =>
                {
                    var Token = CreateToken();
                    if (Token != null)
                    {
                        IsTransactionSuccess = MakePayment();
                        if (IsTransactionSuccess)
                        {
                            UserDialogs.Instance.HideLoading();
                            CheckoutService.IsPayed = true;
                        }
                    }
                    else
                    {
                        UserDialogs.Instance.Alert("Bad card creditials", null, "OK");
                    }

                });
            }
            catch (Exception)
            {
                throw;
            }
            
        }
        public bool MakePayment()
        {
            try
            {
                StripeConfiguration.ApiKey = "sk_test_51IHCoQHSzA0XyAaoGnz0qEFamGOURxkr3SQVOaeH85n6VV7BXHTyLlgxx10nC71qkq2zlEStAfW3u7hw0XxUrkjC002YA4vbY5";
                var options = new ChargeCreateOptions
                {
                    Amount = (long)TotalPrice * 100,
                    Currency = "bam",
                    Description = $"Payment for {Vehicle.Name} from {APIService.username}",
                    StatementDescriptor = ":CAR_RENT_RS2:",
                    Capture = true,
                    ReceiptEmail = "tabakajdin@gmail.com",
                    Source = stripeToken.Id,
                };
                var service = new ChargeService();
                Charge charge = service.Create(options);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string CreateToken()
        {
            try
            {
                StripeConfiguration.ApiKey = TestApiKey;
                var service = new ChargeService();
                var tokenOption = new TokenCreateOptions
                {
                    Card = new CreditCardOptions
                    {
                        Number = "4242424242424242",
                        ExpYear = 22,
                        ExpMonth = 12,
                        Cvc = "889",
                        Name = APIService.username.ToString(),
                        AddressLine1 = "Skolska",
                        AddressCity = "Mostar",
                        AddressCountry = "BiH",
                        Currency = "BAM"
                    }
                };
                TokenService = new TokenService();
                stripeToken = TokenService.Create(tokenOption);
                return stripeToken.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }
        //stripepaymentend

        private async Task PayAndRent()
        {
            var days = (CheckoutService._endDate.Date - CheckoutService._stardDate.Date).Days;
            Model.Requests.Rent.RentInsert insertRequest = new Model.Requests.Rent.RentInsert()
            {
                DateCreated = DateTime.Now,
                EndDate = CheckoutService._endDate,
                IsReviewed = false,
                StartDate = CheckoutService._stardDate,
                TotalPrice = Math.Round((CheckoutService._vehicle.Price * days), 2),
                UserId = APIService.UserId,
                VehicleId = CheckoutService._vehicle.Id
            };

            try
            {
                var result = await _service.Insert<Model.Rent>(insertRequest);
                if (result != null)
                {
                    await Payment();
                    UserDialogs.Instance.Alert("Successfully rented", null, "OK");
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.Alert("Rent failed.", null, "OK");
            }
        }

    }
}
