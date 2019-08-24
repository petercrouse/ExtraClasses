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

namespace ExtraClasses.Application.Teachers.Queries.GetTeacherList
{
    public class GetTeachersQueryHandler : IRequestHandler<GetTeacherListQuery, TeacherListViewModel>
    {
        private readonly IExtraClassesDbContext _context;
        private readonly IMapper _mapper;

        public GetTeachersQueryHandler(IExtraClassesDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TeacherListViewModel> Handle(GetTeacherListQuery request, CancellationToken cancellationToken)
        {
            return new TeacherListViewModel
            {
                Teachers = await _context.Teachers.ProjectTo<TeacherLookupModel>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken)
            };
        }
    }
}
