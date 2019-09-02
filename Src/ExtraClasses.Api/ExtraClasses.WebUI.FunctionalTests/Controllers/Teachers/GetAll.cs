using ExtraClasses.Api;
using ExtraClasses.Application.Teachers.Queries.GetTeacherList;
using ExtraClasses.WebUI.FunctionalTests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace ExtraClasses.WebUI.FunctionalTests.Controllers.Teachers
{
    public class GetAll : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public GetAll(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task ReturnsTeacherListViewModel()
        {
            var response = await _client.GetAsync("/api/teachers/getall");

            response.EnsureSuccessStatusCode();

            var vm = await Utilities.GetResponseContent<TeacherListViewModel>(response);

            Assert.IsType<TeacherListViewModel>(vm);
            Assert.NotEmpty(vm.Teachers);
        }
    }
}
