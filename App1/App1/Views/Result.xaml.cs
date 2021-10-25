using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1.ModelViews;
using App1.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Result : ContentPage
    {
        ViewModel model;
        public Result(ViewModel model)//, payload token)
        {
            InitializeComponent();
            
            this.model = model;
            //this.model.token = token;
            BindingContext = model;
            //model.GetUser();
            //Name.Text = model.SelectUser.name;
            //Mail.Text = model.SelectUser.email;
            //await model.GetUserCommand();
            //Name.Text=
        }
    }
}