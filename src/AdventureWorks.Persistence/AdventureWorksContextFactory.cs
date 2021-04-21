using AdventureWorks.Persistence.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorks.Persistence
{
    public class AdventureWorksContextFactory : DesignTimeDbContextFactoryBase<AdventureWorksContext>
    {
        protected override AdventureWorksContext CreateNewInstance(
            DbContextOptions<AdventureWorksContext> options)
        {
            return new(options);
        }
    }
}