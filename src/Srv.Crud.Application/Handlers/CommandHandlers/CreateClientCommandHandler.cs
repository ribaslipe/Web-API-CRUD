using Srv.Crud.Application.Services;
using Srv.Crud.Domain.Commands;
using Srv.Crud.Domain.Responses.CommandResponses;
using MediatR;
using Microsoft.Extensions.Configuration;
using Srv.Crud.Application.IServices;
using Srv.Crud.Repository.Models;

namespace Srv.Crud.Application.Handlers.CommandHandlers
{
    public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, CreateClientResponse>
    {
        private readonly IClientService _clientService;
        private readonly IUtilService _utilService;
        private readonly IConfiguration _configuration;

        public CreateClientCommandHandler(IClientService clientService, IConfiguration configuration, IUtilService utilService)
        {
            _clientService = clientService;
            _configuration = configuration;
            _utilService = utilService;
        }

        public async Task<CreateClientResponse> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {         
            var validate = await _utilService.ValitadeAll(request);
            if (!validate.sucesso)
                return validate;


            bool result = await _clientService.CreateClient(request);
            return result ? new CreateClientResponse
            {
                mensagem = "Cliente adicionado com sucesso.",
                sucesso = true
            }
            : new CreateClientResponse
            {
                mensagem = "Erro ao salvar",
                sucesso = false
            };
        }
    }
}
