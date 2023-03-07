using Srv.Crud.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Srv.Crud.Repository.IRepositories
{
    public interface IAuthRepository
    {
        Task<bool> ValidateLogin(Login login);
    }
}
