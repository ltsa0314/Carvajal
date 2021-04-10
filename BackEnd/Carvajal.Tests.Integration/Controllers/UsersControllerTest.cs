using AutoMapper;
using Carvajal.Api;
using Carvajal.Api.Dtos;
using Carvajal.Api.Helpers.AutoMapper;
using Carvajal.Domain.Models;
using Carvajal.Infraestructure.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using Xunit;

namespace Carvajal.Tests.Integration.Controllers
{
    public class UsersControllerTest
    {        

        [Fact]
        public void Insert()
        {
            // Arrange
            TestServer server;
            HttpClient client;

            server = new TestServer(WebHost.CreateDefaultBuilder().UseStartup<Startup>().UseEnvironment("Integration"));
            client = server.CreateClient();

            var model = new UserDto
            {
                Name = "Leidy Tatina",
                LastName = "Sanchez Arevalo",
                TypeIdentificationId = 1,
                Identification = "1110544973",
                Email = "ltsa0314@gmail.com",
                Password = "Tatiana@2021"
            };

            // Act
            var json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var result = client.PostAsync($"api/users", content).Result;

            UserDto user = null;

            if (result.StatusCode == HttpStatusCode.OK)
            {
                user = JsonConvert.DeserializeObject<UserDto>(result.Content.ReadAsStringAsync().Result);
            }

            // Assert
            Assert.True(result.StatusCode == HttpStatusCode.OK);
            Assert.True(user != null);
            Assert.True(user.Id > 0);
            Assert.True(user.Name == "Leidy Tatina");
            Assert.True(user.LastName == "Sanchez Arevalo");
            Assert.True(user.TypeIdentificationId == 1);
            Assert.True(user.Identification == "1110544973");
            Assert.True(user.Email == "ltsa0314@gmail.com");
            Assert.True(user.Password == "Tatiana@2021");
        }
    }
}
