using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Srv.Crud.Domain.Commands;
using Srv.Crud.Domain.Responses.CommandResponses;
using Swashbuckle.AspNetCore.Annotations;

namespace Srv.Crud.API.Controllers.v1
{
    [ApiController]
    [Route("v1/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Gerar token JWT
        /// </summary>        
        /// <response code="200">Token gerado com sucesso</response>
        /// <response code="400">A requisição foi malformada, omitindo atributos obrigatórios, seja no payload ou através de atributos na URL.</response>        
        /// <response code="500">Ocorreu um erro no gateway da API ou no microsserviço</response>
        /// <response code="502">Ocorreu um erro nas consultas internas</response>
        [HttpPost]
        [Route("CreateToken")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreateTokenResponse))]
        [SwaggerOperation("Gerar token de acesso", Tags = new[] { "Auth - Login fixo como usuário: test e senha: test" })]
        public async Task<CreateTokenResponse> CreateToken([FromBody] CreateTokenCommand command)
        {
            return await _mediator.Send(command);
        }             

    }
}
