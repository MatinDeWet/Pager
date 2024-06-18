using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pager.UnitTests.Context;
using Pager.UnitTests.MockData;

namespace Pager.UnitTests
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.Scan(scan => scan
            .FromAssemblyOf<IMockData>()
            .AddClasses((classes) => classes.AssignableToAny(typeof(IMockData)))
            .AsSelfWithInterfaces()
            .WithScopedLifetime());

            services.AddDbContext<TestContext>(options =>
            {
                options.UseInMemoryDatabase("test");
            });

            //Seed Data
            var provider = services.BuildServiceProvider();

            var ctx = provider.GetRequiredService<TestContext>();
            MockSeeder.Seed(ctx, provider.GetServices<IMockData>());
        }
    }
}
