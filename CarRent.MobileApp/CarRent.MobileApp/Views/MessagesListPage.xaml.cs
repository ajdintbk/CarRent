using CarRent.MobileApp.ViewModels;
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
    public partial class MessagesListPage : ContentPage
    {
        MessageListViewModel model = null;
        public MessagesListPage()
        {
            InitializeComponent();
            BindingContext = model = new MessageListViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            model.UnreadCount = 0;
            await model.Init();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewMessagePage());
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Model.Message;
            await model.MarkAsRead(item);
            await Navigation.PushAsync(new MessageDetailsPage(item));
        }

        private async void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            await model.ReadFilterCheck();
        }
    }
}