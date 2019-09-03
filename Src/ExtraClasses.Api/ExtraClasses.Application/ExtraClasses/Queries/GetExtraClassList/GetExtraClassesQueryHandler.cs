using AutoMapper;
using AutoMapper.QueryableExtensions;
using ExtraClasses.Application.ExtraClasses.Queries.GetExtraClass;
using ExtraClasses.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace ExtraClasses.Application.ExtraClasses.Queries.GetExtraClassList
{
    public class GetExtraClassesQueryHandler : IRequestHandler<GetExtraClassListQuery, ExtraClassListViewModel>
    {
        private readonly IExtraClassesDbContext _context;
        private readonly IMapper _mapper;

        public GetExtraClassesQueryHandler(IExtraClassesDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ExtraClassListViewModel> Handle(GetExtraClassListQuery request, CancellationToken cancellationToken)
        {
            return new ExtraClassListViewModel
            {
                ExtraClasses = await _context.ExtraClasses.ProjectTo<ExtraClassDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken)
            };
        }
    }
}
