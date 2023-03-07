using MediatR;
using Microsoft.Extensions.Configuration;
using Srv.Crud.Application.IServices;
using Srv.Crud.Domain.Querys;
using Srv.Crud.Domain.Responses.CommandResponses;
using System.Reflection.Metadata.Ecma335;

namespace Srv.Crud.Application.Handlers.QueryHandles
{
    public class SelectClientCommandHandler : IRequestHandler<SelectClientCommand, SelectClientResponse>
    {
        private readonly IClientService _clientService;
        private readonly IConfiguration _configuration;

        public SelectClientCommandHandler(IClientService clientService, IConfiguration configuration)
        {
            _clientService = clientService;
            _configuration = configuration;
        }

        public async Task<SelectClientResponse> Handle(SelectClientCommand request, CancellationToken cancellationToken)
        {
            var result = await _clientService.SelectClient(request);

            return result != null ? result
            : new SelectClientResponse
            {
                sucesso = false
            };
        }
    }
}
