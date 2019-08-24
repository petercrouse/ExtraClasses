using System.Collections.Generic;

namespace ExtraClasses.Domain.Entities
{
    public class Teacher
    {
        public Teacher()
        {
            TeachingSubjects = new HashSet<TeacherSubject>();
            TeachingClasses = new HashSet<ExtraClass>();
            CreatedClasses = new HashSet<ExtraClass>();
        }

        public int TeacherId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }

        public ICollection<TeacherSubject> TeachingSubjects { get; set; }
        public ICollection<ExtraClass> TeachingClasses { get; set; }
        public ICollection<ExtraClass> CreatedClasses { get; set; }
    }
}
