using System;
using System.Collections.Generic;

namespace ExtraClasses.Domain.Entities
{
    public class ExtraClass
    {
        public ExtraClass()
        {
            Bookings = new HashSet<Booking>();
        }

        public long ExtraClassId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int? TeacherId { get; set; }
        public int Size { get; set; }
        public bool IsClassFull { get; set; }
        public TimeSpan Duration { get; set; }
        public int SubjectId { get; set; }
        public double Price { get; set; }
        public int CreatedById { get; set; }
        public int? ModifiedById { get; set; }

        public Subject Subject { get; set; }
        public Teacher ModifiedBy { get; set; }
        public Teacher CreatedBy { get; set; }
        public Teacher Teacher { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
