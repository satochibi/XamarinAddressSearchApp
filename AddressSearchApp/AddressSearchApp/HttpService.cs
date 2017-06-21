using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace AddressSearchApp
{
    class HttpService
    {
        public static async Task<dynamic> getDataFromService(string querySring)
        {
            dynamic data = null;
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(querySring);

            if ((response != null)&&!((int)response.StatusCode >= 400))
            {
                string json = response.Content.ReadAsStringAsync().Result;
                data = JsonConvert.DeserializeObject(json);
            }

            return data;
        }
    }
}
