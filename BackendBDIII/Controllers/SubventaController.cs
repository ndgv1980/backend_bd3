using BackendBDIII.Data;
using BackendBDIII.Data.Repositories;
using BackendBDIII.Model;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace BackendBDIII.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class SubventaController : ControllerBase
    {
        public SubventaController(ISubventaRepository i_subventaRepository, IUsuarioRepository i_usuarioRepository) 
        {
            m_subventaRepository = i_subventaRepository;
            m_usuarioRepository = i_usuarioRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSubsales([FromQuery] string i_token) 
        {
            bool userValidated = await HelperMethods.ValidateToken(m_usuarioRepository, i_token);
            if (!userValidated)
            {
                return BadRequest(new { Error = "Invalid token." });
            }

            return Ok(await m_subventaRepository.GetAllSubsales());
        }

        [HttpPost]
        public async Task<IActionResult> InsertSubventa([FromQuery] string i_token, [FromBody] Subventa i_subsale)
        {
            bool userValidated = await HelperMethods.ValidateToken(m_usuarioRepository, i_token);
            if (!userValidated)
            {
                return BadRequest(new { Error = "Invalid token." });
            }

            return Ok(await m_subventaRepository.InsertSubsale(i_subsale));
        }

        private readonly ISubventaRepository m_subventaRepository;
        private readonly IUsuarioRepository m_usuarioRepository;
    }
}
