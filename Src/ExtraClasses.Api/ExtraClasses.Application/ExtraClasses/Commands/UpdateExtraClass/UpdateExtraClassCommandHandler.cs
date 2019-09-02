﻿using ExtraClasses.Application.Exceptions;
using ExtraClasses.Application.Extensions;
using ExtraClasses.Domain.Entities;
using ExtraClasses.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ExtraClasses.Application.ExtraClasses.Commands.UpdateExtraClass
{
    public class UpdateExtraClassCommandHandler : IRequestHandler<UpdateExtraClassCommand, Unit>
    {
        private readonly IExtraClassesDbContext _context;

        public UpdateExtraClassCommandHandler(IExtraClassesDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateExtraClassCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ExtraClasses.Where(c => c.ExtraClassId == request.Id)
                                                    .Include(t => t.Teacher)
                                                    .ThenInclude(s => s.TeachingSubjects).FirstOrDefaultAsync(cancellationToken);

            if(entity == null)
            {
                throw new NotFoundException(nameof(ExtraClass), request.Id);
            }

            var teacher = await _context.Teachers.FindAsync(request.TeacherId);

            if (teacher == null)
            {
                throw new NotFoundException(nameof(Teacher), request.TeacherId);
            }

            if (!teacher.TeachSubject(request.SubjectId))
            {
                throw new TeacherDoesNotTeachSubjectException(teacher.TeacherId, request.SubjectId);
            }


            entity.Name = request.Name;
            entity.Date = request.Date;
            entity.Duration = request.Duration;
            entity.IsClassFull = false;
            entity.Size = request.Size;
            entity.SubjectId = request.SubjectId;
            entity.TeacherId = request.TeacherId;
            entity.Price = request.Price;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
