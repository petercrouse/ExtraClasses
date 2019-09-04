using ExtraClasses.Api;
using ExtraClasses.Application.Bookings.Queries.GetBookingList;
using ExtraClasses.WebUI.FunctionalTests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace ExtraClasses.WebUI.FunctionalTests.Controllers.Bookings
{
    public class GetAll : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public GetAll(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task ReturnsBookingListViewModel()
        {
            var response = await _client.GetAsync("/api/bookings/getall");

            response.EnsureSuccessStatusCode();

            var vm = await Utilities.GetResponseContent<BookingListViewModel>(response);

            Assert.IsType<BookingListViewModel>(vm);
            Assert.NotEmpty(vm.Bookings);
        }
    }
}
