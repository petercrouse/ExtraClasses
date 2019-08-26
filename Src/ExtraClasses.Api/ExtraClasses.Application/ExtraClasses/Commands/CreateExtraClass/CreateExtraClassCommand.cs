using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtraClasses.Application.ExtraClasses.Commands.CreateExtraClass
{
    public class CreateExtraClassCommand : IRequest<int>
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int? TeacherId { get; set; }
        public int Size { get; set; }
        public TimeSpan Duration { get; set; }
        public int SubjectId { get; set; }
        public double Price { get; set; }       
    }
}
