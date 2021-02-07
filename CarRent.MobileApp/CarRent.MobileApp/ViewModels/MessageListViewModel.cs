using CarRent.Model.Requests.Message;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CarRent.MobileApp.ViewModels
{
    public class MessageListViewModel : BaseViewModel
    {
        private readonly APIService _serviceMessages = new APIService("Message");

        public MessageListViewModel()
        {
            InitCommand = new Command(async () => await Init());
            MarkAsReadCommand = new Command(async () => await MarkAsRead(new Model.Message()));
            ReadFilterCommand = new Command(async () => await ReadFilterCheck());
        }

        public async Task ReadFilterCheck()
        {
            if (!ReadFilter)
                ReadFilter = true;
            else
                ReadFilter = false;
        }

        public async Task MarkAsRead(Model.Message msg)
        {
            var req = new MessageInsert()
            {
                DateCreated = msg.DateCreated,
                DateResponded = msg.DateResponded,
                IsOpened = true,
                Question = msg.Question,
                Response = msg.Response,
                UserId = msg.UserId
            };
            await _serviceMessages.Update<Model.Message>(msg.Id, req);
        }

        private int _undreadCount = 0;
        public int UnreadCount
        {
            get { return _undreadCount; }
            set { SetProperty(ref _undreadCount, value); }
        }
        private bool _readFilter = false;
        public bool ReadFilter
        {
            get { return _readFilter; }
            set { SetProperty(ref _readFilter, value); }
        }
        public async Task Init()
        {
            IsBusy = true;
            IEnumerable<Model.Message> list;
            if(APIService.Role == "Administrator")
            {
                list = await _serviceMessages.Get<IEnumerable<Model.Message>>(null);
            }
            else
            {
                var request = new MessageSearchRequest()
                {
                    UserId = APIService.UserId
                };
                list = await _serviceMessages.Get<IEnumerable<Model.Message>>(request);
            }
            MessageList.Clear();
            UnreadList.Clear();
            foreach (var message in list)
            {
                if(APIService.Role == "Administrator")
                {
                    if (message.Response == null)
                    {
                        UnreadCount++;
                        UnreadList.Add(message);
                    }
                }
                else
                {
                    if (!message.IsOpened)
                    {
                        UnreadCount++;
                        UnreadList.Add(message);
                    }
                }
                MessageList.Add(message);
            };
            IsBusy = false;
        }

        public ObservableCollection<Model.Message> MessageList { get; set; } = new ObservableCollection<Model.Message>();
        public ObservableCollection<Model.Message> UnreadList { get; set; } = new ObservableCollection<Model.Message>();
        public ICommand InitCommand { get; set; }
        public ICommand MarkAsReadCommand { get; set; }
        public ICommand ReadFilterCommand { get; set; }


    }
}
