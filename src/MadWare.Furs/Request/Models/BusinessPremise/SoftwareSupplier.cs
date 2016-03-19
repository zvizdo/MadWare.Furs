using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MadWare.Furs.Request.Models.BusinessPremise
{
    public class SoftwareSupplier
    {
        /// <summary>
        /// Vpiše se davčna številka pravne ali fizične osebe – proizvajalca ali vzdrževalca programske opreme s sedežem v Sloveniji. / The tax number is entered of a legal entity or an individual – producer or software maintenance provider established in Slovenia.
        /// </summary>
        public string TaxNumber { get; set; }

        /// <summary>
        /// Vpiše se naziv in naslov proizvajalca ali vzdrževalca programske opreme, ki nima sedeža v Sloveniji. / The title and address is entered of the producer or software maintenance provider not established in Slovenia.
        /// </summary>
        public string NameForeign { get; set; }

        public bool ShouldSerializeTaxNumber()
        {
            return !string.IsNullOrEmpty(this.TaxNumber);
        }

        public bool ShouldSerializeNameForeign()
        {
            return !string.IsNullOrEmpty(this.NameForeign);
        }
    }
}
