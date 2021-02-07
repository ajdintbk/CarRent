using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CarRent.MobileApp.ViewModels
{
    public class MessageDetailsViewModel : BaseViewModel
    {
        private readonly APIService _service = new APIService("Message");
        public ICommand SaveMessage { get; set; }

        public MessageDetailsViewModel()
        {
            SaveMessage = new Command(async () => await Save());

        }

        public async Task Save()
        {
            if(_message.Response.Length < 5)
            {
                await Application.Current.MainPage.DisplayAlert("Status", "Response too short.", "Try again");
            }
            else
            {
                var request = new Model.Requests.Message.MessageInsert()
                {
                    DateCreated = _message.DateCreated,
                    DateResponded = DateTime.Now,
                    IsOpened = false,
                    Question = _message.Question,
                    Response = _message.Response,
                    UserId = _message.UserId
                };
                var respo = await _service.Update<Model.Message>(_message.Id, request);
                if(respo != null)
                {
                    await Application.Current.MainPage.DisplayAlert("Status", "Reponse successfully added.", "OK");
                    Answered = true;
                    Response = _message.Response;
                }
                else
                    await Application.Current.MainPage.DisplayAlert("Status", "Something went wrong.", "OK");
            }

        }

        public Model.Message _message { get; set; }
        string _response = string.Empty;
        public string Response
        {
            get { return _response; }
            set { SetProperty(ref _response, value); }
        }
        bool _adminStatus = false;
        public bool AdminStatus
        {
            get { return _adminStatus; }
            set { SetProperty(ref _adminStatus, value); }
        }
        bool _answered = false;
        public bool Answered
        {
            get { return _answered; }
            set { SetProperty(ref _answered, value); }
        }
    }
}
