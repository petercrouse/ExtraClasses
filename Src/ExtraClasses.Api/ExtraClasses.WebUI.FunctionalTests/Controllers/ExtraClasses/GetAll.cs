using ExtraClasses.Api;
using ExtraClasses.Application.ExtraClasses.Queries.GetExtraClassList;
using ExtraClasses.WebUI.FunctionalTests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace ExtraClasses.WebUI.FunctionalTests.Controllers.ExtraClasses
{
    public class GetAll : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public GetAll(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task ReturnsExtraClassListViewModel()
        {
            var response = await _client.GetAsync("/api/extraclasses/getall");

            response.EnsureSuccessStatusCode();

            var vm = await Utilities.GetResponseContent<ExtraClassListViewModel>(response);

            Assert.IsType<ExtraClassListViewModel>(vm);
            Assert.NotEmpty(vm.ExtraClasses);
        }
    }
}
