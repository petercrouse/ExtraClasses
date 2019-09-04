using ExtraClasses.Api;
using ExtraClasses.Application.Bookings.Commands.CreateBooking;
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
    public class Create : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public Create(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GivenCreateBookingCommand_ReturnsSuccessStatusCode()
        {
            var command = new CreateBookingCommand
            {
                ExtraClassId = 1,
                StudentId = 4
            };

            var content = Utilities.GetRequestContent(command);

            var response = await _client.PostAsync($"/api/bookings/create", content);

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GivenCreateBookingCommand_ReturnsBadRequestErrorStatusCode()
        {
            var command = new CreateBookingCommand
            {
                ExtraClassId = 1,
                StudentId = 1
            };

            var content = Utilities.GetRequestContent(command);

            var response = await _client.PostAsync($"/api/bookings/create", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task GivenCreateBookingCommand_ReturnsNotFoundStatusCode()
        {
            var command = new CreateBookingCommand
            {
                ExtraClassId = 999,
                StudentId = 1
            };

            var content = Utilities.GetRequestContent(command);

            var response = await _client.PostAsync($"/api/bookings/create", content);

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task GivenCreateBookingCommand_ReturnsInternalServerErrorStatusCode_ClassIsFull()
        {
            var command = new CreateBookingCommand
            {
                ExtraClassId = 3,
                StudentId = 1
            };

            var content = Utilities.GetRequestContent(command);

            var response = await _client.PostAsync($"/api/bookings/create", content);

            Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
        }
    }
}
