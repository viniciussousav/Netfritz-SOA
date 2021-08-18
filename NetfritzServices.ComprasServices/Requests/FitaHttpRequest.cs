using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NetfritzServices.ComprasServices.Requests
{
    public class FitaHttpRequest
    {
        private const string base_url = "https://localhost:6010/fitas/";
        private readonly HttpClient client;

        public FitaHttpRequest()
        {
            client = new HttpClient();
        }

        public async Task<bool> CheckFitaExists(string fitaId)
        {
            var url = new Uri(base_url + fitaId);
            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }
    }
}
