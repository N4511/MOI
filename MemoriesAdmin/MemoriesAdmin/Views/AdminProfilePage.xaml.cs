using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemoriesAdmin.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MemoriesAdmin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminProfilePage : ContentPage
    {
        public AdminProfilePage()
        {
            InitializeComponent();
            this.BindingContext = new AdminProfileViewModel(Navigation);
        }
    }
}