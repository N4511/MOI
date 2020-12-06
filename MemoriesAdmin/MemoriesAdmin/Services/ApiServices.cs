using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using MemoriesAdmin.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Collections.ObjectModel;

namespace MemoriesAdmin.Services
{
    public class ApiServices
    {
        string provider { get; set; }

        public async Task<string> LoginAsync(string userName, string password, string userType)
        {
            
            if(userType == "Admin")
            {
                provider = "admins";
            }else if(userType == "Customer")
            {
                provider = "users";
            }
          
            var keyValues = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username", userName),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("provider", provider),
                new KeyValuePair<string, string>("grant_type", "password")
            };


            var request = new HttpRequestMessage(
                HttpMethod.Post, Constants.BaseApiAddress + "api/login");

           
            request.Content = new FormUrlEncodedContent(keyValues);

            HttpClient client = new HttpClient();
            try
            {
                var response = await client.SendAsync(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {

                    var content = await response.Content.ReadAsStringAsync();

                    JObject jwtDynamic = JsonConvert.DeserializeObject<dynamic>(content);

                    var accessToken = jwtDynamic.Value<string>("access_token");

                    return accessToken;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

            return null;

        }

        public async Task<List<Product>> GetProductsAsync(string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Bearer", accessToken);

            var json = await client.GetStringAsync(Constants.BaseApiAddress + "api/products");

          
            var products = JsonConvert.DeserializeObject<List<Product>>(json);

            return products;
        }
        public async Task<ObservableCollection<Reservation>> GetReservationAsync(string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Bearer", accessToken);

            var json = await client.GetStringAsync(Constants.BaseApiAddress + "api/reservations");


            var reservations = JsonConvert.DeserializeObject<ObservableCollection<Reservation>>(json);

            return reservations;
        }

        public async Task UpdateOrderStatus(Order order, string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
           
            var json = JsonConvert.SerializeObject(order);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PutAsync(
                Constants.BaseApiAddress + "api/orders/" + order.id, content);
        }
    }
}