using CarRent.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CarRent.MobileApp.ViewModels
{
    public class NewMessageVIewModel : BaseViewModel
    {
        private readonly APIService _service = new APIService("Message");
        public NewMessageVIewModel()
        {
            SubmitCommand = new Command(async () => await SaveMessage());
        }

        private async Task SaveMessage()
        {
            if (Question.Length == 0)
            {
                await Application.Current.MainPage.DisplayAlert("Status", "Question is required", "OK");
                return;
            }
            var request = new Model.Requests.Message.MessageInsert()
            {
                DateCreated = DateTime.Now,
                UserId = APIService.UserId,
                IsOpened = true,
                Question = Question,
            };
            try
            {
                var response = await _service.Insert<Model.Message>(request);
                await Application.Current.MainPage.DisplayAlert("Status", "Message submited.", "OK");
                Question = string.Empty;
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Status", "Message error.", "Try again");
                throw;
            }
        }
        string _question = string.Empty;
        public string Question
        {
            get { return _question; }
            set { SetProperty(ref _question, value); }
        }
        public ICommand SubmitCommand { get; set; }

    }
}
