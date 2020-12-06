using MemoriesAdmin.Models;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows.Input;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;
using MemoriesAdmin.Helpers;
using System.Net.Http.Headers;
using System.Diagnostics;

namespace MemoriesAdmin.ViewModels
{
    public class OrdersViewModel : BaseViewModel
    {
         
        public ObservableRangeCollection<Order> Orders { get; }
        public ObservableRangeCollection<Grouping<string, Order>> OrdersGrouped { get; set; }

        public OrdersViewModel()
        {
            Orders = new ObservableRangeCollection<Order>();
            OrdersGrouped = new ObservableRangeCollection<Grouping<string, Order>>();

        }

        
        public async Task LoadOrdersAsync()
        {
            try
            {
                var accessToken = Settings.AccessToken;
                IsBusy = true;
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
              "Bearer", accessToken);

                var json = await client.GetStringAsync("http://localhost:8001/api/orders");
                var items = JsonConvert.DeserializeObject<List<Order>>(json);

                Orders.ReplaceRange(items);

                var groups = from item in Orders
                             orderby item.id descending
                             //group item by item.title[0].ToString()
                             group item by item.order_status.ToString()
                             into orderGroup
                             select new Grouping<string, Order>(orderGroup.Key, orderGroup);
                OrdersGrouped.ReplaceRange(groups);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }
        public async Task UpdateOrdersStatus(Order order)
        {
            try
            {
                var accessToken = Settings.AccessToken;
                IsBusy = true;

                await App._apiservice.UpdateOrderStatus(order,accessToken);

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }

}
