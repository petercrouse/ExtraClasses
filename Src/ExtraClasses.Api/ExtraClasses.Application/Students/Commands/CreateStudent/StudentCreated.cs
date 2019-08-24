using ExtraClasses.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtraClasses.Application.Students.Commands.CreateStudent
{
    public class StudentCreated : INotification
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
    }
}
