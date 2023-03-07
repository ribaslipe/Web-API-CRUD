using Srv.Crud.Application.Services;
using Srv.Crud.Domain.Commands;
using Srv.Crud.Domain.Responses.CommandResponses;
using MediatR;
using Microsoft.Extensions.Configuration;
using Srv.Crud.Application.IServices;
using Srv.Crud.Repository.Models;

namespace Srv.Crud.Application.Handlers.CommandHandlers
{
    public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, UpdateClientResponse>
    {
        private readonly IClientService _clientService;
        private readonly IUtilService _utilService;
        private readonly IConfiguration _configuration;

        public UpdateClientCommandHandler(IClientService clientService, IConfiguration configuration, IUtilService utilService)
        {
            _clientService = clientService;
            _configuration = configuration;
            _utilService = utilService;
        }

        public async Task<UpdateClientResponse> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            var validate = await _utilService.ValitadeAllUpdate(request);
            if (!validate.sucesso)
                return validate;

            bool result = await _clientService.UpdateClient(request);

            return result ? new UpdateClientResponse
            {
                mensagem = "Cliente atualizado com sucesso.",
                sucesso = true
            }
            : new UpdateClientResponse
            {
                mensagem = "Erro ao atualizar",
                sucesso = false
            };
        }
    }
}
