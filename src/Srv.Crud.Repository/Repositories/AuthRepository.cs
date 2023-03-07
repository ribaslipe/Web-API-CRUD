using Srv.Crud.Repository.Contexts;
using Srv.Crud.Repository.IRepositories;
using Srv.Crud.Repository.Models;

namespace Srv.Crud.Repository.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly CrudContext _context;

        public AuthRepository(CrudContext context)
        {
            _context = context;
        }


        public async Task<bool> ValidateLogin(Login login)
        {
            try
            {                                
                var user = login.Usuario == "test" && login.Senha == "test" ? true : false;
                return await Task.FromResult(user);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(false);
            }
        }


    }
}