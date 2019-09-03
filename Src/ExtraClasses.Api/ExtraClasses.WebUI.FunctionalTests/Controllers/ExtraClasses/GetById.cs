using ExtraClasses.Api;
using ExtraClasses.Application.ExtraClasses.Queries.GetExtraClass;
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
    public class GetById : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public GetById(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GivenId_ReturnsExtraClassDto()
        {
            var id = 1;

            var response = await _client.GetAsync($"/api/extraclasses/get/{id}");

            response.EnsureSuccessStatusCode();

            var ExtraClass = await Utilities.GetResponseContent<ExtraClassViewModel>(response);

            Assert.Equal(id, ExtraClass.ExtraClass.Id);
        }

        [Fact]
        public async Task GivenInvalidId_ReturnsNotFoundStatusCode()
        {
            var invalidId = 999;

            var response = await _client.GetAsync($"/api/extraclasses/get/{invalidId}");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
