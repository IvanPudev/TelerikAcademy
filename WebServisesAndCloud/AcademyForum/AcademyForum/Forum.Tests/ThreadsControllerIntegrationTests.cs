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
    public class ThreadsControllerIntegrationTests
    {
        static TransactionScope tran;
        private InMemoryHttpServer httpServer;

        [TestInitialize]
        public void TestInit()
        {
            tran = new TransactionScope();
            var routes = new List<Route>()
            {
                new Route( "ThreadsPosts",
                    "api/threads/{threadId}/posts",
                    new
                    {   controller = "threads",
                        action = "posts" }),                
                new Route(
                    "ThreadsCreateApi",
                    "api/threads/create",
                    new
                    {   controller = "threads",
                        action = "create" }),
                new Route(
                    "ThreadsApi",
                    "api/threads/",
                    new { controller = "threads"}),
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
        public void Create_WhenThreadModelValid_ShouldSaveToDatabase()
        {
            var testThread = new ThreadModel()
            {
                Title = "TestTitle",
                Content = "Test Conetnt",
                DateCreated = DateTime.Now,
                Categories = new string[] { "test categorie 1", "test categorie 10" }
            };
            var headers = new Dictionary<string, string>();
            headers.Add("X-sessionKey", "1jwuZotDUMHHMNeLXLcdEYKjvNDrMwPUDDADPAXzAvXQfHigzy");

            var response = httpServer.Post("api/threads/create", testThread, headers);

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            Assert.IsNull(response.Content);
        }

        [TestMethod]
        public void Get_ShouldGetAllThreadsDatabase()
        {
            var testThread = new ThreadModel()
            {
                Title = "TestTitle",
                Content = "Test Conetnt",
                DateCreated = DateTime.Now,
                Categories = new string[] { "test categorie 1", "test categorie 10" }
            };
            var headers = new Dictionary<string, string>();
            headers.Add("X-sessionKey", "1jwuZotDUMHHMNeLXLcdEYKjvNDrMwPUDDADPAXzAvXQfHigzy");

            var response = httpServer.Post("api/threads/create", testThread, headers);

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);

            response = httpServer.Get("api/threads", headers);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);

            var contentString = response.Content.ReadAsStringAsync().Result;
            var model = JsonConvert.DeserializeObject<ThreadDetails[]>(contentString);

            Assert.AreEqual(testThread.Title, model[0].Title);
        }
    }
}
