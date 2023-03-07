using Microsoft.EntityFrameworkCore;
using Srv.Crud.Repository.Contexts;
using Srv.Crud.Repository.IRepositories;
using Srv.Crud.Repository.Models;


namespace Srv.Crud.Repository.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly CrudContext _context;

        public ClientRepository(CrudContext context)
        {
            _context = context;
        }
      
        public async Task<bool> CreateClient(Client client)
        {
            try
            {                
                _context.Client.Add(client);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateClient(Client client)
        {
            try
            {
                _context.Client.Update(client);
                var result = await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteClient(Client client)
        {
            try
            {
                _context.Client.Remove(client);
                var result = await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Client?> SelectClient(Client client)
        {
            try
            {
                var result = await _context.Client.Where(s => s.CodCliente == client.CodCliente).SingleOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<Client>> GetAll()
        {
            try
            {
                var result = await _context.Client.ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                return new List<Client>();
            }
        }

    }
}
