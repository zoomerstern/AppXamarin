﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App1.Views;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();


        }
        private async void NextButton_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Registration());
        }
    }
}
