using MediatR;
using Srv.Crud.Domain.Responses.CommandResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Srv.Crud.Domain.Commands
{
    public class CreateClientCommand : IRequest<CreateClientResponse>
    {
        public string nome { get; set; }
        public string endereco { get; set; }
        public string cidade { get; set; }
        public string uf { get; set; }
        public string datainsercao { get; set; }
       
    }
}
