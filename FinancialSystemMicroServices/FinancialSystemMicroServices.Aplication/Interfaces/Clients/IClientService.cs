namespace FinancialSystemMicroServices.Aplication.Interfaces.Clients
{
    public interface IClientService
    {
        Task<IEnumerable<Client>> GetAll();

        Task<Client> GetById(Guid id);

        Task<Client> Add(Client client);

        Task<Client> Update(Client client);

        void Remove(Guid id);
    }
}
