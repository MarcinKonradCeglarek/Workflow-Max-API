namespace WorkflowMax.Connector
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;

    using WorkflowMax.Connector.Dto;
    using WorkflowMax.Connector.ValueObjects;

    public interface IClient
    {
        Task<Client> Add(Client client);

        Task<Client> Archive(int id);

        Task<bool> Delete(int id);

        Task<Client> GetById(int id);

        Task<IEnumerable<Client>> GetList();

        Task<Client> Update(Client client);
    }

    public class ClientWrapper : IClient
    {
        public ClientWrapper(IConnector connector)
        {
            this.Connector = connector;
        }

        public IConnector Connector { get; }

        public async Task<Client> Add(Client client)
        {
            var serializedXml = ResponseParser.Serialize(client);
            var content = new StringContent(serializedXml);
            var createResponse = await this.Connector.Post("/client.api/add", content);

            if (!createResponse.IsSuccessStatusCode)
            {
                throw new ApplicationException("Creating client failed");
            }

            var responsePayload = await createResponse.Content.ReadAsStringAsync();
            var response = ResponseParser.Deserialize<ClientResponse>(responsePayload);
            return new Client(response.Client);
        }

        public async Task<Client> Archive(int id)
        {
            var request = new ClientRequest() { Id = id };
            var xml = ResponseParser.Serialize(request);
            var archiveRequestContent = new StringContent(xml);
            var archiveResponse = await this.Connector.Put("client.api/archive", archiveRequestContent);

            if (!archiveResponse.IsSuccessStatusCode)
            {
                throw new ApplicationException("Archiving client failed");
            }

            var responsePayload = await archiveResponse.Content.ReadAsStringAsync();
            var response = ResponseParser.Deserialize<ClientResponse>(responsePayload);
            return new Client(response.Client);
        }

        public async Task<bool> Delete(int id)
        {
            var request = new ClientRequest() { Id = id };
            var xml = ResponseParser.Serialize(request);
            var deleteRequestContent = new StringContent(xml);
            var deleteResponse = await this.Connector.Post("/client.api/delete", deleteRequestContent);
            return deleteResponse.IsSuccessStatusCode;
        }

        public async Task<Client> GetById(int id)
        {
            var getResponse = await this.Connector.Get($"/client.api/get/{id}");

            if (!getResponse.IsSuccessStatusCode)
            {
                throw new ApplicationException("Archiving client failed");
            }

            var responsePayload = await getResponse.Content.ReadAsStringAsync();
            var response = ResponseParser.Deserialize<ClientResponse>(responsePayload);
            return new Client(response.Client);
        }

        public async Task<IEnumerable<Client>> GetList()
        {
            var listResponse = await this.Connector.Get("/client.api/list");
            if (!listResponse.IsSuccessStatusCode)
            {
                throw new ApplicationException("Creating client failed");
            }

            var responsePayload = await listResponse.Content.ReadAsStringAsync();
            var response = ResponseParser.Deserialize<ClientsResponse>(responsePayload);
            return response.Clients.Select(c => new Client(c));
        }

        public async Task<Client> Update(Client client)
        {
            var xml = ResponseParser.Serialize(client.ToXmlClient());
            var updateRequestContent = new StringContent(xml);
            var updateResponse = await this.Connector.Put("/client.api/update", updateRequestContent);

            if (!updateResponse.IsSuccessStatusCode)
            { 
                throw new ApplicationException("Archiving client failed");
            }

            var responsePayload = await updateResponse.Content.ReadAsStringAsync();
            var response = ResponseParser.Deserialize<ClientResponse>(responsePayload);
            return new Client(response.Client);
        }
    }
}