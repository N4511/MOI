using MemoriesAdmin.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace MemoriesAdmin.Services
{
    public class CustomerApiServices
    {
        public async Task<bool> RegisterCustomerAsync(string name, string email, string password, string confirmedPassword, string address, string area, string postcode, string contactNumber)
        {
            var client = new HttpClient();

            var model = new CustomerRegisterBindingModel
            {
                Name = name, 
                Email = email,
                Password = password,
                ConfirmedPassword = confirmedPassword, 
                Address = address, 
                Area = area, 
                Postcode = postcode, 
                ContactNumber = contactNumber
            };

            var json = JsonConvert.SerializeObject(model);

            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync("", content);
            return response.IsSuccessStatusCode;
        }
    }
}
 