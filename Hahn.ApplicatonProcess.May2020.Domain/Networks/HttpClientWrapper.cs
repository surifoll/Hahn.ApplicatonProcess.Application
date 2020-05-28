using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.May2020.Domain.Networks
{
    public class HttpClientWrapper : IHttpClientWrapper
    {

        public async Task<string> HttpGetAsync(string url)
        {
            using (var client = new HttpClient())
            {

                var result = await client.GetAsync(url);
                if (result.StatusCode == HttpStatusCode.OK)
                {
                    string resultContent = await result.Content.ReadAsStringAsync();
                    return resultContent;
                }

                return null;

            }
        }
    }
}
