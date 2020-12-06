using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using MemoriesAdmin.Models;
using MemoriesAdmin.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MemoriesAdmin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReservationPage : ContentPage
    {
        public ObservableCollection<Reservation> reservations { get; set; }
        ReservationViewModel vm;
        public ReservationPage()
        {
            InitializeComponent();

            BindingContext  =vm =  new ReservationViewModel();
            ButtonGet.Clicked += async (sender, e) =>
            {
                await vm.LoadReservationsAsync();
            };
        }

      

    }
}
