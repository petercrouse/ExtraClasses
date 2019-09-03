using ExtraClasses.Api;
using ExtraClasses.Application.Students.Queries.GetStudent;
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
    public class GetById : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public GetById(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GivenId_ReturnsStudentViewModel()
        {
            var id = 1;

            var response = await _client.GetAsync($"/api/students/get/{id}");

            response.EnsureSuccessStatusCode();

            var student = await Utilities.GetResponseContent<StudentViewModel>(response);

            Assert.Equal(id, student.Student.Id);
        }

        [Fact]
        public async Task GivenInvalidId_ReturnsNotFoundStatusCode()
        {
            var invalidId = 999;

            var response = await _client.GetAsync($"/api/students/get/{invalidId}");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
