using ExtraClasses.Api;
using ExtraClasses.Application.Students.Queries.GetStudentList;
using ExtraClasses.WebUI.FunctionalTests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace ExtraClasses.WebUI.FunctionalTests.Controllers.Students
{
    public class GetAll : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public GetAll(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task ReturnsStudentListViewModel()
        {
            var response = await _client.GetAsync("/api/Students/getall");

            response.EnsureSuccessStatusCode();

            var vm = await Utilities.GetResponseContent<StudentListViewModel>(response);

            Assert.IsType<StudentListViewModel>(vm);
            Assert.NotEmpty(vm.Students);
        }
    }
}
