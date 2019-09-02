using ExtraClasses.Application.Exceptions;
using ExtraClasses.Application.ExtraClasses.Commands.UpdateExtraClass;
using ExtraClasses.Application.Tests.Infrastructure;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ExtraClasses.Application.Tests.ExtraClasses.Commands.UpdateExtraClass
{
    public class UpdateExtraClassHandlerTests : CommandTestBase
    {
        [Fact]
        public async Task UpdateExtraClass_GivenSuccessfulValidation_ShouldThrowTeacherDoesNotTeachSubjectException()
        {
            // Arrange          
            var sut = new UpdateExtraClassCommandHandler(_context);
            var id = 1;
            var name = "Staff logic training";
            var date = new DateTime(2056, 1, 1);
            var duration = new TimeSpan(1, 0, 0);
            var size = 10;
            var subjectId = 5;
            var teacherId = 1;
            var price = 100;

            // Assert
            await Assert.ThrowsAsync<TeacherDoesNotTeachSubjectException>(async () => await sut.Handle(new UpdateExtraClassCommand
            {
                Id = 1,
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
        public async Task UpdateExtraClass_GivenSuccessfulValidation_ShouldThrowNotFoundException()
        {
            // Arrange          
            var sut = new UpdateExtraClassCommandHandler(_context);
            var name = "Staff logic training";
            var date = new DateTime(2056, 1, 1);
            var duration = new TimeSpan(1, 0, 0);
            var size = 10;
            var subjectId = 2;
            var teacherId = 3;
            var price = 100;

            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () => await sut.Handle(new UpdateExtraClassCommand
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
