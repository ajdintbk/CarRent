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
    public partial class MessageDetailsPage : ContentPage
    {
        private MessageDetailsViewModel model = null;

        public MessageDetailsPage()
        {
            InitializeComponent();
        }
        public MessageDetailsPage(Message item) :this()
        {
            BindingContext = model = new MessageDetailsViewModel()
            {
                _message = item,
                Answered = (item.Response == null ? false : true),
                AdminStatus = (APIService.Role == "Administrator" ? true : false),
                Response = (item.Response != null ? item.Response : "No response yet.")
            };
        }
        
    }
}