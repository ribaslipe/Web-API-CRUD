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

namespace Srv.Crud.Tests
{
    public class CreateTokenCommandHandlerTest
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
        public async Task CreateTokenShouldCallAdd_Method_Once()
        {
            var configuration = new ConfigurationBuilder().AddInMemoryCollection(appSettingsKeys).Build();

            var options = new DbContextOptionsBuilder<Repository.Contexts.CrudContext>().UseInMemoryDatabase("db_crud_auth").Options;

            var mockAuthService = new Mock<IAuthService>();

            mockAuthService.Setup(x => x.GenerateJwtToken(It.IsAny<Login>())).Returns(Task.FromResult(""));

            var handler = new CreateTokenCommandHandler(mockAuthService.Object, configuration);
            var result = await handler.Handle(new Domain.Commands.CreateTokenCommand() { }, CancellationToken.None);

            result.ShouldBeOfType<CreateTokenResponse>();

            mockAuthService.Verify(x => x.GenerateJwtToken(It.IsAny<Login>()), Times.Once);
        }
    }
}