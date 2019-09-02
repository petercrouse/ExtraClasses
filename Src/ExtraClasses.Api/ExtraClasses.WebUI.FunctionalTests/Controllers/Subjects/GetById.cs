using ExtraClasses.Api;
using ExtraClasses.Application.Subjects.Queries.GetSubject;
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
    public class GetById : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public GetById(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GivenId_ReturnsSubjectDto()
        {
            var id = 1;

            var response = await _client.GetAsync($"/api/subjects/get/{id}");

            response.EnsureSuccessStatusCode();

            var subject = await Utilities.GetResponseContent<SubjectViewModel>(response);

            Assert.Equal(id, subject.Subject.Id);
        }

        [Fact]
        public async Task GivenInvalidId_ReturnsNotFoundStatusCode()
        {
            var invalidId = 999;

            var response = await _client.GetAsync($"/api/subjects/get/{invalidId}");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
