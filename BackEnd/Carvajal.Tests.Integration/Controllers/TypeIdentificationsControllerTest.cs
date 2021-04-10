using Carvajal.Api;
using Carvajal.Api.Dtos;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Xunit;

namespace Carvajal.Tests.Integration.Controllers
{
    public class TypeIdentificationsControllerTest
    {
        [Fact]
        public void GetAll()
        {
            // Arrange
            TestServer server;
            HttpClient client;

            server = new TestServer(WebHost.CreateDefaultBuilder().UseStartup<Startup>().UseEnvironment("Integration"));
            client = server.CreateClient();

            // Act
            var result = client.GetAsync($"api/typeidentifications").Result;
            List<TypeIdentificationDto> typeIdentifications = null;

            if (result.StatusCode == HttpStatusCode.OK)
            {
                typeIdentifications = JsonConvert.DeserializeObject<List<TypeIdentificationDto>>(result.Content.ReadAsStringAsync().Result);
            }

            // Assert
            Assert.True(result.StatusCode == HttpStatusCode.OK);
            Assert.True(typeIdentifications != null);
        }
    }
}
