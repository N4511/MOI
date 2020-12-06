using MemoriesAdmin.Models;
using MemoriesAdmin.ViewModels;
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
	public partial class ProductsPage : ContentPage
	{
		public ProductsPage ()
		{
			InitializeComponent ();
            this.BindingContext = new ProductsViewModel();
		}

        private async void IdeasListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var product = e.Item as Product;
            //await Navigation.PushAsync(new LoginPage());
            await DisplayAlert("Product", product.category_id.ToString() , "cancel");

        }
    }
}