using Api.Connection.Package;
using Microsoft.Extensions.DependencyInjection;
using Tests;

namespace Requests.Test
{
    public class RequestTest
    {
        [Fact]
        public async Task Test()
        {
            IServiceProvider serviceProvider = Mocks.BuildServiceProviderForRedis();
            var requestService = serviceProvider.GetRequiredService<IRequestsService>();
            var result = await requestService.ExecutRequestAsync("http://google.com.br", "");
            Assert.NotNull(result);
        }
    }
}