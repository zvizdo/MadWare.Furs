using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MadWare.Furs.Serialization;
using MadWare.Furs.Requests;
using MadWare.Furs.Models.Invoice;
using System.Security.Cryptography.X509Certificates;
using System.Globalization;
using System.Text;
using System.Security.Cryptography;

namespace MadWare.Furs.ZOI
{
    public class CertZOIProvider : IZOIProvider
    {
        private X509Certificate2 cert;

        public CertZOIProvider(X509Certificate2 cert)
        {
            this.cert = cert;
        }

        private string GetMD5Hash(byte[] input)
        {
            MD5 md5Hash = MD5.Create();

            byte[] data = md5Hash.ComputeHash(input);
            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++) { sBuilder.Append(data[i].ToString("x2")); }
            return sBuilder.ToString();
        }

        public void CalculateZOI<T>(Envelope<T> e) where T : BaseRequestBody
        {
            var invReq = e as Envelope<InvoiceRequestBody>;
            Invoice i = invReq.Body.InvoiceRequest.Invoice;

            string data = string.Concat( i.TaxNumber,
                                         i.IssueDateTime.ToString("dd.MM.yyyy HH:mm:ss"),
                                         i.InvoiceIdentifier.InvoiceNumber,
                                         i.InvoiceIdentifier.BusinessPremiseID,
                                         i.InvoiceIdentifier.ElectronicDeviceID,
                                         i.InvoiceAmount.ToString("N2", CultureInfo.InvariantCulture));

            byte[] bytes = Encoding.ASCII.GetBytes(data);

            RSACryptoServiceProvider rsaCSP = (RSACryptoServiceProvider)this.cert.PrivateKey;
            CspParameters cspParameters = new CspParameters();
            cspParameters.KeyContainerName = rsaCSP.CspKeyContainerInfo.KeyContainerName;
            cspParameters.KeyNumber = rsaCSP.CspKeyContainerInfo.KeyNumber == KeyNumber.Exchange ? 1 : 2;

            RSACryptoServiceProvider rsaAesCSP = new RSACryptoServiceProvider(cspParameters);
            byte[] signature = rsaAesCSP.SignData(bytes, CryptoConfig.MapNameToOID("SHA256"));

            string zoi = GetMD5Hash(signature);

            i.ProtectedID = zoi;
        }

        public bool MustCalculateZOI<T>(Envelope<T> e) where T : BaseRequestBody
        {
            if (e.Body == null)
                return false;

            if (!(e.Body is InvoiceRequestBody))
                return false;

            var invReqBody = e.Body as InvoiceRequestBody;
            if (invReqBody.InvoiceRequest == null || invReqBody.InvoiceRequest.Invoice == null)
                return false;

            return true;
        }

    }
}
