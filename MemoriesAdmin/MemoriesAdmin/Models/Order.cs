using System;
using System.Collections.Generic;
using System.Text;

namespace MemoriesAdmin.Models
{
    
    public class Order
    {
        public int id { get; set; }
        public string customer_name { get; set; }
        public string address { get; set; }
        public string area { get; set; }
        public string postcode { get; set; }
        public double price { get; set; }
        public string order_type { get; set; }
        public string order_status { get; set; }
        public string contact_number { get; set; }
        public string order_time { get; set; }
        public List<string> items { get; set; }
    }
}
