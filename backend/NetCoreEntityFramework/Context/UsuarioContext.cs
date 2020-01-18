using Microsoft.EntityFrameworkCore;
using NetCoreEntityFramework.Entity;

namespace NetCoreEntityFramework.Context
{
    public class UsuarioContext : DbContext
    {
        public UsuarioContext(DbContextOptions<UsuarioContext> options)
            : base(options)
        { }

        public DbSet<Usuario> Usuario { get; set; }
    }
}
