using ExtraClasses.Application.Students.Queries.GetStudent;
using ExtraClasses.Application.Tests.Infrastructure;
using ExtraClasses.Persistence;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ExtraClasses.Application.Tests.Students.Queries
{
    [Collection("QueryCollection")]
    public class GetStudentQueryHandlerTests
    {
        private readonly ExtraClassesDbContext _context;

        public GetStudentQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
        }

        [Fact]
        public async Task GetStudent()
        {
            var sut = new GetStudentQueryHandler(_context);

            var result = await sut.Handle(new GetStudentQuery { Id = 1 }, CancellationToken.None);

            result.ShouldBeOfType<StudentDto>();
            result.Id.ShouldBe(1);
        }
    }
}
