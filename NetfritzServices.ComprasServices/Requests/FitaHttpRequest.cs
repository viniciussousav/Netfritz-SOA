using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NetfritzServices.ComprasServices.Requests
{
    public class FitaHttpRequest
    {
        private const string base_url = "http://localhost:5002/fitas/";
        private readonly HttpClient client;

        public FitaHttpRequest()
        {
            client = new HttpClient();
        }

        public async Task<bool> CheckFitaExists(string fitaId)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, base_url + fitaId);
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }
    }
}
