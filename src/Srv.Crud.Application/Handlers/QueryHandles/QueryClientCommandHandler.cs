using MediatR;
using Microsoft.Extensions.Configuration;
using Srv.Crud.Application.IServices;
using Srv.Crud.Domain.Querys;
using Srv.Crud.Domain.Responses.CommandResponses;
using Srv.Crud.Domain.Responses.QueryResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Srv.Crud.Application.Handlers.QueryHandles
{
    public class QueryClientCommandHandler : IRequestHandler<QueryClientCommand, QueryClientResponse>
    {
        private readonly IClientService _clientService;
        private readonly IConfiguration _configuration;

        public QueryClientCommandHandler(IClientService clientService, IConfiguration configuration)
        {
            _clientService = clientService;
            _configuration = configuration;
        }

        public async Task<QueryClientResponse> Handle(QueryClientCommand request, CancellationToken cancellationToken)
        {
            var result = await _clientService.GetAll();
            return result;
        }
    }
}
