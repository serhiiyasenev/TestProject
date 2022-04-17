using NUnit.Framework;
using System;
using System.Net.Http;
using System.Threading;
using TestProject.Core;

namespace TestProject.Tests.Base
{
    public class BaseTestAPI : BaseTest
    {
        private ThreadLocal<HttpClient> _httpClientPool;

        protected HttpClient HttpClient => _httpClientPool.Value ??= CreateHttpClient();

        [SetUp]
        public void TestInitialize()
        {
            _httpClientPool = new ThreadLocal<HttpClient>();
        }

        [TearDown]
        public void TestFinalize()
        {
            if (_httpClientPool.Value != null)
            {
                _httpClientPool.Value.Dispose();
                _httpClientPool.Value = null;
            }
        }

        private HttpClient CreateHttpClient()
        {
            _httpClientPool = new ThreadLocal<HttpClient>
            {
                Value = new HttpClient
                {
                    BaseAddress = new Uri(Urls.Base)
                }
            };
            return _httpClientPool.Value;
        }
    }
}
