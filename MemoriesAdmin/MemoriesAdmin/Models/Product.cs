using System;
using System.Collections.Generic;
using System.Text;

namespace MemoriesAdmin.Models
{
    public class Product
    {
        public int id { get; set; }
        public string imageUrl { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public int category_id { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
    }
}
