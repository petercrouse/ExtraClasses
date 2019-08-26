using ExtraClasses.Application.Exceptions;
using ExtraClasses.Domain.Entities;
using ExtraClasses.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExtraClasses.Application.ExtraClasses.Commands.DeleteExtraClass
{
    public class DeleteExtraClassCommandHandler : IRequestHandler<DeleteExtraClassCommand, Unit>
    {
        private readonly IExtraClassesDbContext _context;
        private readonly IMediator _mediator;

        public DeleteExtraClassCommandHandler(IExtraClassesDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(DeleteExtraClassCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ExtraClasses.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ExtraClass), request.Id);
            }

            var bookings = entity.Bookings.ToList();

            _context.ExtraClasses.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            await _mediator.Publish(new ExtraClassDeleted { Bookings = bookings }, cancellationToken);

            return Unit.Value;
        }
    }
}
