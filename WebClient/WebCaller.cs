using System;
using System.Dynamic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace WebClient
{
    public class WebCaller
    {
        private readonly HttpClientHandler handler;        
        
        public WebCaller()
        {
            handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, certificate, chain, sslPolicyErrors) =>
                {
                    File.WriteAllBytes("C://Temp/Test.cer", certificate.Export(X509ContentType.Cert));

                    return true;
                }
            };
        }
        
        public string DoACall(string url)
        {
            using (var client = new HttpClient(handler))
            {
                var response = client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
                return response.Result.ToString();
            }

        }

    }
}