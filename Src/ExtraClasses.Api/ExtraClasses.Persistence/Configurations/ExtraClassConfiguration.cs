using ExtraClasses.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExtraClasses.Persistence.Configurations
{
    public class ExtraClassConfiguration : IEntityTypeConfiguration<ExtraClass>
    {
        public void Configure(EntityTypeBuilder<ExtraClass> builder)
        {
            builder.ToTable("ExtraClass");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(e => e.Date)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(e => e.Duration)
                .IsRequired()
                .HasColumnType("time(7)");

            builder.Property(e => e.Price)
                .IsRequired()
                .HasColumnType("money");

            builder.Property(e => e.CreatedById)
                .IsRequired();

            builder.HasOne(e => e.CreatedBy)
                .WithMany()
                .HasForeignKey(e => e.CreatedById);

            builder.HasOne(e => e.Teacher)
                .WithMany()
                .HasForeignKey(e => e.TeacherId);

            builder.HasOne(e => e.Subject)
                .WithMany()
                .HasForeignKey(e => e.SubjectId);

            builder.HasMany(e => e.Bookings)
                .WithOne(e => e.ExtraClass)
                .HasForeignKey(e => e.ExtraClassId);
        }
    }
}
