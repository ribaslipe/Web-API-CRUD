using Microsoft.Extensions.Configuration;
using Moq;
using Shouldly;
using Srv.Crud.Application.Handlers.CommandHandlers;
using Srv.Crud.Application.Services;
using Srv.Crud.Domain.Responses.CommandResponses;
using Srv.Crud.Repository.Repositories;
using Microsoft.EntityFrameworkCore;
using Srv.Crud.Application.IServices;
using Srv.Crud.Repository.IRepositories;
using Srv.Crud.Repository.Models;
using Srv.Crud.Domain.Commands;

namespace Srv.Crud.Tests
{
    public class CreateClientCommandHandlerTest
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
        public async Task CreateClientShouldCallAddMethodOnce()
        {
            var configuration = new ConfigurationBuilder().AddInMemoryCollection(appSettingsKeys).Build();

            var options = new DbContextOptionsBuilder<Repository.Contexts.CrudContext>().UseInMemoryDatabase("db_crud_client").Options;

            var mockClientService = new Mock<IClientService>();
            var mockUtilService = new Mock<IUtilService>();

            var mockClient = new CreateClientCommand { nome = "test", cidade = "test", endereco = "test", uf = "test" };

            mockClientService.Setup(x => x.CreateClient(It.IsAny<CreateClientCommand>())).Returns(Task.FromResult(false));
            mockUtilService.Setup(s => s.ValitadeAll(It.IsAny<CreateClientCommand>())).Returns(Task.FromResult(new CreateClientResponse() { sucesso = true}));

            var handler = new CreateClientCommandHandler(mockClientService.Object, configuration, mockUtilService.Object);
            var result = await handler.Handle(mockClient, CancellationToken.None);

            result.ShouldBeOfType<CreateClientResponse>();

            mockClientService.Verify(x => x.CreateClient(It.IsAny<CreateClientCommand>()), Times.Once);
        }       
    }
}