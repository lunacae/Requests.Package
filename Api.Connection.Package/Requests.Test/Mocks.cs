using Api.Connection.Package;
using Microsoft.Extensions.DependencyInjection;

namespace Tests
{
    public class Mocks
    {
        public static IServiceProvider BuildServiceProviderForRedis()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddScoped<IRequestsService, RequestsService>();

            IServiceProvider serviceProvider = services.BuildServiceProvider();
            return serviceProvider;
        }
    }
}
