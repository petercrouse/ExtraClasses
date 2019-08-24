﻿using ExtraClasses.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExtraClasses.Persistence.Configurations
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.ToTable("Teacher");

            builder.HasMany(e => e.TeachingSubjects)
                .WithOne(e => e.Teacher)
                .HasForeignKey(e => e.TeacherId);

            builder.HasMany(e => e.CreatedClasses)
                .WithOne(e => e.CreatedBy)
                .HasForeignKey(e => e.CreatedById);

            builder.HasMany(e => e.TeachingClasses)
                .WithOne(e => e.Teacher)
                .HasForeignKey(e => e.TeacherId);
        }
    }
}
