using AutoMapper;
using AutoMapper.QueryableExtensions;
using ExtraClasses.Application.Teachers.Queries.GetTeacher;
using ExtraClasses.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ExtraClasses.Application.Teachers.Queries.GetTeacherList
{
    public class GetTeachersQueryHandler : IRequestHandler<GetTeacherListQuery, TeacherListViewModel>
    {
        private readonly IExtraClassesDbContext _context;

        public GetTeachersQueryHandler(IExtraClassesDbContext context)
        {
            _context = context;
        }

        public async Task<TeacherListViewModel> Handle(GetTeacherListQuery request, CancellationToken cancellationToken)
        {
            return new TeacherListViewModel
            {
                Teachers = await _context.Teachers.Select(x => TeacherDto.Create(x)).ToListAsync(cancellationToken)
            };
        }
    }
}
