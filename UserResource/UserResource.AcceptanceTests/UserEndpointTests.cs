using System;
using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace UserResource.AcceptanceTests
{
    [TestFixture]
    public class UserEndpointTests
    {
        private HttpClient _client;
        private Uri _sut;

        [OneTimeSetUp]
        public void SetUp()
        {
            _client = new HttpClient(new HttpClientHandler()
            {
                UseDefaultCredentials = true
            });
        }

        [Test]
        public async void DefaultEndpointReturnsAnOkResponse()
        {
            const HttpStatusCode expected = HttpStatusCode.OK;
            _sut = new Uri(Mother.UserBaseEndpointWithPaging);

            var httpResponse = await _client.GetAsync(_sut);
            var actual = httpResponse.StatusCode;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public async void ShouldReturnAPagedListOfUsers()
        {
            _sut = new Uri(Mother.UserBaseEndpointWithPaging);

            var httpResponse = await _client.GetStringAsync(_sut);
            var jsonParsedResult = JArray.Parse(httpResponse);
            var actual = jsonParsedResult.Count;

            Assert.That(actual, Is.GreaterThan(0));
        }

        [Test]
        public async void ShouldUpdateACurrentUser()
        {
            _sut = new Uri(Mother.UserBaseEndpoint);
            var data = new StringContent(Mother.UserPayLoad, Encoding.UTF8, "application/json");

            var expected = Mother.UserId;
            var httpResponse = await _client.PutAsync(_sut, data);
            var contentResult = httpResponse.Content.ReadAsStringAsync().Result;
            var jsonParsedResult = JObject.Parse(contentResult);
            var actual = (int)jsonParsedResult["id"];

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public async void ShouldDeleteACurrentUser()
        {
            _sut = new Uri(Mother.UserBaseEndpoint);

            var expected = Mother.UserId;
            var httpResponse = await _client.DeleteAsync(_sut);
            var contentResult = httpResponse.Content.ReadAsStringAsync().Result;
            var jsonParsedResult = JObject.Parse(contentResult);
            var actual = (int)jsonParsedResult["id"];

            Assert.That(actual, Is.EqualTo(expected));
        }

    }

}