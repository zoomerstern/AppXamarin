using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App1.Views;
using Xamarin.Essentials;
using App1.ModelViews;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        
        public MainPage()
        {
            InitializeComponent();

            var current = Connectivity.NetworkAccess;

            if (current != NetworkAccess.Internet)
            {
                DisplayAlert("Уведомление", "Подключите интернет", "ОK");
            }

        }

        private async void ResultButton_Click(object sender, EventArgs e)
        {
            string mail = Mail.Text;
            string pass = Password.Text;
            ViewModel model = new ViewModel();
            model.GetToken(mail, pass);
            //string token = server.GetToken(mail, pass);
            await Navigation.PushAsync(new Result(model));
        }
    }
}
