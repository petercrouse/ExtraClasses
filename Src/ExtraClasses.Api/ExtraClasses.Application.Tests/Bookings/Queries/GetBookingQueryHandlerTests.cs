using AutoMapper;
using ExtraClasses.Application.Bookings.Queries.GetBooking;
using ExtraClasses.Application.Exceptions;
using ExtraClasses.Application.Tests.Infrastructure;
using ExtraClasses.Persistence;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ExtraClasses.Application.Tests.Bookings.Queries
{
    [Collection("QueryCollection")]
    public class GetBookingQueryHandlerTests
    {
        private readonly ExtraClassesDbContext _context;
        private readonly IMapper _mapper;

        public GetBookingQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetBooking()
        {
            var sut = new GetBookingQueryHandler(_context, _mapper);

            var result = await sut.Handle(new GetBookingQuery { Id = 1 }, CancellationToken.None);

            result.ShouldBeOfType<BookingViewModel>();
            result.Booking.Id.ShouldBe(1);
            result.Booking.ExtraClassName.ShouldBe("How to be a wizzard");
        }

        [Fact]
        public async Task GetBooking_ShouldThrowNotFoundException()
        {
            var sut = new GetBookingQueryHandler(_context, _mapper);

            //Assert
            await Assert.ThrowsAnyAsync<NotFoundException>(async () => await sut.Handle(new GetBookingQuery { Id = 99 }, CancellationToken.None));
        }
    }
}
