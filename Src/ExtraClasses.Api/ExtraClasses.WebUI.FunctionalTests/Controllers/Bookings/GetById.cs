using ExtraClasses.Api;
using ExtraClasses.Application.Bookings.Queries.GetBooking;
using ExtraClasses.WebUI.FunctionalTests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace ExtraClasses.WebUI.FunctionalTests.Controllers.Bookings
{
    public class GetById : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public GetById(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GivenId_ReturnsBookingViewModel()
        {
            var id = 1;

            var response = await _client.GetAsync($"/api/bookings/get/{id}");

            response.EnsureSuccessStatusCode();

            var Booking = await Utilities.GetResponseContent<BookingViewModel>(response);

            Assert.Equal(id, Booking.Booking.Id);
        }

        [Fact]
        public async Task GivenInvalidId_ReturnsNotFoundStatusCode()
        {
            var invalidId = 999;

            var response = await _client.GetAsync($"/api/bookings/get/{invalidId}");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
