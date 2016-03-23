using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MadWare.Furs.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Net;
using System.Net.Security;
using System.Net.Http;
using System.Text;
using MadWare.Furs.Requests;

namespace MadWare.Furs.Http
{
    public class SoapHttpService : IHttpService
    {
        private X509Certificate2 cert;
        private int timeout;

        public SoapHttpService(X509Certificate2 cert, int timeoutSeconds = 3)
        {
            this.cert = cert;
            this.timeout = timeoutSeconds;

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.ServerCertificateValidationCallback += new System.Net.Security.RemoteCertificateValidationCallback(this.RemoteCertificateValidationCallback);
        }

        protected virtual bool RemoteCertificateValidationCallback(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        public async Task<string> SendRequest(string url, string payload, BaseRequestBody b)
        {
            WebRequestHandler handler = new WebRequestHandler();
            handler.ClientCertificates.Add(this.cert);

            using (HttpClient client = new HttpClient(handler))
            {
                client.DefaultRequestHeaders.Add("SOAPAction", b.GetSOAPAction());
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("text/xml"));
                client.Timeout = TimeSpan.FromSeconds(this.timeout);

                var cnt = new StringContent(payload, Encoding.UTF8, "text/xml");

                HttpResponseMessage resp = await client.PostAsync(url, cnt);

                string content = await resp.Content.ReadAsStringAsync();
                return content;
            }
        }
    }
}
