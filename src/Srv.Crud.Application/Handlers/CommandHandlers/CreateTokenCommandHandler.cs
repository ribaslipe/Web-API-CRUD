using Srv.Crud.Application.Services;
using Srv.Crud.Domain.Commands;
using Srv.Crud.Domain.Responses.CommandResponses;
using MediatR;
using Microsoft.Extensions.Configuration;
using Srv.Crud.Application.IServices;
using Srv.Crud.Repository.Models;

namespace Srv.Crud.Application.Handlers.CommandHandlers
{
    public class CreateTokenCommandHandler : IRequestHandler<CreateTokenCommand, CreateTokenResponse>
    {
        private readonly IAuthService _authService;
        private readonly IConfiguration _configuration;

        public CreateTokenCommandHandler(IAuthService authService, IConfiguration configuration)
        {
            _authService = authService;
            _configuration = configuration;
        }

        public async Task<CreateTokenResponse> Handle(CreateTokenCommand request, CancellationToken cancellationToken)
        {
            var login = new Login { Usuario = request.usuario, Senha = request.senha };
            string accessTokenBase64 = await _authService.GenerateJwtToken(login);

            return accessTokenBase64 != "" ? new CreateTokenResponse
            {
                AccessToken = accessTokenBase64,
                Message = "Success",
                Success = true
            }
            :
            new CreateTokenResponse
            {
                AccessToken = "",
                Message = "Não Autorizado",
                Success = false
            };
        }
    }
}
