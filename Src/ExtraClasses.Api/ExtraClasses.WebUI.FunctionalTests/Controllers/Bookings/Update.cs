using ExtraClasses.Api;
using ExtraClasses.Application.Bookings.Commands.UpdateBooking;
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
    public class Update : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public Update(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GivenUpdateBookingCommand_ReturnsSuccessStatusCode()
        {
            var command = new UpdateBookingCommand
            {
                Id = 1,
                ExtraClassId = 2,
                Paid = true,
                Price = 100
            };

            var content = Utilities.GetRequestContent(command);

            var response = await _client.PutAsync($"/api/Bookings/update/{command.Id}", content);

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GivenUpdateBookingCommandWithInvalidId_ReturnsNotFoundStatusCode()
        {
            var command = new UpdateBookingCommand
            {
                Id = 999,
                ExtraClassId = 2,
                Paid = true,
                Price = 100
            };

            var content = Utilities.GetRequestContent(command);

            var response = await _client.PutAsync($"/api/Bookings/update/{command.Id}", content);

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task GivenUpdateBookingCommandWithValidId_ReturnsNotFoundStatusCode_ExtraClassIsNotFound()
        {
            var command = new UpdateBookingCommand
            {
                Id = 1,
                ExtraClassId = 999,
                Paid = true,
                Price = 100
            };

            var content = Utilities.GetRequestContent(command);

            var response = await _client.PutAsync($"/api/Bookings/update/{command.Id}", content);

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task GivenUpdateBookingCommandWithValidId_ReturnsBadRequestStatusCode()
        {
            var command = new UpdateBookingCommand
            {
                Id = 1,
                ExtraClassId = 1,
                Paid = true,
                Price = 100
            };

            var content = Utilities.GetRequestContent(command);

            var response = await _client.PutAsync($"/api/Bookings/update/{command.Id}", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

    }
}
