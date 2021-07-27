using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using SwaggerService.Core.Models.V2.Autocomplete;
using SwaggerService.Core.Models.V2.ForwardGeocode;
using SwaggerService.Core.Models.V2.POI;
using SwaggerService.Core.Models.V2.ReverseGeocode;
using SwaggerService.Web;
using Xunit;

namespace SwaggerService.Integration.Test.V2.LocationIQ
{
	public class LocationIQTestCase : IClassFixture<WebApplicationFactory<Startup>>
	{
        public HttpClient _client { get; }

        public LocationIQTestCase(WebApplicationFactory<Startup> fixture)
        {
            _client = fixture.CreateClient();
        }

		[Theory]
        [InlineData(HttpStatusCode.OK, "/V2/ForwardGeocode?q=Empire state", "OK")]
        [InlineData(HttpStatusCode.BadRequest, "/V2/ForwardGeocode?q=", "400")]
        public async Task ForwardGeocode(HttpStatusCode expectedHttpStatusCode, string url, string status)
        {
            var response = await _client.GetAsync(url);
            response.StatusCode.Should().Be(expectedHttpStatusCode);
            var res = JsonConvert.DeserializeObject<ForwardGeocodeResponse>(await response.Content.ReadAsStringAsync());        
            res.Status.Should().Be(status);
        }

        [Theory]
        [InlineData(HttpStatusCode.OK, "/V2/ReverseGeocode?lat=47.3769&lon=8.5417", "OK")]
        [InlineData(HttpStatusCode.BadRequest, "/V2/ReverseGeocode?lat=&lon=", "400")]
        public async Task ReverseGeocode(HttpStatusCode expectedHttpStatusCode, string url, string status)
        {
            var response = await _client.GetAsync(url);
            response.StatusCode.Should().Be(expectedHttpStatusCode);
            var res = JsonConvert.DeserializeObject<ReverseGeocodeResponseObject>(await response.Content.ReadAsStringAsync());        
            res.Status.Should().Be(status);
        }

        [Theory]
        [InlineData(HttpStatusCode.OK, "/V2/Autocomplete?q=Empire state", "OK")]
        [InlineData(HttpStatusCode.BadRequest, "/V2/Autocomplete?q=", "400")]
        public async Task Autocomplete(HttpStatusCode expectedHttpStatusCode, string url, string status)
        {
            var response = await _client.GetAsync(url);
            response.StatusCode.Should().Be(expectedHttpStatusCode);
            var res = JsonConvert.DeserializeObject<AutocompleteResponse>(await response.Content.ReadAsStringAsync());        
            res.Status.Should().Be(status);
        }

        [Theory]
        [InlineData(HttpStatusCode.OK, "/V2/Nearest?coordinates=-0.16102,51.523854", "OK")]
        [InlineData(HttpStatusCode.BadRequest, "/V2/Nearest?coordinates=", "400")]
        public async Task Nearest(HttpStatusCode expectedHttpStatusCode, string url, string status)
        {
            var response = await _client.GetAsync(url);
            response.StatusCode.Should().Be(expectedHttpStatusCode);
        }

        [Theory]
        [InlineData(HttpStatusCode.OK, "/V2/Nearby?lat=46.944&lon=7.4493", "OK")]
        [InlineData(HttpStatusCode.BadRequest, "/V2/Nearby?lat=&lon=", "400")]
        public async Task Nearby(HttpStatusCode expectedHttpStatusCode, string url, string status)
        {
            var response = await _client.GetAsync(url);
            response.StatusCode.Should().Be(expectedHttpStatusCode);
            var res = JsonConvert.DeserializeObject<POIResponse>(await response.Content.ReadAsStringAsync());        
            res.Status.Should().Be(status);
        }



		
	}
		
}
