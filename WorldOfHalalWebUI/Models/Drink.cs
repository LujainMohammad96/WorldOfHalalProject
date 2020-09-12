using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WorldOfHalalWebUI.Models
{
    public class Drink
    {
        public int DrinkId { get; set; }

        [DisplayName("Drink Name")]
        public string DrinkName { get; set; }

        [DisplayName("Company Name")]
        public string DrinkCompany { get; set; }

        [DisplayName("Certificate")]
        public string CertificateDrinkUrl { get; set; }
    }
}