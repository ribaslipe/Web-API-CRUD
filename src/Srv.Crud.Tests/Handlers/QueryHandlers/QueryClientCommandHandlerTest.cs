using Microsoft.Extensions.Configuration;
using Moq;
using Shouldly;
using Srv.Crud.Application.Handlers.QueryHandles;
using Srv.Crud.Application.IServices;
using Srv.Crud.Domain.Querys;
using Srv.Crud.Domain.Responses.QueryResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Srv.Crud.Tests.Handlers.QueryHandlers
{
    public class QueryClientCommandHandlerTest
    {
        private Dictionary<string, string> appSettingsKeys = new Dictionary<string, string>();

        [Fact]
        public async Task QueryClientShouldCallAdd_Method_Once()
        {
            var configuration = new ConfigurationBuilder().AddInMemoryCollection(appSettingsKeys).Build();

            var mockClientService = new Mock<IClientService>();

            mockClientService.Setup(x => x.GetAll()).Returns(Task.FromResult(new QueryClientResponse()));


            var handler = new QueryClientCommandHandler(mockClientService.Object, configuration);
            var result = await handler.Handle(new QueryClientCommand() { }, CancellationToken.None);

            result.ShouldBeOfType<QueryClientResponse>();

            mockClientService.Verify(x => x.GetAll(), Times.Once);
        }        


    }
}
