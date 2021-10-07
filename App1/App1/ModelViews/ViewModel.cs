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
            selectUser = null;
            IsBusy = false;
            //GetTokenCommand = new Command(GetToken);
            //GetUserCommand = new Command(GetUser);
        }

        public payload Token
        {
            get { return token; }
            set
            {
                if (token != value)
                {
                    payload tok = new payload()
                    {
                        id_user = value.id_user,
                        token = value.token,
                        timeleft = value.timeleft
                        //phone = value.phone
                    };
                    token = null;
                    OnPropertyChanged("token");

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
                        email = value.email
                        //phone = value.phone
                    };
                    selectUser = null;
                    OnPropertyChanged("selectUser");
                    
                }
            }
        }
        public async void GetUser()
        {
            SelectUser = await server.GetUser("Bearer="+Token.token);
        }
        public async void GetToken(string login, string password)
        {
            Token = await server.GetToken(login, password);
            //await Navigation.PushAsync(new Result(this));
            
        }
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        
    }
}
