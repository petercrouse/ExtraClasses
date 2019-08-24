using ExtraClasses.Application.Students.Commands.CreateStudent;
using ExtraClasses.Application.Tests.Infrastructure;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace ExtraClasses.Application.Tests.Students.Commands.CreateStudent
{
    public class CreateStudentCommandTests : CommandTestBase
    {
        [Fact]
        public async void CreateStudentCommandHandler_ShouldRaiseStudentCreatedNotification()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();
            var sut = new CreateStudentCommandHandler(_context, mediatorMock.Object);
            var firstName = "Merry";
            var lastName = "Brandybuck";
            var email = "mbrandybuck@theshire.com";

            // Act
            var result = await sut.Handle(new CreateStudentCommand {
                FirstName = firstName,
                LastName = lastName,
                Email = email
            }, CancellationToken.None);

            // Assert
            mediatorMock.Verify(m => m.Publish(It.Is<StudentCreated>(sc => sc.FirstName == firstName), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
