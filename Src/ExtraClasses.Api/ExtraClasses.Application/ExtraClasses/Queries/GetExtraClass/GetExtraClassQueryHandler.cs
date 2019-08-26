using AutoMapper;
using ExtraClasses.Application.Exceptions;
using ExtraClasses.Domain.Entities;
using ExtraClasses.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
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
            var extraClass = _mapper.Map<ExtraClassViewModel>(await _context.ExtraClasses.FindAsync(request.Id));

            if (extraClass == null)
            {
                throw new NotFoundException(nameof(ExtraClass), request.Id);
            }

            return extraClass;
        }
    }
}
