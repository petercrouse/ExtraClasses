using ExtraClasses.Api;
using ExtraClasses.Application.Teachers.Commands.CreateTeacher;
using ExtraClasses.WebUI.FunctionalTests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace ExtraClasses.WebUI.FunctionalTests.Controllers.Teachers
{
    public class Create : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public Create(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GivenCreateTeacherCommand_ReturnsSuccessStatusCode()
        {
            var command = new CreateTeacherCommand
            {
                LastName = "The One",
                FirstName = "Sauron",
                Email = "stheone@mordor.com"
            };

            var content = Utilities.GetRequestContent(command);

            var response = await _client.PostAsync($"/api/teachers/create", content);

            response.EnsureSuccessStatusCode();
        }
    }
}
