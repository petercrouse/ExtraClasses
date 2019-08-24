using ExtraClasses.Application.Exceptions;
using ExtraClasses.Domain.Entities;
using ExtraClasses.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExtraClasses.Application.Teachers.Queries.GetTeacher
{
    public class GetTeacherQueryHandler : IRequestHandler<GetTeacherQuery, TeacherDto>
    {
        private readonly IExtraClassesDbContext _context;

        public GetTeacherQueryHandler(IExtraClassesDbContext context)
        {
            _context = context;
        }

        public async Task<TeacherDto> Handle(GetTeacherQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Teachers.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Teacher), request.Id);
            }

            return TeacherDto.Create(entity);
        }
    }
}
