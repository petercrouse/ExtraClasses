using ExtraClasses.Application.Exceptions;
using ExtraClasses.Application.ExtraClasses.Commands.DeleteExtraClass;
using ExtraClasses.Application.Tests.Infrastructure;
using MediatR;
using Moq;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ExtraClasses.Application.Tests.ExtraClasses.Commands.DeleteExtraClass
{
    public class DeleteExtraClassHandlerTests : CommandTestBase
    {
        [Fact]
        public async Task DeleteExtraClassCommandHandler_GivenSuccessfulValidation_ShouldThrowDeleteFailureException()
        {
            //Arrange
            var sut = new DeleteExtraClassCommandHandler(_context);

            // Assert
            await Assert.ThrowsAsync<DeleteFailureException>(async () => await sut.Handle(new DeleteExtraClassCommand { Id = 1 }, CancellationToken.None));
        }

        [Fact]
        public async Task DeleteExtraClass_GivenSuccessfulValidation_ShouldThrowNotFoundException()
        {
            // Arrange     
            var mediatorMock = new Mock<IMediator>();
            var sut = new DeleteExtraClassCommandHandler(_context);            

            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () => await sut.Handle(new DeleteExtraClassCommand { Id = 99 }, CancellationToken.None));
        }
    }
}
