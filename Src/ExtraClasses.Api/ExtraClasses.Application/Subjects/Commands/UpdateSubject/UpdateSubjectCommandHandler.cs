using ExtraClasses.Application.Exceptions;
using ExtraClasses.Domain.Entities;
using ExtraClasses.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExtraClasses.Application.Subjects.Commands.UpdateSubject
{
    public class UpdateSubjectCommandHandler : IRequestHandler<UpdateSubjectCommand, Unit>
    {
        private readonly IExtraClassesDbContext _context;

        public UpdateSubjectCommandHandler(IExtraClassesDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateSubjectCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Subjects.FindAsync(request.Id);

            if(entity == null)
            {
                throw new NotFoundException(nameof(Subject), request.Id);
            }

            entity.Name = request.Name;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
