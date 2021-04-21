using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AdventureWorks.Web.Api.Helpers
{
    public static class ContextConfiguration
    {
        public static IServiceCollection AddDbContext<TContextImplementation>(this IServiceCollection services,
            string connectionString) where TContextImplementation : DbContext
        {
            services.AddDbContext<TContextImplementation>(options =>
                {
                    options.UseSqlServer(connectionString, o =>
{
    o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
});

                    options.UseLazyLoadingProxies(true);
                }
            );
            return services;
        }
    }
}
