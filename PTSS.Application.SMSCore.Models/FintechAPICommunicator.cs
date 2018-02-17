using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PTSS.Application.SMSCore.Models
{
    public static class FintechURL
    {
        public static string BaseURL = "https://tps.azure-api.net/";
        public static string Customers = $"{BaseURL}customers/";
        public static string Wallets = $"{BaseURL}wallets/";


    }
    public class FintechAPICommunicator
    {
        
        public static HttpClient getDefaultHeaders()
        {
            var client = new HttpClient();

            // Request headers
            client.DefaultRequestHeaders.Add("X-Consumer-Custom-Id", "2");
            client.DefaultRequestHeaders.Add("X-Authenticated-Userid", "Ali.Khan");
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "{subscription key}");

            return client;
        }

        static async void MakePostRequest()
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            client = getDefaultHeaders();

            var uri = $"{FintechURL.Customers}customers?{queryString}";

            HttpResponseMessage response;

            // Request body
            byte[] byteData = Encoding.UTF8.GetBytes("{body}");

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await client.PostAsync(uri, content);
            }

        }

        static async void MakeGetRequest()
        {
            string uniqueIdentifier = string.Empty;
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            client = getDefaultHeaders();

            var uri = $"{FintechURL.Customers}customers/{uniqueIdentifier}/wallets?{queryString}";

            var response = await client.GetAsync(uri);
        }

        static async void MakePutRequest()
        {
            string walletId = string.Empty;
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            client = getDefaultHeaders();

            var uri = $"{FintechURL.Wallets}wallets/{walletId}?{queryString}";

            HttpResponseMessage response;

            // Request body
            byte[] byteData = Encoding.UTF8.GetBytes("{body}");

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await client.PutAsync(uri, content);
            }
        }
    }
}
