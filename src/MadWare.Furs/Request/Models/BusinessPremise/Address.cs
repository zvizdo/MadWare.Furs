using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MadWare.Furs.Request.Models.BusinessPremise
{
    public class Address
    {
        /// <summary>
        /// Ulica / Street
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// Hišna številka / House number
        /// </summary>
        public string HouseNumber { get; set; }

        /// <summary>
        /// Dodatek k hišni številki / Addition to the house number
        /// </summary>
        public string HouseNumberAdditional { get; set; }

        /// <summary>
        /// Naselje / Town
        /// </summary>
        public string Community { get; set; }

        /// <summary>
        /// Pošta / Post office
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Poštna številka / Postcode
        /// </summary>
        public string PostalCode { get; set; }

        public bool ShouldSerializeHouseNumberAdditional()
        {
            return !string.IsNullOrEmpty(this.HouseNumberAdditional);
        }
    }
}
