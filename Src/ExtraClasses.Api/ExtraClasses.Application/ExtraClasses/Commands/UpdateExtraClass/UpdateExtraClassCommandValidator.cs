using ExtraClasses.Common;
using ExtraClasses.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ExtraClasses.Application.ExtraClasses.Commands.UpdateExtraClass
{
    public class UpdateExtraClassCommandValidator : AbstractValidator<UpdateExtraClassCommand>
    {
        private readonly IExtraClassesDbContext _context;

        public UpdateExtraClassCommandValidator(IDateTime dateTime, IExtraClassesDbContext context)
        {
            _context = context;

            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Date).GreaterThanOrEqualTo(dateTime.Now);
            RuleFor(x => x.Size).MustAsync(ValidSizeAsync).WithMessage("The class will be too small for the amount of students that are currently booked.");
            RuleFor(x => x.Duration).GreaterThanOrEqualTo(new TimeSpan(0, 30, 0));
            RuleFor(x => x.Price).GreaterThanOrEqualTo(0);
            RuleFor(x => x.SubjectId).NotNull();
        }

        private async Task<bool> ValidSizeAsync(UpdateExtraClassCommand command ,int size, CancellationToken cancellationToken)
        {
            var extraclass = await _context.ExtraClasses.Where(c => c.ExtraClassId == command.Id)
                .Include(b => b.Bookings).FirstOrDefaultAsync(cancellationToken);

            return extraclass.Bookings.Count < size;
        }

    }
}
