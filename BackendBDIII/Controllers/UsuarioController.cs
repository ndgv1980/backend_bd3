using BackendBDIII.Data;
using BackendBDIII.Data.Repositories;
using BackendBDIII.Model;
using Microsoft.AspNetCore.Mvc;

namespace BackendBDIII.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        public UsuarioController(IUsuarioRepository i_usuarioRepository)
        {
            m_usuarioRepository = i_usuarioRepository;
        }

        [HttpPost]
        public async Task<IActionResult> PostLogin([FromBody] LoginData? i_loginData)
        {
            if (i_loginData == null) 
            {
                return BadRequest();
            }

            if (!ModelState.IsValid) 
            {
                return BadRequest();
            }

            var users = await m_usuarioRepository.GetAllUsers();

            Usuario? usuario = null;
            foreach (var user in users) 
            {
                if (i_loginData.Nombre == user.Nombre && 
                    i_loginData.Contra == user.Contra) 
                {
                    usuario = user;
                    break;
                }
            }

            if (usuario == null) 
            {
                return BadRequest();
            }

            return Ok(new LoginResponse() { Token = HelperMethods.GetUserHash(usuario) });
        }

        private readonly IUsuarioRepository m_usuarioRepository;
    }
}
