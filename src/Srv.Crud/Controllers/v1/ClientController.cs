using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Srv.Crud.Domain.Commands;
using Srv.Crud.Domain.Querys;
using Srv.Crud.Domain.Responses.CommandResponses;
using Srv.Crud.Domain.Responses.QueryResponses;
using Swashbuckle.AspNetCore.Annotations;

namespace Srv.Crud.API.Controllers.v1
{
    [ApiController]
    [Filters.Authorize]
    [Route("v1/[controller]")]
    public class ClientController : Controller
    {

        private readonly IMediator _mediator;

        public ClientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Cria cliente na tabela 
        /// </summary>
        /// <response code="200">Dados do cliente adicionado com sucesso</response>
        /// <response code="400">A requisição foi malformada, omitindo atributos obrigatórios, seja no payload ou através de atributos na URL.</response>
        /// <response code="401">Cabeçalho de autenticação ausente/inválido ou token inválido</response>
        /// <response code="404">O recurso solicitado não existe ou não foi autorizado</response>
        /// <response code="500">Ocorreu um erro no gateway da API ou no serviço</response>
        /// <response code="502">Ocorreu um erro nas consultas internas</response>
        [HttpPost]
        [Route("CreateClient")]        
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreateClientResponse))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [SwaggerOperation("Cria cliente na tabela")]
        public async Task<CreateClientResponse> CreateClient([FromBody] CreateClientCommand command)
        {
            return await _mediator.Send(command);
        }

        /// <summary>
        /// Atualiza cliente na tabela 
        /// </summary>
        /// <response code="200">Dados do cliente atualizado com sucesso</response>
        /// <response code="400">A requisição foi malformada, omitindo atributos obrigatórios, seja no payload ou através de atributos na URL.</response>
        /// <response code="401">Cabeçalho de autenticação ausente/inválido ou token inválido</response>
        /// <response code="404">O recurso solicitado não existe ou não foi autorizado</response>
        /// <response code="500">Ocorreu um erro no gateway da API ou no serviço</response>
        /// <response code="502">Ocorreu um erro nas consultas internas</response>
        [HttpPut]
        [Route("UpdateClient")]                
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UpdateClientResponse))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [SwaggerOperation("Atualiza cliente na tabela")]
        public async Task<UpdateClientResponse> UpdateClient([FromBody] UpdateClientCommand command)
        {
            return await _mediator.Send(command);
        }

        /// <summary>
        /// Deleta cliente na tabela 
        /// </summary>
        /// <response code="200">Dados do cliente deletado com sucesso</response>
        /// <response code="400">A requisição foi malformada, omitindo atributos obrigatórios, seja no payload ou através de atributos na URL.</response>
        /// <response code="401">Cabeçalho de autenticação ausente/inválido ou token inválido</response>
        /// <response code="404">O recurso solicitado não existe ou não foi autorizado</response>
        /// <response code="500">Ocorreu um erro no gateway da API ou no serviço</response>
        /// <response code="502">Ocorreu um erro nas consultas internas</response>
        [HttpDelete]
        [Route("DeleteClient")]      
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DeleteClientResponse))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [SwaggerOperation("Deleta cliente na tabela")]
        public async Task<DeleteClientResponse> DeleteClient([FromBody] DeleteClientCommand command)
        {
            return await _mediator.Send(command);
        }

        /// <summary>
        /// Seleciona cliente na tabela através do seu id
        /// </summary>
        /// <response code="200">Dados do cliente retornado com sucesso</response>
        /// <response code="400">A requisição foi malformada, omitindo atributos obrigatórios, seja no payload ou através de atributos na URL.</response>
        /// <response code="401">Cabeçalho de autenticação ausente/inválido ou token inválido</response>
        /// <response code="404">O recurso solicitado não existe ou não foi autorizado</response>
        /// <response code="500">Ocorreu um erro no gateway da API ou no serviço</response>
        /// <response code="502">Ocorreu um erro nas consultas internas</response>
        [HttpPost]
        [Route("SelectClient")]       
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SelectClientResponse))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [SwaggerOperation("Seleciona cliente na tabela através do seu Id")]
        public async Task<SelectClientResponse> SelectClient([FromBody] SelectClientCommand command)
        {
            return await _mediator.Send(command);
        }

        /// <summary>
        /// Seleciona todos os clientes da tabela
        /// </summary>
        /// <response code="200">Dados do cliente retornado com sucesso</response>
        /// <response code="400">A requisição foi malformada, omitindo atributos obrigatórios, seja no payload ou através de atributos na URL.</response>
        /// <response code="401">Cabeçalho de autenticação ausente/inválido ou token inválido</response>
        /// <response code="404">O recurso solicitado não existe ou não foi autorizado</response>
        /// <response code="500">Ocorreu um erro no gateway da API ou no serviço</response>
        /// <response code="502">Ocorreu um erro nas consultas internas</response>
        [HttpPost]
        [Route("GetClients")]        
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(QueryClientResponse))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [SwaggerOperation("Retorna todos os clientes da tabela")]
        public async Task<QueryClientResponse> GetClients([FromBody] QueryClientCommand command)
        {
            return await _mediator.Send(command);
        }

    }
}
