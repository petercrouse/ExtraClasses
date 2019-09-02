using ExtraClasses.Api;
using ExtraClasses.Application.Teachers.Commands.UpdateTeacher;
using ExtraClasses.WebUI.FunctionalTests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace ExtraClasses.WebUI.FunctionalTests.Controllers.Teachers
{
    public class Update : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public Update(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GivenUpdateTeacherCommand_ReturnsSuccessStatusCode()
        {
            var command = new UpdateTeacherCommand
            {
                Id = 1,
                LastName = "The White",
                FirstName = "Gandalf",
                Email = "gthewhite@wizzardcouncil.com"
            };

            var content = Utilities.GetRequestContent(command);

            var response = await _client.PutAsync($"/api/teachers/update/{command.Id}", content);

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GivenUpdateTeacherCommandWithInvalidId_ReturnsNotFoundStatusCode()
        {
            var command = new UpdateTeacherCommand
            {
                Id = 999,
                LastName = "The White",
                FirstName = "Gandalf",
                Email = "gthewhite@wizzardcouncil.com"
            };

            var content = Utilities.GetRequestContent(command);

            var response = await _client.PutAsync($"/api/teachers/update/{command.Id}", content);

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task GivenUpdateTeacherCommandWithInvalidId_ReturnsBadRequestStatusCode()
        {
            var command = new UpdateTeacherCommand
            {
                Id = -1,
                LastName = "The White",
                FirstName = "Gandalf",
                Email = "gthewhite@wizzardcouncil.com"
            };

            var content = Utilities.GetRequestContent(command);

            var response = await _client.PutAsync($"/api/teachers/update/{command.Id}", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

    }
}
