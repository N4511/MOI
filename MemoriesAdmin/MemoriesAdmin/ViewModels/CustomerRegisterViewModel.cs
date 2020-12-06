using MemoriesAdmin.Services;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MemoriesAdmin.ViewModels
{
    public class CustomerRegisterViewModel : BaseViewModel
    {
        CustomerApiServices customerApiServies = new CustomerApiServices();
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmedPassword { get; set; }
        public string Address { get; set; }
        public string Area { get; set; }
        public string Postcode { get; set; }
        public string ContactNumber { get; set; }

        public string Message { get; set; }

        public ICommand RegisterCustomerCommand
        {
            get
            {
                return new Command( async() =>
                {
                    IsBusy = true;
                    var isSuccess = await customerApiServies.RegisterCustomerAsync(Name, Email, Password, ConfirmedPassword, Address, Area, Postcode, ContactNumber);
                    IsBusy = false;
                    if (isSuccess)
                        Message = "Registered Successfully";
                    else
                    {
                        Message = "Error! Could not Register User.";
                    }

                });
            }

        }
    }
}
