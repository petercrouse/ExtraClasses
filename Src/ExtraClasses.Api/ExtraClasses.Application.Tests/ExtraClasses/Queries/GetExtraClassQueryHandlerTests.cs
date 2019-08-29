using AutoMapper;
using ExtraClasses.Application.ExtraClasses.Queries.GetExtraClass;
using ExtraClasses.Application.Tests.Infrastructure;
using ExtraClasses.Persistence;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ExtraClasses.Application.Tests.ExtraClasses.Queries
{
    [Collection("QueryCollection")]
    public class GetExtraClassQueryHandlerTests
    {
        private readonly ExtraClassesDbContext _context;
        private readonly IMapper _mapper;

        public GetExtraClassQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetExtraClass()
        {
            var sut = new GetExtraClassQueryHandler(_context, _mapper);

            var result = await sut.Handle(new GetExtraClassQuery { Id = 1 }, CancellationToken.None);

            result.ShouldBeOfType<ExtraClassViewModel>();
            result.Id.ShouldBe(1);
        }
    }
}
