using ExtraClasses.Api;
using ExtraClasses.Application.Students.Commands.CreateStudent;
using ExtraClasses.WebUI.FunctionalTests.Common;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace ExtraClasses.WebUI.FunctionalTests.Controllers.Students
{
    public class Create : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public Create(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GivenCreateStudentCommand_ReturnsSuccessStatusCode()
        {
            var command = new CreateStudentCommand
            {
                LastName = "Baggins",
                FirstName = "Frodo",
                Email = "fbaggins@theshire.com"
            };

            var content = Utilities.GetRequestContent(command);

            var response = await _client.PostAsync($"/api/Students/create", content);

            response.EnsureSuccessStatusCode();
        }
    }
}
