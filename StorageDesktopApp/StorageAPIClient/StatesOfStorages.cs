using Newtonsoft.Json;
using StorageDesktopApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StorageDesktopApp.StorageAPIClient
{
    public class StatesOfStorages
    {
        public static async Task<List<StateOfStorage>> GetAllStatesOfStorages(HttpClient client)
        {
            HttpResponseMessage response;
            try
            {
                var builder = new UriBuilder($"{client.BaseAddress}StorageAPI/StatesOfStorages/");
                var url = builder.ToString();
                response = await client.GetAsync(url);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            // Parse users from the response
            string contents = await response.Content.ReadAsStringAsync();
            if (string.IsNullOrEmpty(contents))
            {
                return null;
            }
            try
            {
                List<StateOfStorage> states = JsonConvert.DeserializeObject<List<StateOfStorage>>(contents);
                return states;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
