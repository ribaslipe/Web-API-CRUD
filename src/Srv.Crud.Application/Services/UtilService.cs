using Srv.Crud.Application.IServices;
using Srv.Crud.Domain.Commands;
using Srv.Crud.Domain.Responses.CommandResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Srv.Crud.Application.Services
{
    public class UtilService : IUtilService
    {
        public async Task<CreateClientResponse> ValitadeAll(CreateClientCommand request)
        {
            var msg = "";

            if (String.IsNullOrEmpty(request.nome) || request.nome.Length > 500)
            {
                msg = "Nome não pode ser vazio ou maior de 500 caracteres.";
            }

            if (String.IsNullOrEmpty(request.endereco) || request.nome.Length > 1000)
            {
                msg += "\nEndereço não pode ser vazio ou maior de 1000 caracteres.";
            }

            if (String.IsNullOrEmpty(request.cidade) || request.nome.Length > 200)
            {
                msg += "\nCidade não pode ser vazia ou maior de 200 caracteres";
            }

            if (String.IsNullOrEmpty(request.uf) || request.uf.Length > 2)
            {
                msg += "\nUF não pode está vazia ou maior que 2 caracteres";
            }           

            if (!String.IsNullOrEmpty(msg))
            {
                var result = new CreateClientResponse() { mensagem = msg, sucesso = false};              
                return await Task.FromResult(result);
            }
            else
            {
                var result = new CreateClientResponse() { sucesso = true };
                return await Task.FromResult(result);
            }


        }

        public async Task<UpdateClientResponse> ValitadeAllUpdate(UpdateClientCommand request)
        {
            var msg = "";

            if (String.IsNullOrEmpty(request.nome) || request.nome.Length > 500)
            {
                msg = "Nome não pode ser vazio ou maior de 500 caracteres.";
            }

            if (String.IsNullOrEmpty(request.endereco) || request.nome.Length > 1000)
            {
                msg += "\nEndereço não pode ser vazio ou maior de 1000 caracteres.";
            }

            if (String.IsNullOrEmpty(request.cidade) || request.nome.Length > 200)
            {
                msg += "\nCidade não pode ser vazia ou maior de 200 caracteres";
            }

            if (String.IsNullOrEmpty(request.uf) || request.uf.Length > 2)
            {
                msg += "\nUF não pode está vazia ou maior que 2 caracteres";
            }

            if (!String.IsNullOrEmpty(msg))
            {
                var result = new UpdateClientResponse() { mensagem = msg, sucesso = false };
                return await Task.FromResult(result);
            }
            else
            {
                var result = new UpdateClientResponse() { sucesso = true };
                return await Task.FromResult(result);
            }


        }

    }
}
