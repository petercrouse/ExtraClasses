using ExtraClasses.Domain.Entities;
using System.Linq;

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
