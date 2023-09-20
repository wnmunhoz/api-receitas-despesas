using FinancialSystemMicroServices.Domain.Interfaces.Clients;
using Microsoft.EntityFrameworkCore;

namespace FinancialSystemMicroServices.Infra.Repositories.Clients
{
    public class ClientRepository : IClientRepository
    {
        private AppDbContext _context;

        public ClientRepository(AppDbContext context)
            => _context = context;

        public async Task<IEnumerable<Client>> GetAllAsync()
            => await _context.Clients.ToListAsync();

        public async Task<Client> GetByIdAsync(Guid id)
        {
            var response = await _context.Clients.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);

            if (response is null)
                throw new Exception("Client not found.");

            return response;
        }

        public async Task<Client> AddAsync(Client client)
        {
            var result = await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<Client> UpdateAsync(Client client)
        {
            _context.Clients.Update(client);
            await _context.SaveChangesAsync();

            return client;
        }

        public async void Remove(Guid id)
        {
            var response = await GetByIdAsync(id);

            if (response is not null)
            {
                _context.Clients.Remove(response);
                _context.SaveChanges();
            }
        }
    }
}
