using ExtraClasses.Api;
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
    public class Delete : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public Delete(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GivenId_ReturnsSuccessStatusCode()
        {
            var validId = 3;

            var response = await _client.DeleteAsync($"/api/teachers/delete/{validId}");

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GivenInvalidId_ReturnsNotFoundStatusCode()
        {
            var invalidId = 999;

            var response = await _client.DeleteAsync($"/api/teachers/delete/{invalidId}");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task GivenId_ReturnsInternalServerErrorStatusCode_BecauseTeacherStillTeachesClasses()
        {
            var validId = 1;

            var response = await _client.DeleteAsync($"/api/teachers/delete/{validId}");

            Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
        }
    }
}
