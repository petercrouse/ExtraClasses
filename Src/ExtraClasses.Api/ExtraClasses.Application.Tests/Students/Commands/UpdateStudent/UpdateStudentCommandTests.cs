using ExtraClasses.Application.Exceptions;
using ExtraClasses.Application.Students.Commands.UpdateStudent;
using ExtraClasses.Application.Tests.Infrastructure;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ExtraClasses.Application.Tests.Students.Commands.UpdateStudent
{
    public class UpdateStudentCommandTests : CommandTestBase
    {
        [Fact]
        public async Task UpdateStudentCommand_ShouldThrowNotFoundException()
        {
            //Arrange
            var sut = new UpdateStudentCommandHandler(_context);
            var command = new UpdateStudentCommand {
                Id = 99,
                LastName = "Smeegol"
            };

            //Assert
            await Assert.ThrowsAnyAsync<NotFoundException>(async () => await sut.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task UpdateCustomerCommand_ShouldUpdateStudent()
        {
            //Arrange
            var sut = new UpdateStudentCommandHandler(_context);
            var command = new UpdateStudentCommand
            {
                Id = 1,
                LastName = "Smeegol",
                FirstName = "Frodo",
                Email = ""
            };

            //Act
            _ = await sut.Handle(command, CancellationToken.None);

            //Assert
            _context.Students.Find(command.Id).LastName.ShouldBe("Smeegol");
        }
    }
}
