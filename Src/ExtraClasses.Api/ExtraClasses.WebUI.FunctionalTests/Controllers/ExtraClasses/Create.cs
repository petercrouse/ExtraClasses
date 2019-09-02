using ExtraClasses.Api;
using ExtraClasses.Application.ExtraClasses.Commands.CreateExtraClass;
using ExtraClasses.WebUI.FunctionalTests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace ExtraClasses.WebUI.FunctionalTests.Controllers.ExtraClasses
{
    public class Create : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public Create(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GivenCreateExtraClassCommand_ReturnsSuccessStatusCode()
        {
            var command = new CreateExtraClassCommand
            {
                TeacherId = 1,
                SubjectId = 1,
                Size = 4,
                Duration = new TimeSpan(60, 00, 00),
                Price = 100,
                Date = new DateTime(2555, 1, 1),
                Name = "Wizzard Stance"
            };

            var content = Utilities.GetRequestContent(command);

            var response = await _client.PostAsync($"/api/extraclasses/create", content);

            response.EnsureSuccessStatusCode();
        }
    }
}
