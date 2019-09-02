using ExtraClasses.Application.Exceptions;
using ExtraClasses.Application.Teachers.Commands.UpdateTeacher;
using ExtraClasses.Application.Tests.Infrastructure;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ExtraClasses.Application.Tests.Teachers.Commands.UpdateTeacher
{
    public class UpdateTeacherCommandTests : CommandTestBase
    {
        [Fact]
        public async Task UpdateTeacherCommand_ShouldThrowNotFoundException()
        {
            //Arrange
            var sut = new UpdateTeacherCommandHandler(_context);
            var command = new UpdateTeacherCommand
            {
                Id = 99,
                LastName = "The White"
            };

            //Assert
            await Assert.ThrowsAnyAsync<NotFoundException>(async () => await sut.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task UpdateTeacherCommand_ShouldUpdateTeacher()
        {
            //Arrange
            var sut = new UpdateTeacherCommandHandler(_context);
            var command = new UpdateTeacherCommand
            {
                Id = 1,
                LastName = "The White",
                FirstName = "Gandalf",
                Email = ""
            };

            //Act
            _ = await sut.Handle(command, CancellationToken.None);

            //Assert
            _context.Teachers.Find(command.Id).LastName.ShouldBe("The White");
        }
    }
}
