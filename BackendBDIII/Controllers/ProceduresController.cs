using BackendBDIII.Data;
using BackendBDIII.Data.Repositories;
using BackendBDIII.Model;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace BackendBDIII.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ProceduresController : ControllerBase
    {
        public ProceduresController(IUsuarioRepository i_usuarioRepository) 
        {
            m_usuarioRepository = i_usuarioRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCallProcedure1([FromQuery] string i_token) 
        {
            bool userValidated = await HelperMethods.ValidateToken(m_usuarioRepository, i_token);
            if (!userValidated) 
            {
                return BadRequest(new { Error = "Invalid token." });
            }

            return Ok();
        }

        private readonly IUsuarioRepository m_usuarioRepository;
    }
}
