using System;
using System.Collections.Generic;
using System.Text;

namespace MemoriesAdmin.Models
{
   
    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
    }
}
