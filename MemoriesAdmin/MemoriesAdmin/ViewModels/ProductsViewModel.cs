using MemoriesAdmin.Models;
using MemoriesAdmin.Services;
using System;
using System.Linq;
using System.Net.Http;
using System.Windows.Input;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MemoriesAdmin.Helpers;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MvvmHelpers;
using Newtonsoft.Json;

namespace MemoriesAdmin.ViewModels
{
   public class ProductsViewModel : BaseViewModel
    {
        private readonly ApiServices _apiServices = new ApiServices();
        private List<Product> _products;

        //public string AccessToken { get; set; }
        public List<Product> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                OnPropertyChanged();
            }
        }
        public ICommand GetProductsCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsBusy = true;
                    var accessToken = Settings.AccessToken;
                    Products = await _apiServices.GetProductsAsync(accessToken);
                    IsBusy = false;
                });
            }
        }

       

       
    }
}
