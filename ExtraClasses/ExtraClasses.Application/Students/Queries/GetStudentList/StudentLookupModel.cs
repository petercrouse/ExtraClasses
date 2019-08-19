﻿using AutoMapper;
using ExtraClasses.Application.Interfaces.Mapping;
using ExtraClasses.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtraClasses.Application.Students.Queries.GetStudentList
{
    public class StudentLookupModel : IHaveCustomMapping
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Student, StudentLookupModel>()
                .ForMember(s => s.Id, opt => opt.MapFrom(s => s.StudentId));
        }
    }
}
