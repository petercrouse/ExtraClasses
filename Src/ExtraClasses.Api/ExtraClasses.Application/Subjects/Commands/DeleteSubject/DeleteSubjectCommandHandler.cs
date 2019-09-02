﻿using ExtraClasses.Application.Exceptions;
using ExtraClasses.Domain.Entities;
using ExtraClasses.Interfaces;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ExtraClasses.Application.Subjects.Commands.DeleteSubject
{
    public class DeleteSubjectCommandHandler : IRequestHandler<DeleteSubjectCommand, Unit>
    {
        private readonly IExtraClassesDbContext _context;

        public DeleteSubjectCommandHandler(IExtraClassesDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteSubjectCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Subjects.FindAsync(request.Id);

            if(entity == null)
            {
                throw new NotFoundException(nameof(Subject), request.Id);
            }

            var taughtInClasses = _context.ExtraClasses.Any(s => s.SubjectId == request.Id);
            var taughtByTeacher = _context.Teachers.Any(s => s.TeachingSubjects.Any(t => t.SubjectId == request.Id));

            if (taughtInClasses)
            {
                throw new DeleteFailureException(nameof(Subject), request.Id, "There are still classes hosting this subject");
            }

            if (taughtByTeacher)
            {
                throw new DeleteFailureException(nameof(Subject), request.Id, "There are still teachers teaching this subject");
            }

            _context.Subjects.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
