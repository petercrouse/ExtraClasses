using ExtraClasses.Api;
using ExtraClasses.Application.Subjects.Commands.CreateSubject;
using ExtraClasses.WebUI.FunctionalTests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace ExtraClasses.WebUI.FunctionalTests.Controllers.Subjects
{
    public class Create : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public Create(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GivenCreateSubjectCommand_ReturnsSuccessStatusCode()
        {
            var command = new CreateSubjectCommand
            {
                Name = "Dark Magic"
            };

            var content = Utilities.GetRequestContent(command);

            var response = await _client.PostAsync($"/api/subjects/create", content);

            response.EnsureSuccessStatusCode();
        }
    }
}
