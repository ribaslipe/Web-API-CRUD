using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Srv.Crud.Domain.Responses.CommandResponses
{
    public class UpdateClientResponse
    {
        public int codcliente { get; set; }
        public string nome { get; set; }
        public string endereco { get; set; }
        public string cidade { get; set; }
        public string uf { get; set; }
        public string datainsercao { get; set; }
        public string mensagem { get; set; }
        public bool sucesso { get; set; }
    }
}
