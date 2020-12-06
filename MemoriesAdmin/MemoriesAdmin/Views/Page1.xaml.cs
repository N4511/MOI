using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace MemoriesAdmin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
            btnPrint.Clicked += async(object sender, EventArgs e) =>
            {
                // Variables
                string ipAddress = "192.168.1.200";
                int portNumber = 9100;
      


                string orderId = "69562222";
                List<string> myText = new List<string>() { "Memories of India", "6 Ashley House", "SL2 3QL", "01753 644166"};
               
               
                // Try to find the platform specific services
                var printer = DependencyService.Get<IPrinter>();
                if (printer == null)
                {
                    // Do not proceed if no services found for the platform
                    await DisplayAlert("Error", "No implementation provided for this platform", "OK");
                    return;
                }

                try
                {
                    printer.PrintDevider(ipAddress, portNumber, orderId);
                    printer.PrintQRCODE(ipAddress, portNumber, orderId);
                    
                    printer.PrintDevider(ipAddress, portNumber, "===================");
                    //printer.PrintDevider(ipAddress, portNumber, "...................");
                    // Call the method, declare by the IPrinter interface
                    printer.Print(ipAddress, portNumber, myText);
                }
                catch (Exception ex)
                {
                    // Exception here could mean difficulties in connecting to the printer etc
                    await DisplayAlert("Error", $"Failed to print redemption slip\nReason: {ex.Message}", "OK");
                }
            };
            var current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
            {
                // Connection to internet is available
                networkState.Text = "Connection to internet is available.";
            }else
            {
                networkState.Text = "No Internet Connection.";
            }
        }
    }
}