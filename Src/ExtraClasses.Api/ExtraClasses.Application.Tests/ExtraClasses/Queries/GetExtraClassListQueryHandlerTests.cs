using AutoMapper;
using ExtraClasses.Application.ExtraClasses.Queries.GetExtraClassList;
using ExtraClasses.Application.Tests.Infrastructure;
using ExtraClasses.Persistence;
using Shouldly;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ExtraClasses.Application.Tests.ExtraClasses.Queries
{
    [Collection("QueryCollection")]
    public class GetExtraClassListQueryHandlerTests
    {
        private readonly ExtraClassesDbContext _context;
        private readonly IMapper _mapper;

        public GetExtraClassListQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetExtraClassesList()
        {
            var sut = new GetExtraClassesQueryHandler(_context, _mapper);

            var result = await sut.Handle(new GetExtraClassListQuery(), CancellationToken.None);

            result.ShouldBeOfType<ExtraClassListViewModel>();

            result.ExtraClasses.Count().ShouldBe(3);
        }
    }
}
