using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using Shouldly;
using Srv.Crud.Application.Handlers.QueryHandles;
using Srv.Crud.Application.IServices;
using Srv.Crud.Domain.Querys;
using Srv.Crud.Domain.Responses.CommandResponses;
using Srv.Crud.Repository.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Srv.Crud.Tests.Handlers.QueryHandlers
{
    public class SelectClientCommandHandlerTest
    {
        private Dictionary<string, string> appSettingsKeys = new Dictionary<string, string>()
            {
                {"Key1", "Value1"},
                {"Jwt:Issuer", "WebApiJwt.com"},
                {"Jwt:Audience", "localhost"},
                {"Jwt:Key", "39846cc178804fe18610bb1b205cfb16"},
                {"Jwt:AccessTokenExpirationInMinutes", "60"},
                {"Jwt:RefreshTokenExpirationInDays", "7"}
            };


        [Fact]
        public async Task SelectClientShouldCallAddMethodOnce()
        {
            var configuration = new ConfigurationBuilder().AddInMemoryCollection(appSettingsKeys).Build();

            var options = new DbContextOptionsBuilder<CrudContext>().UseInMemoryDatabase("db_crud_client").Options;

            var mockPartnerService = new Mock<IClientService>();

            mockPartnerService.Setup(x => x.SelectClient(It.IsAny<SelectClientCommand>())).Returns(Task.FromResult(new SelectClientResponse()));

            var handler = new SelectClientCommandHandler(mockPartnerService.Object, configuration);
            var result = await handler.Handle(new SelectClientCommand() { }, CancellationToken.None);

            result.ShouldBeOfType<SelectClientResponse>();

            mockPartnerService.Verify(x => x.SelectClient(It.IsAny<SelectClientCommand>()), Times.Once);
        }


    }
}
