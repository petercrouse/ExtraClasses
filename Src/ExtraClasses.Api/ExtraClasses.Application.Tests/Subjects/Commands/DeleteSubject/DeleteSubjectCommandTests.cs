using ExtraClasses.Application.Exceptions;
using ExtraClasses.Application.Subjects.Commands.DeleteSubject;
using ExtraClasses.Application.Tests.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace ExtraClasses.Application.Tests.Subjects.Commands.DeleteSubject
{
    public class DeleteSubjectCommandTests : CommandTestBase
    {
        [Fact]
        public async void DeleteSubjectCommand_ShouldThrowDeleteFailureException()
        {
            //Arrange
            var sut = new DeleteSubjectCommandHandler(_context);
            var command = new DeleteSubjectCommand { Id = 1 };

            //Assert
            await Assert.ThrowsAsync<DeleteFailureException>(async () => await sut.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async void DeleteSubjectCommand_ShouldThrowNotFoundException()
        {
            //Arrange
            var sut = new DeleteSubjectCommandHandler(_context);
            var command = new DeleteSubjectCommand { Id = 99 };

            //Assert
            await Assert.ThrowsAnyAsync<NotFoundException>(async () => await sut.Handle(command, CancellationToken.None));
        }
    }
}
