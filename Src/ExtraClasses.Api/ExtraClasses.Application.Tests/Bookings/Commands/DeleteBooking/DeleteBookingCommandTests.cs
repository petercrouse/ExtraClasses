using ExtraClasses.Application.Bookings.Commands.DeleteBooking;
using ExtraClasses.Application.Exceptions;
using ExtraClasses.Application.Tests.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace ExtraClasses.Application.Tests.Bookings.Commands.DeleteBooking
{
    public class DeleteBookingCommandTests: CommandTestBase
    {
        [Fact]
        public async void DeleteBookingCommand_ShouldThrowNotFoundException()
        {
            //Arrange
            var sut = new DeleteBookingCommandHandler(_context);
            var command = new DeleteBookingCommand { Id = 99 };

            //Assert
            await Assert.ThrowsAnyAsync<NotFoundException>(async () => await sut.Handle(command, CancellationToken.None));
        }
    }
}
