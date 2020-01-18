using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCoreEntityFramework.Services;

namespace NetCoreEntityFramework.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("autenticar")]
        public async Task<bool> Autenticar(string userName)
        {
            return await _usuarioService.AutenticarUsuario(userName);
        }

        [HttpPost("registrar")]
        public async Task Registrar(string userName)
        {
            await _usuarioService.RegistrarUsuario(userName);
        }

    }
}
