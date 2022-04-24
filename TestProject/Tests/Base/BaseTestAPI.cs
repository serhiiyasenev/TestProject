using Core;
using NUnit.Framework;
using System;
using System.Net.Http;
using System.Threading;

namespace TestProject.Tests.Base
{
    public class BaseTestAPI : BaseTest
    {
        private ThreadLocal<HttpClient> _httpClientPool;
        private static readonly object Thread = new();

        protected HttpClient HttpClient
        {
            get
            {
                lock (Thread)
                {
                    return _httpClientPool.Value ??= CreateHttpClient();
                }
            }
        }



        [SetUp]
        public void TestInitialize()
        {
            lock (Thread)
            {
                _httpClientPool = new ThreadLocal<HttpClient>();
            }
        }

        [TearDown]
        public void TestFinalize()
        {
            lock (Thread)
            {
                if (_httpClientPool.Value != null)
                {
                    _httpClientPool.Value.Dispose();
                    _httpClientPool.Value = null;
                }
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
