using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using App1.Model;
using Xamarin.Forms;
using App1.Views;

namespace App1.ModelViews
{
    public class ViewModel : INotifyPropertyChanged
    {
        public string login= "youremail@mail.ru";
        public string password= "8877cgh443F";


        bool initialized = false;   // была ли начальная инициализация
        User selectUser;  // Пользователь
        private bool isBusy;    // идет ли загрузка с сервера
        public payload token;
        ServerConnect server = new ServerConnect();
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand GetTokenCommand { protected set; get; }
        public ICommand GetUserCommand { protected set; get; }

        public INavigation Navigation { get; set; }

        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged("IsBusy");
                OnPropertyChanged("IsLoaded");
            }
        }
        public bool IsLoaded
        {
            get { return !isBusy; }
        }

        public ViewModel()
        {
 
            IsBusy = false;
            GetTokenCommand = new Command(GetToken);
            GetUserCommand = new Command(GetUser);
        }

        public payload Token
        {
            get { return token; }
            set
            {
                if (token != value)
                {
                    payload result = new payload()
                    {
                        id_user = value.id_user,
                        token = value.token,
                        timeleft = value.timeleft
                        //phone = value.phone
                    };
                    token = result;
                    OnPropertyChanged("token");
                    Navigation.PushAsync(new Result(this));
                }
            }
        }
        public User SelectUser
        {
            get { return selectUser; }
            set
            {
                if (selectUser != value)
                {
                    User tempFriend = new User()
                    {
                        id = value.id,
                        name = value.name,
                        surname = value.surname,
                        middle_name = value.middle_name,
                        adress=value.adress,
                        brith_day=value.brith_day,
                        email = value.email,
                        gender = value.gender
                        //phone = value.phone
                    };
                    //selectUser = null;
                    OnPropertyChanged("selectUser");
                }
            }
        }
        public async void GetUser()
        {
            SelectUser = await server.GetUser("Bearer="+Token.token);
        }
        public async void GetToken()
        {
            if (login.Length == 0 || password.Length == 0)
                return;
            var result = await server.GetToken(login, password);
            Token = result.payload;

            //Token = await server.GetToken(login, password);
            //await Navigation.PushAsync(new Result(this));

        }
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        
    }
}
