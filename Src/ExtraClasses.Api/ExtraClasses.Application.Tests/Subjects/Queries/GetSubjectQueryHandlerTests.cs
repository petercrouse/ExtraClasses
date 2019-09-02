using ExtraClasses.Application.Subjects.Queries.GetSubject;
using ExtraClasses.Application.Tests.Infrastructure;
using ExtraClasses.Persistence;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ExtraClasses.Application.Tests.Subjects.Queries
{
    [Collection("QueryCollection")]
    public class GetSubjectQueryHandlerTests
    {
        private readonly ExtraClassesDbContext _context;

        public GetSubjectQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
        }

        [Fact]
        public async Task GetSubject()
        {
            var sut = new GetSubjectQueryHandler(_context);

            var result = await sut.Handle(new GetSubjectQuery { Id = 1 }, CancellationToken.None);

            result.ShouldBeOfType<SubjectViewModel>();
            result.Subject.Id.ShouldBe(1);
        }
    }
}
