using System;
using System.Collections.Generic;
using System.Net;
using System.Transactions;
using Forum.WebAPI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Forum.Tests
{
    [TestClass]
    public class UsersControllerIntegrationTests
    {
        static TransactionScope tran;
        private InMemoryHttpServer httpServer;

        [TestInitialize]
        public void TestInit()
        {
            tran = new TransactionScope();
            var routes = new List<Route>()
            {
                new Route( 
                    "UsersApi",
                    "api/users/{action}",
                    new{controller = "users"})
                //new Route( 
                //    "DefaultApi"
                //    "api/{controller}/{id}",
                //    new { id = RouteParameter.Optional }),
            };

            this.httpServer = new InMemoryHttpServer("http://localhost/", routes);
        }

        [TestCleanup]
        public void TearDown()
        {
            tran.Dispose();
        }

        [TestMethod]
        public void GetAll_When()
        {
            var response = httpServer.Get("api/threads");
        }

        [TestMethod]
        public void Register_WhenUserModelValid_ShouldSaveToDatabase()
        {
            var testUser = new UserModel()
            {
                Username = "VALIDUSER",
                Nickname = "VALIDNICK",
                AuthCode = new string('b', 40)
            };
            var response = httpServer.Post("api/users/register", testUser);

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            Assert.IsNotNull(response.Content);

            var contentString = response.Content.ReadAsStringAsync().Result;
            var model = JsonConvert.DeserializeObject<LoggedUserModel>(contentString);
            Assert.AreEqual(testUser.Nickname, model.Nickname);
            Assert.IsNotNull(model.SessionKey);
        }
    }
}
