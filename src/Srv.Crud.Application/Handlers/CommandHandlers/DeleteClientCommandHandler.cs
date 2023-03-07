using Srv.Crud.Application.Services;
using Srv.Crud.Domain.Commands;
using Srv.Crud.Domain.Responses.CommandResponses;
using MediatR;
using Microsoft.Extensions.Configuration;
using Srv.Crud.Application.IServices;
using Srv.Crud.Repository.Models;

namespace Srv.Crud.Application.Handlers.CommandHandlers
{
    public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand, DeleteClientResponse>
    {
        private readonly IClientService _clientService;
        private readonly IConfiguration _configuration;

        public DeleteClientCommandHandler(IClientService clientService, IConfiguration configuration)
        {
            _clientService = clientService;
            _configuration = configuration;
        }

        public async Task<DeleteClientResponse> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {
            bool result = await _clientService.DeleteClient(request);

            return result ? new DeleteClientResponse
            {
                mensagem = "Cliente deletado com sucesso.",
                sucesso = true
            }
            : new DeleteClientResponse
            {
                mensagem = "Erro ao deletar",
                sucesso = false
            };
        }
    }
}
