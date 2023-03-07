using MediatR;
using Srv.Crud.Domain.Responses.CommandResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Srv.Crud.Domain.Querys
{
    public class SelectClientCommand : IRequest<SelectClientResponse>
    {
        public int codcliente { get; set; }       
    }
}
