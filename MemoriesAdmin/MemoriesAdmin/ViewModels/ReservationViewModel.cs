using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Net.Http.Headers;
using System.Net.Http;
using MemoriesAdmin.Models;
using MvvmHelpers;
using Xamarin.Forms;
using System.Windows.Input;
using MemoriesAdmin.Helpers;
using System.Threading.Tasks;
using System.Diagnostics;
using Newtonsoft.Json;

namespace MemoriesAdmin.ViewModels
{
   public class ReservationViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Reservation> Reservations { get; set; }
        public ReservationViewModel()
        {
            Reservations = new ObservableRangeCollection<Reservation>();
        }
        public async Task LoadReservationsAsync()
        {
            try
            {
                var accessToken = Settings.AccessToken;
                IsBusy = true;
                var reservations = await App._apiservice.GetReservationAsync(accessToken);
                Reservations.ReplaceRange(reservations);
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
