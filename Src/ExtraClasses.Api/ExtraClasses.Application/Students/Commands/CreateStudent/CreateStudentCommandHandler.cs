using ExtraClasses.Domain.Entities;
using ExtraClasses.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ExtraClasses.Application.Students.Commands.CreateStudent
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, Unit>
    {
        public CreateStudentCommandHandler(IExtraClassesDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        private readonly IExtraClassesDbContext _context;
        private readonly IMediator _mediator;

        public async Task<Unit> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var entity = new Student
            {
                LastName = request.LastName,
                FirstName = request.FirstName,
                Email = request.Email
            };

            _context.Students.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            await _mediator.Publish(new StudentCreated
            {
                LastName = entity.LastName,
                FirstName = entity.FirstName,
                Email = entity.Email
            }, cancellationToken);

            return Unit.Value;
        }
    }
}
