using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace MadWare.Furs.WebService
{
    public class FursConfig
    {
        public string Url { get; set; }

        public X509Certificate2 Certificate { get; set; }

        /// <summary>
        /// Timeout in seconds when calling service. Default value is 3.
        /// </summary>
        public int HttpTimeout = 3;
    }
}
