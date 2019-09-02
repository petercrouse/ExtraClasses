using ExtraClasses.Api;
using ExtraClasses.Application.Subjects.Queries.GetSubjects;
using ExtraClasses.WebUI.FunctionalTests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace ExtraClasses.WebUI.FunctionalTests.Controllers.Subjects
{
    public class GetAll : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public GetAll(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task ReturnsSubjectListViewModel()
        {
            var response = await _client.GetAsync("/api/subjects/getall");

            response.EnsureSuccessStatusCode();

            var vm = await Utilities.GetResponseContent<SubjectListViewModel>(response);

            Assert.IsType<SubjectListViewModel>(vm);
            Assert.NotEmpty(vm.Subjects);
        }
    }
}
