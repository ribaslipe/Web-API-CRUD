using MediatR;
using Srv.Crud.Domain.Responses.CommandResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Srv.Crud.Domain.Commands
{
    public class DeleteClientCommand : IRequest<DeleteClientResponse>
    {
        public int codcliente { get; set; }       
    }
}
