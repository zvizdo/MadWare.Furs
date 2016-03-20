using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MadWare.Furs.Models.Invoice
{
    public class SalesBookInvoice : BaseInvoice
    {
        public SalesBookIdentifier SalesBookIdentifier { get; set; }

        /// <summary>
        /// Vpiše se oznaka poslovnega prostora v katerem je bil izdan račun iz vezane knjige računov. / The mark of business premises is entered, in which the invoice has been issued from the pre-numbered invoice book.
        /// Oznaka poslovnega prostora mora biti enaka oznaki, ki je bila posredovana v okviru podatkov o poslovnih prostorih. / The mark of business premises shall be the same as the mark, which has been submitted within data about business premises.
        /// Vsebuje lahko samo črke in številke / It may include only the following letters and numbers: 0-9, a-z, A-Z.
        /// </summary>
        public string BusinessPremiseID { get; set; }

    }
}
