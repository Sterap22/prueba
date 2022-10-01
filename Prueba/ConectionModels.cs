using Login.Models;
using Microsoft.EntityFrameworkCore;

namespace Login
{
    public class ConectionModels : DbContext
    {
        public ConectionModels(DbContextOptions options) : base(options)
        {
        }
        public DbSet<UsuarioInfo> usuario { get; set; }
    }
}
