using ExtraClasses.Domain.Entities;
using ExtraClasses.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExtraClasses.Application.Teachers.Commands.CreateTeacher
{
    public class CreateTeacherCommandHandler : IRequestHandler<CreateTeacherCommand, Unit>
    {
        private readonly IExtraClassesDbContext _context;

        public CreateTeacherCommandHandler(IExtraClassesDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
        {
            var entity = new Teacher
            {
                LastName = request.LastName,
                FirstName = request.FirstName,
                Email = request.Email
            };

            await _context.Teachers.AddAsync(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
