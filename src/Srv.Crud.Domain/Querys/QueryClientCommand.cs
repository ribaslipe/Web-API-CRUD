using MediatR;
using Srv.Crud.Domain.Responses.QueryResponses;

namespace Srv.Crud.Domain.Querys
{
    public class QueryClientCommand : IRequest<QueryClientResponse>
    {
    }
}
