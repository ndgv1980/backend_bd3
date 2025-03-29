using BackendBDIII.Data;
using BackendBDIII.Data.Repositories;
using BackendBDIII.Model;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace BackendBDIII.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        public VentasController(IVentasRepository i_ventasRepository, IUsuarioRepository i_usuarioRepository) 
        {
            m_ventasRepository = i_ventasRepository;
            m_usuarioRepository = i_usuarioRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSales([FromQuery] string i_token) 
        {
            bool userValidated = await HelperMethods.ValidateToken(m_usuarioRepository, i_token);
            if (!userValidated)
            {
                return BadRequest(new { Error = "Invalid token." });
            }

            return Ok(await m_ventasRepository.GetAllSales());
        }

        [HttpPost]
        public async Task<IActionResult> InsertStock([FromQuery] string i_token, [FromBody] Ventas i_sale)
        {
            bool userValidated = await HelperMethods.ValidateToken(m_usuarioRepository, i_token);
            if (!userValidated)
            {
                return BadRequest(new { Error = "Invalid token." });
            }

            return Ok(await m_ventasRepository.InsertSale(i_sale));
        }

        private readonly IVentasRepository m_ventasRepository;
        private readonly IUsuarioRepository m_usuarioRepository;
    }
}
