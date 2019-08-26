using AutoMapper;
using ExtraClasses.Application.Interfaces.Mapping;
using ExtraClasses.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtraClasses.Application.ExtraClasses.Queries.GetExtraClass
{
    public class ExtraClassViewModel : IHaveCustomMapping
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string TeacherName { get; set; }
        public int Size { get; set; }
        public bool IsClassFull { get; set; }
        public TimeSpan Duration { get; set; }
        public string SubjectName { get; set; }
        public double Price { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<ExtraClass, ExtraClassViewModel>()
                .ForMember(cDTO => cDTO.SubjectName, opt => opt.MapFrom(c => c.Subject != null ? c.Subject.Name : string.Empty))
                .ForMember(cDTO => cDTO.TeacherName, opt => opt.MapFrom(c => c.Teacher != null ? $"{c.Teacher.FirstName} {c.Teacher.LastName}" : string.Empty));
        }
    }
}
