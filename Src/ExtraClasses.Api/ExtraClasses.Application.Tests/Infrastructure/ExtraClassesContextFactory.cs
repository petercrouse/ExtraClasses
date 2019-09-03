using ExtraClasses.Domain.Entities;
using ExtraClasses.Persistence;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ExtraClasses.Application.Tests.Infrastructure
{
    public class ExtraClassesContextFactory
    {
        public static ExtraClassesDbContext Create()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<ExtraClassesDbContext>()
                .UseSqlite(connection)
                .Options;

            var context = new ExtraClassesDbContext(options);

            context.Database.EnsureCreated();

            context.Students.AddRange(new[]
            {
                new Student { StudentId = 1, LastName = "Baggins" , FirstName = "Frodo", Email = "fbaggins@theshire.com"},
                new Student { StudentId = 2, LastName = "Baggins" , FirstName = "Bilbo", Email = "bbaggins@theshire,com"},
                new Student { StudentId = 3, LastName = "Gam Gee" , FirstName = "Sam", Email = "sgamegee@theshire.com"},
                new Student { StudentId = 4, LastName = "BrandyBuck", FirstName = "Merry", Email = "mbrandybuck@theshire.com"}
            });

            context.Teachers.AddRange(new[]
            {
                new Teacher {
                    TeacherId = 1,
                    LastName = "The Grey",
                    FirstName = "Gandalf",
                    Email ="gandalf@wizzardcouncil.com",
                    TeachingSubjects = new List<TeacherSubject> {
                        new TeacherSubject {
                            TeacherId = 1,
                            SubjectId = 1
                        }
                    }
                },
                new Teacher
                {
                    TeacherId = 2,
                    LastName = "The White",
                    FirstName = "Saruman",
                    Email = "saurman@wizzardcouncil.com",
                    TeachingSubjects = new List<TeacherSubject>
                    {
                        new TeacherSubject
                        {
                            TeacherId = 2,
                            SubjectId = 2
                        },
                        new TeacherSubject
                        {
                            TeacherId = 2,
                            SubjectId = 1
                        }
                    }
                }
            });

            context.Subjects.AddRange(new[]
            {
                new Subject {SubjectId = 1, Name = "Magic"},
                new Subject {SubjectId = 2, Name = "Staff Logic"}
            });

            context.Bookings.AddRange(new[]
            {
                new Booking {BookingId = 1, StudentId = 1, ExtraClassId = 1, BookingPrice = 100},
                new Booking {BookingId = 2, StudentId = 2, ExtraClassId = 1, BookingPrice = 100},
                new Booking {BookingId = 3, StudentId = 4, ExtraClassId = 1, BookingPrice = 100},
                new Booking {BookingId = 4, StudentId = 1, ExtraClassId = 3, BookingPrice = 100}
            });

            context.ExtraClasses.AddRange(new[]
            {
                new ExtraClass {ExtraClassId = 1, TeacherId = 1, SubjectId = 1, Size = 2, Duration = new TimeSpan(1,00,00), Price = 100, Date = new DateTime(2555,1,1), IsClassFull = true, Name = "How to be a wizzard"},
                new ExtraClass {ExtraClassId = 2, TeacherId = 2, SubjectId = 2, Size = 4, Duration = new TimeSpan(1,00,00), Price = 100, Date = new DateTime(2555,1,1), IsClassFull = false, Name = "Staff Logic"},
                new ExtraClass {ExtraClassId = 3, TeacherId = 2, SubjectId = 2, Size = 4, Duration = new TimeSpan(1,00,00), Price = 100, Date = new DateTime(2555,1,1), IsClassFull = true, Name = "Wizzard Magic"}
            });

            context.SaveChanges();

            return context;
        }

        public static void Destroy(ExtraClassesDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.CloseConnection();
            context.Dispose();           
        }       
    }
}
