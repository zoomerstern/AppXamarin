using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registration2 : ContentPage
    {
        public Registration2()
        {
            InitializeComponent();
        }
        private async void NextButton_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}