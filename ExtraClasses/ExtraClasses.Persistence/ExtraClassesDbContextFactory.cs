using ExtraClasses.Persistence.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace ExtraClasses.Persistence
{
    public class ExtraClassesDbContextFactory : DesignTimeDbContextFactoryBase<ExtraClassesDbContext>
    {
        protected override ExtraClassesDbContext CreateNewInstance(DbContextOptions<ExtraClassesDbContext> options)
        {
            return new ExtraClassesDbContext(options);
        }
    }
}
