using System.Windows.Input;
using MemoriesAdmin.Helpers;
using MemoriesAdmin.Services;
using MemoriesAdmin.Views;
using Xamarin.Forms;
using MvvmHelpers;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace MemoriesAdmin.ViewModels

{
    public class LoginViewModel : BaseViewModel
    {
        private readonly ApiServices _apiServices = new ApiServices();
        public INavigation Navigation { get; set; }
        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<UserType> UserTypeList { get; set; }

       
   
        private UserType _selectedUserType { get; set; }
        public UserType SelectedUserType
        {
            get { return _selectedUserType; }
            set
            {
                if (_selectedUserType != value)
                {
                    _selectedUserType = value;
                  
                }
            }

        }

        public LoginViewModel(INavigation navigation)
        {
            Navigation = navigation;
            Username = Settings.Username;
            Password = Settings.Password;
            Message = "Not Logged in.";
            Title = "Login Page";
            IsNotBusy = true;

            UserTypeList = GetUserTypes().OrderBy(t => t.Value).ToList();
         
            _selectedUserType = new UserType() { Key = 3, Value = "" };

        }

        public async Task GotoHomePage()
        {
            await Navigation.PushAsync(new HomePage());
        }
       



        public ICommand LoginCommand
        {
            get
            {
                return new Command(async () =>
                {
                    if(_selectedUserType.Value == "")
                    {
                        Message = "Could not log you in. Please select your user type!";
                        IsBusy = false;
                        IsNotBusy = true;
                        return;
                    }
                    IsBusy = true;
                    IsNotBusy = false;
                    var accesstoken = await _apiServices.LoginAsync(Username, Password, _selectedUserType.Value);

                    if (accesstoken != null)
                    {
                        Settings.AccessToken = accesstoken;
                        Settings.Username = Username;
                        Settings.Password = Password;
                        //Message = Settings.AccessToken;
                        Message = "Logged in.";
                        IsBusy = false;

                        await GotoHomePage();

                    }
                    else
                    {
                        Message = "Could not log you in. Please try again later!";
                        IsBusy = false;
                        IsNotBusy = true;
                    }

                });
            }
        }







        public List<UserType> GetUserTypes()
        {
            var userTypes = new List<UserType>()
            {
                new UserType(){Key =  1, Value= "Customer"},
                new UserType(){Key =  2, Value="Admin"},
            
            };

            return userTypes;
        }
    }


    public class UserType
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }

}

