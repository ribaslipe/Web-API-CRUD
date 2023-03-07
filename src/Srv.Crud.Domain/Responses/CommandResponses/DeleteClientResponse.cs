using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Srv.Crud.Domain.Responses.CommandResponses
{
    public class DeleteClientResponse
    {       
        public string mensagem { get; set; }
        public bool sucesso { get; set; }
    }
}
