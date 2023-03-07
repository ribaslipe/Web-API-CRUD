using Srv.Crud.Domain.Commands;
using Srv.Crud.Domain.Querys;
using Srv.Crud.Domain.Responses.CommandResponses;
using Srv.Crud.Domain.Responses.QueryResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Srv.Crud.Application.IServices
{
    public interface IClientService
    {
        Task<bool> CreateClient(CreateClientCommand command);
        Task<bool> UpdateClient(UpdateClientCommand command);
        Task<bool> DeleteClient(DeleteClientCommand command);
        Task<SelectClientResponse?> SelectClient(SelectClientCommand command);
        Task<QueryClientResponse> GetAll();
    }
}
