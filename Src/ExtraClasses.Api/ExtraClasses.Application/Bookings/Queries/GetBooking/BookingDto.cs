using AutoMapper;
using ExtraClasses.Application.Interfaces.Mapping;
using ExtraClasses.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtraClasses.Application.Bookings.Queries.GetBooking
{
    public class BookingDto : IHaveCustomMapping
    {
        public int Id { get; set; }
        public int ExtraClassId { get; set; }
        public string ExtraClassName { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public bool Paid { get; set; }
        public double Price { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Booking, BookingDto>()
                .ForMember(bDTO => bDTO.Id, opt => opt.MapFrom(b => b.BookingId))
                .ForMember(bDTO => bDTO.ExtraClassName, opt => opt.MapFrom(b => b.ExtraClass.Name))
                .ForMember(bDTO => bDTO.StudentName, opt => opt.MapFrom(b => $"{b.Student.FirstName} {b.Student.LastName}"));
        }
    }
}
