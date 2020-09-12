using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WorldOfHalalWebUI.Models
{
    public class Restaurant
    {
        public int RestaurantId { get; set; }

        [DisplayName("Restaurant Name")]
        public string RestaurantName { get; set; }

        [DisplayName("Location")]
        public string RestaurantLocation { get; set; }

        [DisplayName("Certificate")]
        public string ImagePath { get; set; }
    }
}