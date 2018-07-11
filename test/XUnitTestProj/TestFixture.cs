using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using TestFailx101;

namespace XUnitTestProj
{
    public class TestFixture
    {
        private static TestServer _server;
        private static HttpClient _client;

        private readonly static object _lock = new object();
        public static TestServer Server
        {
            get
            {
                lock (_lock)
                {
                    if (_server == null)
                    {
                        var builder = WebHostBuilderFactory.CreateFromAssemblyEntryPoint(typeof(Startup).Assembly, null);
                        builder.UseSolutionRelativeContentRoot("src/TestFailx101/");
                        _server = new TestServer(builder);
                    }
                    return _server;
                }
            }
        }

        public static HttpClient Client
        {
            get
            {
                if (_client == null)
                {
                    _client = Server.CreateClient();
                }
                return _client;
            }
        }
    }
}
