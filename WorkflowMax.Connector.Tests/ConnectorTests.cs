namespace WorkflowMax.Connector.Tests
{
    using System;
    using System.Configuration;
    using System.Diagnostics;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;

    using NUnit.Framework;

    using WorkflowMax.Connector.Dto;

    [TestFixture]
    public class ConnectorTests
    {
        private static IConnector Connector
            =>
                new Connector(
                    ConfigurationManager.AppSettings["AccountKey"],
                    ConfigurationManager.AppSettings["ApiKey"],
                    ConfigurationManager.AppSettings["Url"]);

        [Test]
        [Category("Integration")]
        public async Task CreateAndDeleteClient()
        {
            var createRequestObject = new XmlClient() { Name = "TestingClient" + Guid.NewGuid() };
            var serializedXml = ResponseParser.Serialize(createRequestObject);
            Debug.WriteLine("CreateClient XML Request: " + serializedXml);

            var content = new StringContent(serializedXml);
            var createResponse = await Connector.Post("client.api/add", content);
            Assert.AreEqual(HttpStatusCode.OK, createResponse.StatusCode);
            var responsePayload = await createResponse.Content.ReadAsStringAsync();
            Debug.WriteLine("CreateClient XML Response: " + responsePayload);
            var response = ResponseParser.Deserialize<ClientResponse>(responsePayload);

            var request = new ClientRequest() { Id = response.Client.Id };
            var xml = ResponseParser.Serialize(request);
            Debug.WriteLine(xml);
            var deleteRequestContent = new StringContent(xml);
            var deleteResponse = await Connector.Post("/client.api/delete", deleteRequestContent);
            Assert.AreEqual(HttpStatusCode.OK, deleteResponse.StatusCode);
        }

        [Test]
        [Category("Integration")]
        public async Task DeleteAllAdditionalClients()
        {
            var clientsResponse = await Connector.Get("client.api/list");
            Assert.AreEqual(HttpStatusCode.OK, clientsResponse.StatusCode);
            var clientsResponsePayload = await clientsResponse.Content.ReadAsStringAsync();
            var clientsResponseObj = ResponseParser.Deserialize<ClientsResponse>(clientsResponsePayload);

            foreach (var client in clientsResponseObj.Clients)
            {
                if (client.Name == "Redington")
                {
                    continue;
                }

                Debug.WriteLine("Deleting " + client.Id);

                var request = new ClientRequest() { Id = client.Id };
                var xml = ResponseParser.Serialize(request);
                Debug.WriteLine(xml);
                var deleteRequestContent = new StringContent(xml);
                var deleteResponse = await Connector.Post("/client.api/delete", deleteRequestContent);
                Assert.AreEqual(HttpStatusCode.OK, deleteResponse.StatusCode);
            }
        }

        [Test]
        [Category("Integration")]
        public async Task GetCategoriesList()
        {
            var response = await Connector.Get("category.api/list");
            var obj = ResponseParser.Deserialize<CategoriesResponse>(await response.Content.ReadAsStringAsync());
            Assert.AreEqual(Status.Success, obj.Status);
            Assert.AreEqual(0, obj.Categories.Count);
        }
    }
}