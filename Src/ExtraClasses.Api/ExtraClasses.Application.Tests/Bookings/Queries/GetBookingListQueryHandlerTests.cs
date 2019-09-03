using AutoMapper;
using ExtraClasses.Application.Bookings.Queries.GetBookingList;
using ExtraClasses.Application.Tests.Infrastructure;
using ExtraClasses.Persistence;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ExtraClasses.Application.Tests.Bookings.Queries
{
    [Collection("QueryCollection")]
    public class GetBookingListQueryHandlerTests
    {
        private readonly ExtraClassesDbContext _context;
        private IMapper _mapper;

        public GetBookingListQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetBookingList()
        {
            var sut = new GetBookingsQueryHandler(_context, _mapper);

            var result = await sut.Handle(new GetBookingListQuery(), CancellationToken.None);

            result.ShouldBeOfType<BookingListViewModel>();

            result.Bookings.Count().ShouldBe(4);
        }
    }
}
