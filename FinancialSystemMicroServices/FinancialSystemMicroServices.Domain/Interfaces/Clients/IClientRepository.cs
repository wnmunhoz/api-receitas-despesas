namespace FinancialSystemMicroServices.Domain.Interfaces.Clients
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetAllAsync();

        Task<Client> GetByIdAsync(Guid id);

        Task<Client> AddAsync(Client client);

        Task<Client> UpdateAsync(Client client);

        void Remove(Guid id);
    }
}
