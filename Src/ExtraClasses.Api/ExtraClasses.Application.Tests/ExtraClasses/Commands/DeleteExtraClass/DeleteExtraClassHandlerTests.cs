using ExtraClasses.Application.Exceptions;
using ExtraClasses.Application.ExtraClasses.Commands.DeleteExtraClass;
using ExtraClasses.Application.Tests.Infrastructure;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ExtraClasses.Application.Tests.ExtraClasses.Commands.DeleteExtraClass
{
    public class DeleteExtraClassHandlerTests : CommandTestBase
    {
        [Fact]
        public async Task DeleteExtraClassCommandHandler_ShouldRaiseExtraClassDeletedNotificationAsync()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();
            var sut = new DeleteExtraClassCommandHandler(_context, mediatorMock.Object);            

            // Act
            var result = await sut.Handle(new DeleteExtraClassCommand { Id = 1 }, CancellationToken.None);

            // Assert
            mediatorMock.Verify(m => m.Publish(It.Is<ExtraClassDeleted>(ed => ed.Bookings.FirstOrDefault().ExtraClassId == 1), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task DeleteExtraClass_GivenSuccessfulValidation_ShouldThrowNotFoundException()
        {
            // Arrange     
            var mediatorMock = new Mock<IMediator>();
            var sut = new DeleteExtraClassCommandHandler(_context, mediatorMock.Object);            

            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () => await sut.Handle(new DeleteExtraClassCommand { Id = 99 }, CancellationToken.None));
        }
    }
}
