using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreEntityFramework.Services
{
    public interface IUsuarioService
    {
        Task<bool> AutenticarUsuario(string userName);
        Task<bool> RegistrarUsuario(string userName);
    }
}
