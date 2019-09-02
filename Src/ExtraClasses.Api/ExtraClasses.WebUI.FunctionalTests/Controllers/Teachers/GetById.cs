using ExtraClasses.Api;
using ExtraClasses.Application.Teachers.Queries.GetTeacher;
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
    public class GetById : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public GetById(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GivenId_ReturnsTeacherDto()
        {
            var id = 1;

            var response = await _client.GetAsync($"/api/teachers/get/{id}");

            response.EnsureSuccessStatusCode();

            var Teacher = await Utilities.GetResponseContent<TeacherDto>(response);

            Assert.Equal(id, Teacher.Id);
        }

        [Fact]
        public async Task GivenInvalidId_ReturnsNotFoundStatusCode()
        {
            var invalidId = 999;

            var response = await _client.GetAsync($"/api/teachers/get/{invalidId}");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
