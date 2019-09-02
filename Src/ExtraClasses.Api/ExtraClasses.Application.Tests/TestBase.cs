using ExtraClasses.Persistence;
using Microsoft.EntityFrameworkCore;
using System;

namespace ExtraClasses.Application.Tests
{
    public class TestBase
    {
        public ExtraClassesDbContext GetDbContext(bool useSqlLite = false)
        {
            var builder = new DbContextOptionsBuilder<ExtraClassesDbContext>();
            if (useSqlLite)
            {
                builder.UseSqlite("DataSource=:memory:", x => { });
            }
            else
            {
                builder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            }

            var dbContext = new ExtraClassesDbContext(builder.Options);
            if (useSqlLite)
            {
                // SQLite needs to open connection to the DB.
                // Not required for in-memory-database.
                dbContext.Database.OpenConnection();
            }

            dbContext.Database.EnsureCreated();

            return dbContext;
        }
    }
}
