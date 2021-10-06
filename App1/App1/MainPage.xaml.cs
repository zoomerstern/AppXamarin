using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App1.Views;
using Xamarin.Essentials;

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
        private async void NextButton_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Registration());
        }
        private async void ResultButton_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Result());
        }
    }
}
