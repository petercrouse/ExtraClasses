using ExtraClasses.Application.Subjects.Commands.CreateSubject;
using ExtraClasses.Application.Tests.Infrastructure;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Xunit;

namespace ExtraClasses.Application.Tests.Subjects.Commands.CreateSubject
{
    public class CreateSubjectCommandTests : CommandTestBase
    {
        [Fact]
        public async void CreateSubjectCommandHandler_ShouldAddSubjectToContext()
        {
            // Arrange
            var sut = new CreateSubjectCommandHandler(_context);
            string name = "StaffLogic";

            // Act
            var result = await sut.Handle(new CreateSubjectCommand { Name = name}, CancellationToken.None);

            // Assert
            _context.Subjects.Where(t => t.Name == name).FirstOrDefault().Name.ShouldBe("StaffLogic");
        }
    }
}
