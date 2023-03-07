using MediatR;
using Srv.Crud.API.Filters;
using Srv.Crud.Application.Handlers.CommandHandlers;
using Srv.Crud.Application.Services;
using Srv.Crud.Domain.Commands;
using Srv.Crud.Repository.Contexts;
using Srv.Crud.Repository.Repositories;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Srv.Crud.Application.IServices;
using Srv.Crud.Repository.IRepositories;
using Srv.Crud.Domain.Querys;
using Srv.Crud.Application.Handlers.QueryHandles;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
InitServicesDependencyInjection();
InitMediatr();
InitSwagger();
InitIdentityServer();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseHttpsRedirection();
app.UseMiddleware<JwtMiddleware>();
app.MapControllers();

app.Run();


void InitMediatr()
{
    builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
    builder.Services.AddMediatR(typeof(CreateTokenCommand).Assembly);
    builder.Services.AddMediatR(typeof(CreateTokenCommandHandler).Assembly);
    builder.Services.AddMediatR(typeof(CreateClientCommand).Assembly);
    builder.Services.AddMediatR(typeof(CreateClientCommandHandler).Assembly);
    builder.Services.AddMediatR(typeof(UpdateClientCommand).Assembly);
    builder.Services.AddMediatR(typeof(UpdateClientCommandHandler).Assembly);
    builder.Services.AddMediatR(typeof(DeleteClientCommand).Assembly);
    builder.Services.AddMediatR(typeof(DeleteClientCommandHandler).Assembly);
    builder.Services.AddMediatR(typeof(UpdateClientCommand).Assembly);
    builder.Services.AddMediatR(typeof(UpdateClientCommandHandler).Assembly);
    builder.Services.AddMediatR(typeof(SelectClientCommand).Assembly);
    builder.Services.AddMediatR(typeof(SelectClientCommandHandler).Assembly);
    builder.Services.AddMediatR(typeof(QueryClientCommand).Assembly);
    builder.Services.AddMediatR(typeof(QueryClientCommandHandler).Assembly);
}

void InitSwagger()
{
    builder.Services.AddSwaggerGen(c => {

        string projectName = Assembly.GetEntryAssembly()?.GetName()?.Name + String.Empty;

        string apiDescription = "API CRUD";
        c.EnableAnnotations();
        c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo() { Title = projectName, Version = "v1", Description = apiDescription });

        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
        {
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
        });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                }
            },
            new string[] {}
        }
    });

    });

}

void InitServicesDependencyInjection()
{
    builder.Services.AddScoped<IAuthService, AuthService>();
    builder.Services.AddScoped<IAuthRepository, AuthRepository>();
    builder.Services.AddScoped<IClientService, ClientService>();
    builder.Services.AddScoped<IClientRepository, ClientRepository>();
    builder.Services.AddScoped<IUtilService, UtilService>();
}

void InitIdentityServer()
{
    builder.Services.AddDbContext<CrudContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
}

