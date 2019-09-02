using ExtraClasses.Api;
using ExtraClasses.Application.Subjects.Commands.UpdateSubject;
using ExtraClasses.WebUI.FunctionalTests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace ExtraClasses.WebUI.FunctionalTests.Controllers.Subjects
{
    public class Update : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public Update(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GivenUpdateSubjectCommand_ReturnsSuccessStatusCode()
        {
            var command = new UpdateSubjectCommand
            {
                Id = 1,
                Name = "Void Magic"
            };

            var content = Utilities.GetRequestContent(command);

            var response = await _client.PutAsync($"/api/subjects/update/{command.Id}", content);

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GivenUpdateSubjectCommandWithInvalidId_ReturnsNotFoundStatusCode()
        {
            var command = new UpdateSubjectCommand
            {
                Id = 999,
                Name = "Void Magic"
            };

            var content = Utilities.GetRequestContent(command);

            var response = await _client.PutAsync($"/api/subjects/update/{command.Id}", content);

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task GivenUpdateSubjectCommandWithInvalidId_ReturnsBadRequestStatusCode()
        {
            var command = new UpdateSubjectCommand
            {
                Id = -1,
                Name = "Void Magic"
            };

            var content = Utilities.GetRequestContent(command);

            var response = await _client.PutAsync($"/api/subjects/update/{command.Id}", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

    }
}
