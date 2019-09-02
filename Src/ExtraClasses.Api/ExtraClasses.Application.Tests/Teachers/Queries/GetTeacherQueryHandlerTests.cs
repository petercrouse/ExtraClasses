using ExtraClasses.Application.Teachers.Queries.GetTeacher;
using ExtraClasses.Application.Tests.Infrastructure;
using ExtraClasses.Persistence;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ExtraClasses.Application.Tests.Teachers.Queries
{
    [Collection("QueryCollection")]
    public class GetTeacherQueryHandlerTests
    {
        private readonly ExtraClassesDbContext _context;

        public GetTeacherQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
        }

        [Fact]
        public async Task GetTeacher()
        {
            var sut = new GetTeacherQueryHandler(_context);

            var result = await sut.Handle(new GetTeacherQuery { Id = 1 }, CancellationToken.None);

            result.ShouldBeOfType<TeacherDto>();
            result.Id.ShouldBe(1);
        }
    }
}
