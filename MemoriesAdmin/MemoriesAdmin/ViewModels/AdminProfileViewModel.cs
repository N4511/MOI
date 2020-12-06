using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MemoriesAdmin.Helpers;
using MemoriesAdmin.Views;
using MvvmHelpers;
using Xamarin.Forms;

namespace MemoriesAdmin.ViewModels
{
    public class AdminProfileViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }
        public AdminProfileViewModel(INavigation navigation)
        {
            Navigation = navigation;
           

        }

        public async Task GotoLoginPage()
        {
          
            await Navigation.PushAsync(new LoginPage());
        }
        public ICommand LogoutCommand
        {
            get
            {
                return new Command(async () =>
                {
                    
                    Settings.AccessToken = string.Empty;
                    Debug.WriteLine(Settings.Username);
                    Settings.Username = string.Empty;
                    Debug.WriteLine(Settings.Password);
                    Settings.Password = string.Empty;

                    // navigate to LoginPage
                    await GotoLoginPage();
                    
                });
            }
        }

        
    }
}
