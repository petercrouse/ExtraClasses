using ExtraClasses.Application.Exceptions;
using ExtraClasses.Application.Students.Commands.DeleteStudent;
using ExtraClasses.Application.Tests.Infrastructure;
using MediatR;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace ExtraClasses.Application.Tests.Students.Commands.DeleteStudent
{
    public class DeleteStudentCommandTests : CommandTestBase
    {
        [Fact]
        public async void DeleteStudentCommand_ShouldThrowDeleteFailureException()
        {
            //Arrange
            var sut = new DeleteStudentCommandHandler(_context);
            var command = new DeleteStudentCommand { Id = 1 };

            //Assert
            await Assert.ThrowsAsync<DeleteFailureException>(async () => await sut.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async void DeleteStudentCommand_ShouldThrowNotFoundException()
        { 
            //Arrange
            var sut = new DeleteStudentCommandHandler(_context);
            var command = new DeleteStudentCommand { Id = 99 };

            //Assert
            await Assert.ThrowsAnyAsync<NotFoundException>(async () => await sut.Handle(command, CancellationToken.None));
        }
    }
}
