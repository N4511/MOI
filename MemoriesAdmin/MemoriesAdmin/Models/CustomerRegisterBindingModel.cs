using System;
using System.Collections.Generic;
using System.Text;

namespace MemoriesAdmin.Models
{
    public class CustomerRegisterBindingModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmedPassword { get; set; }
        public string Address { get; set; }
        public string Area { get; set; }
        public string Postcode { get; set; }
        public string ContactNumber { get; set; }
    }
}
