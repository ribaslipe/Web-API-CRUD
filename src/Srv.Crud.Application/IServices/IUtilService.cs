using Srv.Crud.Domain.Commands;
using Srv.Crud.Domain.Responses.CommandResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Srv.Crud.Application.IServices
{
    public interface IUtilService
    {
        Task<CreateClientResponse> ValitadeAll(CreateClientCommand request);
        Task<UpdateClientResponse> ValitadeAllUpdate(UpdateClientCommand request);
    }
}
