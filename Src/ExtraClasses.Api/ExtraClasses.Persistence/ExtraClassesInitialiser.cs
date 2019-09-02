using ExtraClasses.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExtraClasses.Persistence
{
    public class ExtraClassesInitialiser
    {
        private readonly Dictionary<int, Student> Students = new Dictionary<int, Student>();
        private readonly Dictionary<int, Teacher> Teachers = new Dictionary<int, Teacher>();
        private readonly Dictionary<int, Subject> Subjects = new Dictionary<int, Subject>();
        private readonly Dictionary<int, ExtraClass> ExtraClasses = new Dictionary<int, ExtraClass>();
        private readonly Dictionary<int, Booking> Bookings = new Dictionary<int, Booking>();

        public static void Initialise(ExtraClassesDbContext context)
        {
            var initialiser = new ExtraClassesInitialiser();
            initialiser.SeedEverything(context);
        }

        private void SeedEverything(ExtraClassesDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Bookings.Any())
            {
                return;
            }

            SeedStudents(context);
            SeedSubjects(context);
            SeedTeachers(context);
            SeedExtraClasses(context);
            SeedBookings(context);
        }

        private void SeedStudents(ExtraClassesDbContext context)
        {
            var students = new[]
            {
                new Student { LastName = "Baggins", FirstName = "Frodo", Email = "fbaggins@theshire.com" },
                new Student { LastName = "Baggins", FirstName = "Bilbo", Email = "bbaggins@theshire.com" },
                new Student { LastName = "Gam Gee", FirstName = "Sam", Email = "sgamegee@theshire.com" },
                new Student { LastName = "Brandybuck", FirstName = "Merry", Email = "mbrandybuck@theshire.com"}
            };

            context.Students.AddRange(students);
            context.SaveChanges();
        }

        private void SeedSubjects(ExtraClassesDbContext context)
        {
            var subjects = new[] {
                new Subject { Name = "Magic" },
                new Subject { Name = "Staff Logic"},
                new Subject { Name = "Dark Magic" }
            };

            context.AddRange(subjects);
            context.SaveChanges();
        }

        private void SeedTeachers(ExtraClassesDbContext context)
        {
            var teachers = new[] {
                new Teacher {
                    LastName = "The Grey",
                    FirstName = "Gandalf",
                    Email = "gandalf@wizzardcouncil.com",
                    TeachingSubjects = new List<TeacherSubject> {
                        new TeacherSubject {
                            TeacherId = 1,
                            SubjectId = 1
                        }
                    }
                },
                new Teacher
                {
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
                },
                new Teacher
                {
                    LastName = "Peredhel",
                    FirstName = "Elrond",
                    Email = "eperedhel@rivendell.com",
                    TeachingSubjects = new List<TeacherSubject>
                    {

                    }
                }
            };

            context.AddRange(teachers);
            context.SaveChanges();
        }

        private void SeedExtraClasses(ExtraClassesDbContext context)
        {
            var classes = new[] {
                new ExtraClass {
                    TeacherId = 1,
                    SubjectId = 1,
                    Size = 4,
                    Duration = new TimeSpan(01, 00, 00),
                    Price = 100,
                    Date = new DateTime(2555, 1, 1),
                    IsClassFull = false,
                    Name = "How to be a wizzard"
                },
                new ExtraClass
                {
                    TeacherId = 1,
                    SubjectId = 2,
                    Size = 10,
                    Duration = new TimeSpan(01, 00, 00),
                    Price = 150,
                    Date = new DateTime(2556, 1, 1),
                    IsClassFull = false,
                    Name = "Staff logic training"
                },
                new ExtraClass
                {
                    TeacherId = 2,
                    SubjectId = 2,
                    Size = 2,
                    Duration = new TimeSpan(0,30,0),
                    Price = 100,
                    Date = new DateTime(2556, 3, 3),
                    IsClassFull = false,
                    Name = "How to fight orcs"
                }
            };

            context.ExtraClasses.AddRange(classes);
            context.SaveChanges();
        }

        private void SeedBookings(ExtraClassesDbContext context)
        {
            var bookings = new[] {
            new Booking { StudentId = 1, ExtraClassId = 2, BookingPrice = 100 },
            new Booking { StudentId = 2, ExtraClassId = 2, BookingPrice = 100 },
            new Booking { StudentId = 2, ExtraClassId = 3, BookingPrice = 150 },
            new Booking { StudentId = 3, ExtraClassId = 2, BookingPrice = 100 },
            new Booking { StudentId = 3, ExtraClassId = 3, BookingPrice = 150 },
            new Booking { StudentId = 1, ExtraClassId = 1, BookingPrice = 100 }
            };

            context.Bookings.AddRange(bookings);
            context.SaveChanges();
        }
    }
}
