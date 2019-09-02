using ExtraClasses.Api;
using ExtraClasses.Application.Students.Commands.UpdateStudent;
using ExtraClasses.WebUI.FunctionalTests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace ExtraClasses.WebUI.FunctionalTests.Controllers.Students
{
    public class Update : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public Update(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GivenUpdateStudentCommand_ReturnsSuccessStatusCode()
        {
            var command = new UpdateStudentCommand
            {
                Id = 1,
                LastName = "Gobblin",
                FirstName = "Frodo",
                Email = "fGobblin@mordor.com"
            };

            var content = Utilities.GetRequestContent(command);

            var response = await _client.PutAsync($"/api/students/update/{command.Id}", content);

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GivenUpdateStudentCommandWithInvalidId_ReturnsNotFoundStatusCode()
        {
            var command = new UpdateStudentCommand
            {
                Id = 99,
                LastName = "Gobblin",
                FirstName = "Frodo",
                Email = "fGobblin@mordor.com"
            };

            var content = Utilities.GetRequestContent(command);

            var response = await _client.PutAsync($"/api/students/update/{command.Id}", content);

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task GivenUpdateStudentCommandWithInvalidId_ReturnsBadRequestStatusCode()
        {
            var command = new UpdateStudentCommand
            {
                Id = -1,
                LastName = "Gobblin",
                FirstName = "Frodo",
                Email = "fGobblin@mordor.com"
            };

            var content = Utilities.GetRequestContent(command);

            var response = await _client.PutAsync($"/api/students/update/{command.Id}", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

    }
}
