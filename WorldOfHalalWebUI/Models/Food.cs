using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WorldOfHalalWebUI.Models
{
    public class Food
    {
        public int FoodId { get; set; }

        [DisplayName("Food Name")]
        public string FoodName { get; set; }

        [DisplayName("Company Name")]
        public string FoodCompany { get; set; }

        [DisplayName("Certificate")]
        public string CertificateFoodUrl { get; set; }
    }
}