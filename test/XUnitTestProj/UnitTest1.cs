using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestProj
{
    public class UnitTest1
    {
        private readonly HttpClient _client = TestFixture.Client;

        [Fact]
        public async Task TestAsync()
        {
            var json = await _client.GetStringAsync("/api/values");
            var result = JsonConvert.DeserializeObject<IList<string>>(json);
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }
    }
}
