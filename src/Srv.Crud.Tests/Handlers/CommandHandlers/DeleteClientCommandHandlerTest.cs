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
    public class DeleteClientCommandHandlerTest
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
        public async Task DeleteClientShouldCallAddMethodOnce()
        {
            var configuration = new ConfigurationBuilder().AddInMemoryCollection(appSettingsKeys).Build();

            var options = new DbContextOptionsBuilder<Repository.Contexts.CrudContext>().UseInMemoryDatabase("db_crud_client").Options;

            var mockClientService = new Mock<IClientService>();                        

            mockClientService.Setup(x => x.DeleteClient(It.IsAny<DeleteClientCommand>())).Returns(Task.FromResult(false));            

            var handler = new DeleteClientCommandHandler(mockClientService.Object, configuration);
            var result = await handler.Handle(new DeleteClientCommand() { }, CancellationToken.None);

            result.ShouldBeOfType<DeleteClientResponse>();

            mockClientService.Verify(x => x.DeleteClient(It.IsAny<DeleteClientCommand>()), Times.Once);
        }       
    }
}