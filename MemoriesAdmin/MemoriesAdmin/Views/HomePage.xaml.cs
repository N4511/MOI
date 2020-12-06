using MemoriesAdmin.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MemoriesAdmin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : TabbedPage
    {
        public HomePage()
        {

          
          
            if (Settings.AccessToken != "")
            {
                this.Children.Add(new AdminProfilePage() { Title = "Profile" });
                this.Children.Add(new Page1() { Title = "Page" });
                this.Children.Add(new ProductsPage() { Title = "Products" });
                this.Children.Add(new AdminOrdersPage() { Title = "Orders" });
                this.Children.Add(new ReservationPage() { Title = "Reservations" });
               

            }
            else
            {
                this.Children.Add(new CustomerRegisterPage() { Title = "Register" });
                this.Children.Add(new LoginPage() { Title = "Login" });
            }

              
           
               
            InitializeComponent();
            //remove back button from navigation bar
            NavigationPage.SetHasBackButton(this, false);
        }

       
    }
}