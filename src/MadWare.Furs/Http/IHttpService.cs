using MadWare.Furs.Requests;
using MadWare.Furs.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace MadWare.Furs.Http
{
    public interface IHttpService
    {

        Task<string> SendRequest(string url, string payload, BaseRequestBody b); 

    }
}
