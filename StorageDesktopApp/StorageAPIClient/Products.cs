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
    public class Products
    {
        public static async Task<List<Product>> GetAllProducts(HttpClient client)
        {
            HttpResponseMessage response;
            try
            {
                var builder = new UriBuilder($"{client.BaseAddress}StorageAPI/Products/");
                var url = builder.ToString();
                response = await client.GetAsync(url);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            string contents = await response.Content.ReadAsStringAsync();
            if (string.IsNullOrEmpty(contents))
            {
                return null;
            }
            try
            {
                List<Product> products = JsonConvert.DeserializeObject<List<Product>>(contents);
                return products;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
