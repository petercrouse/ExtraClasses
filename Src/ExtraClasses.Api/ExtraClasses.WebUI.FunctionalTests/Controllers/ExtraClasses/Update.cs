using ExtraClasses.Api;
using ExtraClasses.Application.ExtraClasses.Commands.UpdateExtraClass;
using ExtraClasses.WebUI.FunctionalTests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace ExtraClasses.WebUI.FunctionalTests.Controllers.ExtraClasses
{
    public class Update : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public Update(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GivenUpdateExtraClassCommand_ReturnsSuccessStatusCode()
        {
            var command = new UpdateExtraClassCommand
            {
                Id = 1,
                TeacherId = 1,
                SubjectId = 2,
                Size = 4,
                Duration = new TimeSpan(60, 00, 00),
                Price = 100,
                Date = new DateTime(2555, 1, 1),
                Name = "Wizzard Stance"
            };

            var content = Utilities.GetRequestContent(command);

            var response = await _client.PutAsync($"/api/extraclasses/update/{command.Id}", content);

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GivenUpdateExtraClassCommandWithInvalidId_ReturnsNotFoundStatusCode()
        {
            var command = new UpdateExtraClassCommand
            {
                Id = 999,
                TeacherId = 1,
                SubjectId = 1,
                Size = 4,
                Duration = new TimeSpan(60, 00, 00),
                Price = 100,
                Date = new DateTime(2555, 1, 1),
                Name = "Wizzard Stance"
            };

            var content = Utilities.GetRequestContent(command);

            var response = await _client.PutAsync($"/api/extraclasses/update/{command.Id}", content);

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task GivenUpdateExtraClassCommandWithInvalidId_ReturnsBadRequestStatusCode()
        {
            var command = new UpdateExtraClassCommand
            {
                Id = -1,
                TeacherId = 1,
                SubjectId = 1,
                Size = 4,
                Duration = new TimeSpan(60, 00, 00),
                Price = 100,
                Date = new DateTime(2555, 1, 1),
                Name = "Wizzard Stance"
            };

            var content = Utilities.GetRequestContent(command);

            var response = await _client.PutAsync($"/api/extraclasses/update/{command.Id}", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task GivenUpdateExtraClassCommandWithValidId_ReturnsNotFoundStatusCode_ForTeacherNotFound()
        {
            var command = new UpdateExtraClassCommand
            {
                Id = 1,
                TeacherId = 999,
                SubjectId = 1,
                Size = 4,
                Duration = new TimeSpan(60, 00, 00),
                Price = 100,
                Date = new DateTime(2555, 1, 1),
                Name = "Wizzard Stance"
            };

            var content = Utilities.GetRequestContent(command);

            var response = await _client.PutAsync($"/api/extraclasses/update/{command.Id}", content);

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

    }
}
