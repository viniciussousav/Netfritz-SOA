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
        private const string base_url = "https://localhost:6030/cadastro/cliente/";
        private readonly HttpClient httpClient;


        public ClienteHttpRequest()
        {
            httpClient = new HttpClient();
        }

        public async Task<bool> CheckClientExists(string clienteId)
        {
            var url = new Uri(base_url + clienteId);
            var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
           
            return false;  
        }
    }
}
