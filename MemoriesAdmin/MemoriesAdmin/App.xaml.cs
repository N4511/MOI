using MemoriesAdmin.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MemoriesAdmin.Services;
[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MemoriesAdmin
{
    public partial class App : Application
    {
        public static ApiServices _apiservice { get; private set; }
    
        public App()
        {
            InitializeComponent();
            _apiservice = new ApiServices();
            MainPage = new NavigationPage(new HomePage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
