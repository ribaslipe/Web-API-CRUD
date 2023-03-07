using Srv.Crud.Domain.Commands;
using Srv.Crud.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Srv.Crud.Application.IServices
{
    public interface IAuthService
    {
        Task<string> GenerateJwtToken(Login login);                    

    }
}
