using MediatR;
using Srv.Crud.Domain.Responses.CommandResponses;


namespace Srv.Crud.Domain.Commands
{
    public class CreateTokenCommand : IRequest<CreateTokenResponse>
    {
        public string usuario { get; set; }
        public string senha { get; set; }
    }
}



