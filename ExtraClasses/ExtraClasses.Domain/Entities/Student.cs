using System.Collections.Generic;

namespace ExtraClasses.Domain.Entities
{
    public class Student
    {
        public Student()
        {
            Bookings = new HashSet<Booking>();
        }

        public int StudentId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }

        public ICollection<Booking> Bookings { get; set; }
    }
}
