using AutoMapper;
using ExtraClasses.Application.Students.Queries.GetStudentList;
using ExtraClasses.Application.Tests.Infrastructure;
using ExtraClasses.Persistence;
using Shouldly;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ExtraClasses.Application.Tests.Students.Queries
{
    [Collection("QueryCollection")]
    public class GetStudentListQueryHandlerTests
    {
        private readonly ExtraClassesDbContext _context;
        private readonly IMapper _mapper;

        public GetStudentListQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetStudentList()
        {
            var sut = new GetStudentsQueryHandler(_context, _mapper);

            var result = await sut.Handle(new GetStudentListQuery(), CancellationToken.None);

            result.ShouldBeOfType<StudentListViewModel>();

            result.Students.Count().ShouldBe(4);
        }
    }
}
