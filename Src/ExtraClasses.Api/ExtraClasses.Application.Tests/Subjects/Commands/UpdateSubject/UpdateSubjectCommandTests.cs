using ExtraClasses.Application.Exceptions;
using ExtraClasses.Application.Subjects.Commands.UpdateSubject;
using ExtraClasses.Application.Tests.Infrastructure;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ExtraClasses.Application.Tests.Subjects.Commands.UpdateSubject
{
    public class UpdateSubjectCommandTests : CommandTestBase
    {
        [Fact]
        public async Task UpdateSubjectCommand_ShouldThrowNotFoundException()
        {
            //Arrange
            var sut = new UpdateSubjectCommandHandler(_context);
            var command = new UpdateSubjectCommand
            {
                Id = 99,
                Name = "VoidMagic"
            };

            //Assert
            await Assert.ThrowsAnyAsync<NotFoundException>(async () => await sut.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task UpdateCustomerCommand_ShouldUpdateSubject()
        {
            //Arrange
            var sut = new UpdateSubjectCommandHandler(_context);
            var command = new UpdateSubjectCommand
            {
                Id = 1,
                Name = "VoidMagic"
            };

            //Act
            _ = await sut.Handle(command, CancellationToken.None);

            //Assert
            _context.Subjects.Find(command.Id).Name.ShouldBe("VoidMagic");
        }
    }
}
