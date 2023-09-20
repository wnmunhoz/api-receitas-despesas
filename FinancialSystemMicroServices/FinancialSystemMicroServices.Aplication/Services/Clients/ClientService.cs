using FinancialSystemMicroServices.Aplication.Interfaces.Clients;
using FinancialSystemMicroServices.Domain.Interfaces.Clients;

namespace FinancialSystemMicroServices.Aplication.Services.Clients
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientsRepository)
            => _clientRepository = clientsRepository;

        public async Task<IEnumerable<Client>> GetAll()
            => await _clientRepository.GetAllAsync();        

        public async Task<Client> GetById(Guid id)        
            => await _clientRepository.GetByIdAsync(id);

        public async Task<Client> Add(Client client)
            => await _clientRepository.AddAsync(client);

        public async Task<Client> Update(Client client)
            => await _clientRepository.UpdateAsync(client);

        public void Remove(Guid id)
            => _clientRepository.Remove(id);
    }
}
