using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace TestProject.Core
{
    public static class Helpers
    {
        public static T DeserializeObjectAsync<T>(string json)
        {
            var model = JsonConvert.DeserializeObject<T>(json);
            return model;
        }

        public static async Task<string> SendPostAsync(this HttpClient client, HttpContent content, string requestUrl)
        {
            var result = await client.PostAsync(requestUrl, content);
            return await result.Content.ReadAsStringAsync();
        }

        public static int GetFactorial(int fact)
        {
            if (fact == 0)
                return 1;
            return fact * GetFactorial(fact - 1);
        }

        public static void KillAllProcesses(string processName)
        {
            foreach (var process in Process.GetProcessesByName(processName))
            {
                try
                {
                    process.Kill();
                }
                catch
                {
                    // ignored
                }
            }
        }
    }
}
