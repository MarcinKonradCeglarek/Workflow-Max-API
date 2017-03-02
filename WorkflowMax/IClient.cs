namespace WorkflowMax.Connector
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using WorkflowMax.Connector.ValueObjects;
    using WorkflowMax.Model;

    public interface IClient
    {
        Task<Client> Add(Client client);

        Task<Client> Archive(int id);

        Task<bool> Delete(int id);

        Task<Client> GetById(int id);

        Task<IEnumerable<Client>> GetList();

        Task<Client> Update(Client client);
    }
}