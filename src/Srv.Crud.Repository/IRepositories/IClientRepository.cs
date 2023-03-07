using Srv.Crud.Domain.Commands;
using Srv.Crud.Domain.Querys;
using Srv.Crud.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Srv.Crud.Repository.IRepositories
{
    public interface IClientRepository
    {
        Task<bool> CreateClient(Client client);
        Task<bool> UpdateClient(Client client);
        Task<bool> DeleteClient(Client client);
        Task<Client?> SelectClient(Client client);
        Task<List<Client>> GetAll();
    }
}
