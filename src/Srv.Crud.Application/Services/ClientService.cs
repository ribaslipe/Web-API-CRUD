using Microsoft.Extensions.Configuration;
using Srv.Crud.Repository.IRepositories;
using Srv.Crud.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Srv.Crud.Domain.Commands;
using Srv.Crud.Application.IServices;
using Srv.Crud.Domain.Querys;
using Srv.Crud.Domain.Responses.CommandResponses;
using Srv.Crud.Domain.Responses.QueryResponses;

namespace Srv.Crud.Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IConfiguration _configuration;
        private readonly IClientRepository _clientRepository;

        public ClientService(IConfiguration configuration, IClientRepository clientRepository)
        {
            _configuration = configuration;
            _clientRepository = clientRepository;
        }

        public async Task<bool> CreateClient(CreateClientCommand command)
        {
            var result = await _clientRepository.CreateClient(new Repository.Models.Client
            {
                Nome = command.nome,
                Endereco = command.endereco,
                Cidade = command.cidade,
                Uf = command.uf,
                DataInsercao = command.datainsercao
            });

            if (result)
                return true;
            else
                return false;
        }

        public async Task<bool> UpdateClient(UpdateClientCommand command)
        {
            var result = await _clientRepository.UpdateClient(new Repository.Models.Client
            {
                CodCliente = command.codcliente,
                Nome = command.nome,
                Endereco = command.endereco,
                Cidade = command.cidade,
                Uf = command.uf,
                DataInsercao = command.datainsercao
            });

            if (result)
                return true;
            else
                return false;
        }

        public async Task<bool> DeleteClient(DeleteClientCommand command)
        {
            var result = await _clientRepository.DeleteClient(new Repository.Models.Client
            {
                CodCliente = command.codcliente
            });

            if (result)
                return true;
            else
                return false;
        }

        public async Task<SelectClientResponse?> SelectClient(SelectClientCommand command)
        {
            var result = await _clientRepository.SelectClient(new Repository.Models.Client
            {
                CodCliente = command.codcliente
            });

            if (result != null)
            {
                return new SelectClientResponse
                {
                    codcliente = result.CodCliente,
                    cidade = result.Cidade,
                    datainsercao = result.DataInsercao,
                    endereco = result.Endereco,
                    nome = result.Nome,
                    uf = result.Uf,
                    sucesso = true
                };
            }
            else return null;
        }

        public async Task<QueryClientResponse> GetAll()
        {
            var result = await _clientRepository.GetAll();

            if (result.Count() > 0)
            {
                QueryClientResponse client = new QueryClientResponse();

                client.clients = result.Select(p => new Clients
                {
                    nome = p.Nome,
                    endereco = p.Endereco,
                    cidade = p.Cidade,
                    codcliente = p.CodCliente,
                    datainsercao = p.DataInsercao,
                    uf = p.Uf
                }).ToList();

                return client;
            }
            else
            {
                return new QueryClientResponse();
            }
        }

    }
}
