using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WorldOfHalalWebUI.Models
{
    public class Hotel
    {
        public int HotelId { get; set; }

        [DisplayName("Hotel Name")]
        public string HotelName { get; set; }
        [DisplayName("Hotel Location")]
        public string HotelLocation { get; set; }
    }
}