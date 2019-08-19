using ExtraClasses.Domain.Entities;
using ExtraClasses.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExtraClasses.Persistence
{
    public class ExtraClassesDbContext : DbContext, IExtraClassesDbContext
    {
        public ExtraClassesDbContext(DbContextOptions<ExtraClassesDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<ExtraClass> ExtraClasses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ExtraClassesDbContext).Assembly);
        }
    }
}
