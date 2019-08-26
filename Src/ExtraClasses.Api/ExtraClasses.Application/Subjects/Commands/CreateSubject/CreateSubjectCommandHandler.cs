using ExtraClasses.Domain.Entities;
using ExtraClasses.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExtraClasses.Application.Subjects.Commands.CreateSubject
{
    public class CreateSubjectCommandHandler : IRequestHandler<CreateSubjectCommand, int>
    {
        private readonly IExtraClassesDbContext _context;

        public CreateSubjectCommandHandler(IExtraClassesDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateSubjectCommand request, CancellationToken cancellationToken)
        {
            var entity = new Subject
            {
                Name = request.Name
            };

            _context.Subjects.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.SubjectId;
        }
    }
}
