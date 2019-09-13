using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Fusillade;
using LoginPage.Models;
using ModernHttpClient;
using Newtonsoft.Json;
using Refit;

namespace LoginPage.Services
{
    public class ApiService : IApiService
    {
        public ApiService()
        {
        }

        public async Task<PhonesDirectory> GetDirectories()
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync("https://api-newbee.herokuapp.com/directorio");
            return JsonConvert.DeserializeObject<PhonesDirectory>(response);
        }

    }
}
