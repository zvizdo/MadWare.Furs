using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MadWare.Furs.Models.Common
{
    public class Header
    {
        /// <summary>
        /// Enkratni identifikator sporočila. / Unique identifier of the message
        /// Vsako sporočilo mora imeti enkratno identifikacijsko oznako.
        /// Enako velja tudi pri pošiljanju sporočila, ki se zaradi napake pošilja ponovno. / Every message shall have the unique identification mark.The same is valid also for sending messages, which are resent due to errors.
        /// </summary>
        public string MessageID { get; set; }

        /// <summary>
        /// Datum in čas pošiljanja sporočila. / Date and time of sending the message
        /// </summary>
        public DateTime DateTime { get; set; }
    }
}
