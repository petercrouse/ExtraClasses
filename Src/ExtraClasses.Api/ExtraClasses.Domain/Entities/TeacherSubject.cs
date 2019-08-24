﻿namespace ExtraClasses.Domain.Entities
{
    public class TeacherSubject
    {
        public int TeacherId { get; set; }
        public int SubjectId { get; set; }

        public Teacher Teacher { get; set; }
        public Subject Subject { get; set; }
    }
}
