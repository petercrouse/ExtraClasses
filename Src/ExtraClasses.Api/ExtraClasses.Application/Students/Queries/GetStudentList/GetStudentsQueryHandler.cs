using AutoMapper;
using AutoMapper.QueryableExtensions;
using ExtraClasses.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExtraClasses.Application.Students.Queries.GetStudentList
{
    public class GetStudentsQueryHandler : IRequestHandler<GetStudentListQuery, StudentListViewModel>
    {
        private readonly IExtraClassesDbContext _context;
        private readonly IMapper _mapper;

        public GetStudentsQueryHandler(IExtraClassesDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<StudentListViewModel> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            return new StudentListViewModel
            {
                Students = await _context.Students.ProjectTo<StudentLookupModel>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken)
            };
        }
    }
}
