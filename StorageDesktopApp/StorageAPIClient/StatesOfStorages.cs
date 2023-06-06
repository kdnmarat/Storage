using StorageDesktopApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StorageDesktopApp.StorageAPIClient
{
    class StatesOfStorages
    {
        internal static async Task<List<StateOfStorage>> GetAllStatesOfStorages(HttpClient client)
        {
            HttpResponseMessage response;
            try
            {
                var builder = new UriBuilder($"{client.BaseAddress}/StorageAPI/StatesOfStorages/");
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
                log.LogError($"[ERROR] User is not found by email: {email}");
                return null;
            }
            try
            {
                UserModel greenHouseUser = JsonConvert.DeserializeObject<UserModel>(contents);
                return greenHouseUser;
            }
            catch (Exception ex)
            {
                log.LogError($"[ERROR] Failed to parse the user:");
                log.LogError(ex.Message);
                return null;
            }
        }
    }
}
