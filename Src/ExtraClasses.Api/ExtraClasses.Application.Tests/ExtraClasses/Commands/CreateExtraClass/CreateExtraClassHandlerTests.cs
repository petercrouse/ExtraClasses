using ExtraClasses.Application.Exceptions;
using ExtraClasses.Application.ExtraClasses.Commands.CreateExtraClass;
using ExtraClasses.Application.Tests.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ExtraClasses.Application.Tests.ExtraClasses.Commands.CreateExtraClass
{
    public class CreateExtraClassHandlerTests : CommandTestBase
    {
        [Fact]
        public async Task CreateExtraClass_GivenSuccessfulValidation_ShouldThrowTeacherDoesNotTeachSubjectException()
        {
            // Arrange          
            var sut = new CreateExtraClassCommandHandler(_context);
            var name = "Staff logic training";
            var date = new DateTime(2056, 1, 1);
            var duration = new TimeSpan(1, 0, 0);
            var size = 10;
            var subjectId = 2;
            var teacherId = 1;
            var price = 100;

            // Assert
            await Assert.ThrowsAsync<TeacherDoesNotTeachSubjectException>(async () => await sut.Handle(new CreateExtraClassCommand
            {
                Name = name,
                Date = date,
                Duration = duration,
                Size = size,
                SubjectId = subjectId,
                TeacherId = teacherId,
                Price = price
            }, CancellationToken.None));           
        }

        [Fact]
        public async Task CreateExtraClass_GivenSuccessfulValidation_ShouldThrowNotFoundException()
        {
            // Arrange          
            var sut = new CreateExtraClassCommandHandler(_context);
            var name = "Staff logic training";
            var date = new DateTime(2056, 1, 1);
            var duration = new TimeSpan(1, 0, 0);
            var size = 10;
            var subjectId = 2;
            var teacherId = 3;
            var price = 100;

            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () => await sut.Handle(new CreateExtraClassCommand
            {
                Name = name,
                Date = date,
                Duration = duration,
                Size = size,
                SubjectId = subjectId,
                TeacherId = teacherId,
                Price = price
            }, CancellationToken.None));
        }
    }
}
