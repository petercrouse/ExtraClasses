using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtraClasses.Application.ExtraClasses.Commands.UpdateExtraClass
{
    public class UpdateExtraClassCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int? TeacherId { get; set; }
        public int Size { get; set; }
        public TimeSpan Duration { get; set; }
        public int SubjectId { get; set; }
        public double Price { get; set; }
    }
}
