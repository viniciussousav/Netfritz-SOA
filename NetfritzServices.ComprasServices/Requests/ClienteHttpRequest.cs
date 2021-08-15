using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace NetfritzServices.ComprasServices.Requests
{
    public class ClienteHttpRequest
    {
        private const string base_url = "http://localhost:5001/cliente/";
        private readonly HttpClient httpClient;


        public ClienteHttpRequest()
        {
            httpClient = new HttpClient();
        }

        public async Task<bool> CheckClientExists(string clienteId)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, base_url + clienteId);
            var response = await httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
           
            return false;  
        }
    }
}
