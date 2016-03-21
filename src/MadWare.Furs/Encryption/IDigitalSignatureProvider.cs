using MadWare.Furs.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MadWare.Furs.Encryption
{
    public interface IDigitalSignatureProvider
    {
        /// <summary>
        /// Sign payload
        /// </summary>
        /// <param name="payload">Payload to add signature</param>
        /// <param name="e">Serialized representation of the payload</param>
        /// <returns>Signed payload</returns>
        string Sign(string payload, Envelope<BaseRequestBody> e);
    }
}
