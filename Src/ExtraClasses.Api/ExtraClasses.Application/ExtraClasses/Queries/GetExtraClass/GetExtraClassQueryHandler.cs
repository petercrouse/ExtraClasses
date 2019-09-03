using AutoMapper;
using ExtraClasses.Application.Exceptions;
using ExtraClasses.Domain.Entities;
using ExtraClasses.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ExtraClasses.Application.ExtraClasses.Queries.GetExtraClass
{
    public class GetExtraClassQueryHandler : IRequestHandler<GetExtraClassQuery, ExtraClassViewModel>
    {
        private readonly IExtraClassesDbContext _context;
        private readonly IMapper _mapper;

        public GetExtraClassQueryHandler(IExtraClassesDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ExtraClassViewModel> Handle(GetExtraClassQuery request, CancellationToken cancellationToken)
        {
            var extraClass = _mapper.Map<ExtraClassDto>(await _context.ExtraClasses.Where(c => c.ExtraClassId == request.Id)
                                                                                         .Include(t => t.Teacher)
                                                                                         .Include(s => s.Subject)
                                                                                         .FirstOrDefaultAsync(cancellationToken));

            if (extraClass == null)
            {
                throw new NotFoundException(nameof(ExtraClass), request.Id);
            }

            return new ExtraClassViewModel
            {
                ExtraClass = extraClass
            };
        }
    }
}
