using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemoriesAdmin.Helpers;
using MemoriesAdmin.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MemoriesAdmin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderDetailsPage : ContentPage
    {
        Order order;
        public OrderDetailsPage(Order order)
        {
            InitializeComponent();

            this.BindingContext = order;
            this.order = order;
        }

        protected async void Print_Order(object sender, EventArgs e)
        {
            //await DisplayAlert("Printing Order: " + order.id.ToString(), "Please Wait", "OK");
            // Variables
            string ipAddress = "192.168.1.200";
            int portNumber = 9100;



           
            List<string> shopDetails = new List<string>() {
                "Memories of India",
                "6 Ashley House",
                "SL2 3QL",
                "01753 644166"
            };

            List<string> orderDetails = new List<string>();
            List<string> customerDetails = new List<string>();
            //add order Details from the individual order list
             
            foreach (var item  in order.items)
            {
                orderDetails.Add(item.ToString());
            }
            customerDetails.Add(order.customer_name.ToString());
            customerDetails.Add(order.address.ToString());
            customerDetails.Add(order.area.ToString());
            customerDetails.Add(order.postcode.ToString());
            customerDetails.Add(order.contact_number.ToString());
            customerDetails.Add($"Total: {order.price.ToString()} GBP");

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
                printer.PrintDevider(ipAddress, portNumber, order.id.ToString());
                //printer.PrintQRCODE(ipAddress, portNumber, order.id.ToString());
                //printer.PrintDevider(ipAddress, portNumber, "===================");
                
                //printer.PrintDevider(ipAddress, portNumber, "...................");
                // Call the method, declare by the IPrinter interface
                printer.Print(ipAddress, portNumber, orderDetails);
                printer.PrintDevider(ipAddress, portNumber, "===================");
                printer.Print(ipAddress, portNumber, customerDetails);
                //printer.PrintDevider(ipAddress, portNumber, $"Total: {order.price.ToString()}GBP");
                order.order_status = "Checked";
                await App._apiservice.UpdateOrderStatus(order, Settings.AccessToken);
            }
            catch (Exception ex)
            {
                // Exception here could mean difficulties in connecting to the printer etc
                await DisplayAlert("Error", $"Failed to print redemption slip\nReason: {ex.Message}", "OK");
            }
        }
       
    }
}