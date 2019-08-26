using ExtraClasses.Application.Subjects.Queries.GetSubject;
using ExtraClasses.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExtraClasses.Application.Subjects.Queries.GetSubjects
{
    public class GetSubjectsQueryHandler : IRequestHandler<GetSubjectListQuery, SubjectListViewModel>
    {
        private readonly IExtraClassesDbContext _context;

        public GetSubjectsQueryHandler(IExtraClassesDbContext context)
        {
            _context = context;
        }

        public async Task<SubjectListViewModel> Handle(GetSubjectListQuery request, CancellationToken cancellationToken)
        {
            return new SubjectListViewModel
            {
                Subjects = await _context.Subjects.Select(x => SubjectDto.Create(x)).ToListAsync()
            };
        }
    }
}
