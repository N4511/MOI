using System;
using System.Collections.Generic;
using System.Text;

namespace MemoriesAdmin.Models
{
    public class Reservation
    {
        public int id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string no_of_guest { get; set; }
        public string reservation_date { get; set; }
        public string reservation_time { get; set; }
        public string contact_number { get; set; }
        public string printed_status { get; set; }
        public string review_notification { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
    }
}
