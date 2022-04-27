using Core;
using NUnit.Framework;
using System.Threading;

namespace TestProject.Tests.Base
{
    public class BaseTestAPI : BaseTest
    {
        private ThreadLocal<HttpClientManager> _httpClientPool;
        private static readonly object Thread = new();

        protected HttpClientManager HttpClient
        {
            get
            {
                lock (Thread)
                {
                    return _httpClientPool.Value ??= new HttpClientManager();
                }
            }
        }



        [SetUp]
        public void TestInitialize()
        {
            lock (Thread)
            {
                _httpClientPool = new ThreadLocal<HttpClientManager>();
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

    }
}