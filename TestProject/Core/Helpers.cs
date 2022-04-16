using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace NUnitProject.Core
{
    public class Helpers
    {
        public static T DeserializeObjectAsync<T>(string json)
        {
            var model = JsonConvert.DeserializeObject<T>(json);
            return model;
        }

        public static async Task<string> SendCalculateAsync(string value, string requestUrl)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri(Urls.Base);
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("number", $"{value}")
            });
            var result = await client.PostAsync(requestUrl, content);
            return await result.Content.ReadAsStringAsync();
        }

        public static int GetFactorial(int fact)
        {
            if (fact == 0)
                return 1;
            return fact * GetFactorial(fact - 1);
        }
    }
}
