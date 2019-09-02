using AutoMapper;
using ExtraClasses.Application.Interfaces.Mapping;
using ExtraClasses.Domain.Entities;

namespace ExtraClasses.Application.Teachers.Queries.GetTeacherList
{
    public class TeacherLookupModel : IHaveCustomMapping
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Teacher, TeacherLookupModel>()
                .ForMember(s => s.Id, opt => opt.MapFrom(s => s.TeacherId));
        }
    }
}
