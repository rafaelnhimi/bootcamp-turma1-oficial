using NetCoreEntityFramework.Entity;
using NetCoreEntityFramework.Utils;
using System.Threading.Tasks;

namespace NetCoreEntityFramework.Repository
{
    public interface IUsuarioRepository : IRepositoryUsuarioContext<Usuario>
    {
        Task<bool> AutenticarUsuario(string userName);
    }
}
