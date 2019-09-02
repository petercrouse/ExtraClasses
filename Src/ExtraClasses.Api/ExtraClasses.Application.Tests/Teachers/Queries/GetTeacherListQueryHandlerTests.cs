using AutoMapper;
using ExtraClasses.Application.Teachers.Queries.GetTeacherList;
using ExtraClasses.Application.Tests.Infrastructure;
using ExtraClasses.Persistence;
using Shouldly;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ExtraClasses.Application.Tests.Teachers.Queries
{
    [Collection("QueryCollection")]
    public class GetTeacherListQueryHandlerTests
    {
        private readonly ExtraClassesDbContext _context;
        private readonly IMapper _mapper;

        public GetTeacherListQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetTeacherList()
        {
            var sut = new GetTeachersQueryHandler(_context, _mapper);

            var result = await sut.Handle(new GetTeacherListQuery(), CancellationToken.None);

            result.ShouldBeOfType<TeacherListViewModel>();

            result.Teachers.Count().ShouldBe(2);
        }
    }
}
