using Microsoft.EntityFrameworkCore;
using NetCoreEntityFramework.Context;
using NetCoreEntityFramework.Entity;
using NetCoreEntityFramework.Utils;
using System.Threading.Tasks;

namespace NetCoreEntityFramework.Repository
{
    public class UsuarioRepository : RepositoryUsuarioContext<Usuario> , IUsuarioRepository
    {
        public UsuarioRepository(UsuarioContext context) : base(context)
        {

        }

        public async Task<bool> AutenticarUsuario(string userName)
        {
            return await _context.Usuario.AnyAsync(p => p.UserName.ToLower() == userName.ToLower());
        }
    }
}
