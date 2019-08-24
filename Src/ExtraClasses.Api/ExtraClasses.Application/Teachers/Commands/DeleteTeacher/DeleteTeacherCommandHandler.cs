using ExtraClasses.Application.Exceptions;
using ExtraClasses.Domain.Entities;
using ExtraClasses.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExtraClasses.Application.Teachers.Commands.DeleteTeacher
{
    public class DeleteTeacherCommandHandler : IRequestHandler<DeleteTeacherCommand, Unit>
    {
        private readonly IExtraClassesDbContext _context;

        public DeleteTeacherCommandHandler(IExtraClassesDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteTeacherCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Teachers.FindAsync(request.Id);

            if(entity == null)
            {
                throw new NotFoundException(nameof(Teacher), request.Id);
            }

            var teachesClasses = _context.ExtraClasses.Any(c => c.TeacherId == entity.TeacherId || c.CreatedById == entity.TeacherId);

            if (teachesClasses)
            {
                throw new DeleteFailureException(nameof(Teacher), request.Id, "There are still classes created or taught by this teacher");
            }

            _context.Teachers.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
