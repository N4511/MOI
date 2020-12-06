using MemoriesAdmin.Helpers;
using MemoriesAdmin.Models;
using MemoriesAdmin.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MemoriesAdmin.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AdminOrdersPage : ContentPage
	{
        OrdersViewModel vm;
		public AdminOrdersPage ()
		{
			InitializeComponent ();
           
            this.BindingContext = vm = new OrdersViewModel();
           
            ButtonGet.Clicked += async (sender, e) =>
            {
                await vm.LoadOrdersAsync();
            };

		}
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await vm.LoadOrdersAsync();
        }
        private async void IdeasListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        
            var order= e.Item as Order;
            await Navigation.PushAsync(new OrderDetailsPage(order));
            //await DisplayAlert("Product: " + product.id, product.customer_name.ToString(), "cancel");
        }

        protected async void PrintButtonClicked(object sender, EventArgs e)
        {
           
       
            var id = int.Parse((sender as Button).CommandParameter.ToString());
            
            await DisplayAlert("Product", id.ToString(), "cancel");
            // Variables
            string ipAddress = "192.168.1.200";
            int portNumber = 9100;



            string orderId = (sender as Button).CommandParameter.ToString();
            List<string> myText = new List<string>() { "01753 644166" };


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

                Order order = vm.Orders.FirstOrDefault(item => item.id == id);
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