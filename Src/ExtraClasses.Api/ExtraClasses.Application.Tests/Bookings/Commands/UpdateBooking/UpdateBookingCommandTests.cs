using ExtraClasses.Application.Bookings.Commands.UpdateBooking;
using ExtraClasses.Application.Exceptions;
using ExtraClasses.Application.Tests.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ExtraClasses.Application.Tests.Bookings.Commands.UpdateBooking
{
    public class UpdateBookingCommandTests : CommandTestBase
    {
        [Fact]
        public async Task UpdateBookingCommand_ShouldThrowNotFoundException()
        {
            //Arrange
            var sut = new UpdateBookingCommandHandler(_context);
            var command = new UpdateBookingCommand
            {
                Id = 99,
                ExtraClassId = 1
            };

            //Assert
            await Assert.ThrowsAnyAsync<NotFoundException>(async () => await sut.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task UpdateBookingCommand_ShouldThrowNotFoundException_MissingExtraClass()
        {
            //Arrange
            var sut = new UpdateBookingCommandHandler(_context);
            var command = new UpdateBookingCommand
            {
                Id = 1,
                ExtraClassId = 99
            };

            //Assert
            await Assert.ThrowsAnyAsync<NotFoundException>(async () => await sut.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task UpdateBookingCommand_ShouldThrowDoubleBookingException()
        {
            //Arrange
            var sut = new UpdateBookingCommandHandler(_context);
            var command = new UpdateBookingCommand
            {
                Id = 1,
                ExtraClassId = 3
            };

            //Assert
            await Assert.ThrowsAnyAsync<DoubleBookingException>(async () => await sut.Handle(command, CancellationToken.None));
        }
    }
}
