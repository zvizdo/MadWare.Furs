using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MadWare.Furs.Models.Invoice
{
    /// <summary>
    /// Vpišejo se podatki o pavšalnem nadomestilu. / Data about the flat-rate compensation are entered.
    /// Podatek se posreduje le, če račun vsebuje znesek obračunanega pavšalnega nadomestila. / The data is submitted only if the invoice includes the amount of the flat-rate compensation settled.
    /// Podatek je sestavljen iz stopnje, osnove in zneska pavšalnega nadomestila. / The data consists of the rate, base and amount of the flat-rate compensation.
    /// </summary>
    public class FlatRateCompensation
    {
        /// <summary>
        /// Vrednost stopnje pavšalnega nadomestila. / Value of the flat-rate compensation's rate
        /// Decimalno ločilo je pika. / The decimal separator is a dot.
        /// </summary>
        public decimal FlatRateRate { get; set; }

        /// <summary>
        /// Osnova oziroma vrednost od katere se obračuna znesek pavšalnega nadomestila (po zmanjšanju za popuste). / The base or value from which the amount of the flat-rate compensation is settled (after reduction for discounts).
        /// Decimalno ločilo je pika. / The decimal separator is a dot.
        /// </summary>
        public decimal FlatRateTaxableAmount { get; set; }

        /// <summary>
        /// Znesek pavšalnega nadomestila. / Amount of the flat-rate compensation
        /// Decimalno ločilo je pika. / The decimal separator is a dot.
        /// </summary>
        public decimal FlatRateAmount { get; set; }

    }
}
