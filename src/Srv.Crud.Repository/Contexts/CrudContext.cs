using Microsoft.EntityFrameworkCore;
using Srv.Crud.Repository.Models;

namespace Srv.Crud.Repository.Contexts
{
    public class CrudContext : DbContext
    {

        public CrudContext()
        {
        }

        public CrudContext(DbContextOptions<CrudContext> options) : base(options)
        {
        }

        public DbSet<Client> Client { get; set; }
        public DbSet<Login> Login { get; set; }
    }
}
