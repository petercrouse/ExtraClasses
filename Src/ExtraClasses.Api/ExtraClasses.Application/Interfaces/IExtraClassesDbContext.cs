using ExtraClasses.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace ExtraClasses.Interfaces
{
    public interface IExtraClassesDbContext
    {
        DbSet<Student> Students { get; set; }
        DbSet<Booking> Bookings { get; set; }
        DbSet<ExtraClass> ExtraClasses { get; set; }
        DbSet<Teacher> Teachers { get; set; }
        DbSet<Subject> Subjects { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
