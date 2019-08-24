using ExtraClasses.Application.Exceptions;
using ExtraClasses.Application.Teachers.Commands.DeleteTeacher;
using ExtraClasses.Application.Tests.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace ExtraClasses.Application.Tests.Teachers.Commands.DeleteTeacher
{
    public class DeleteTeacherCommandTests : CommandTestBase
    {
        [Fact]
        public async void DeleteTeacherCommand_ShouldThrowDeleteFailureException()
        {
            //Arrange
            var sut = new DeleteTeacherCommandHandler(_context);
            var command = new DeleteTeacherCommand { Id = 1 };

            //Assert
            await Assert.ThrowsAsync<DeleteFailureException>(async () => await sut.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async void DeleteTeacherCommand_ShouldThrowNotFoundException()
        {
            //Arrange
            var sut = new DeleteTeacherCommandHandler(_context);
            var command = new DeleteTeacherCommand { Id = 99 };

            //Assert
            await Assert.ThrowsAnyAsync<NotFoundException>(async () => await sut.Handle(command, CancellationToken.None));
        }
    }
}
