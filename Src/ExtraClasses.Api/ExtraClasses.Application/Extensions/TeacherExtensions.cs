using ExtraClasses.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtraClasses.Application.Extensions
{
    public static class TeacherExtensions
    {
        public static bool TeachSubject(this Teacher instance, int id)
        {
            return instance.TeachingSubjects.Any(s => s.SubjectId == id);
        }
    }
}
