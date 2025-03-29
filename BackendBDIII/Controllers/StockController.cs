using BackendBDIII.Data;
using BackendBDIII.Data.Repositories;
using BackendBDIII.Model;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace BackendBDIII.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        public StockController(IStockRepository i_stockRepository, IUsuarioRepository i_usuarioRepository) 
        {
            m_stockRepository = i_stockRepository;
            m_usuarioRepository = i_usuarioRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetStock([FromQuery] string i_token) 
        {
            bool userValidated = await HelperMethods.ValidateToken(m_usuarioRepository, i_token);
            if (!userValidated)
            {
                return BadRequest(new { Error = "Invalid token." });
            }

            return Ok(await m_stockRepository.GetStock());
        }

        [HttpPost]
        public async Task<IActionResult> InsertStock([FromQuery] string i_token, [FromBody] Stock i_stock)
        {
            bool userValidated = await HelperMethods.ValidateToken(m_usuarioRepository, i_token);
            if (!userValidated)
            {
                return BadRequest(new { Error = "Invalid token." });
            }

            return Ok(await m_stockRepository.InsertStock(i_stock));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteStock([FromQuery] string i_token, [FromQuery] int i_stockId, [FromQuery] int i_storageLocationId)
        {
            bool userValidated = await HelperMethods.ValidateToken(m_usuarioRepository, i_token);
            if (!userValidated)
            {
                return BadRequest(new { Error = "Invalid token." });
            }

            return Ok(await m_stockRepository.DeleteStock(new() { Codigo_Producto = i_stockId, Codigo_Almacen = i_storageLocationId }));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStock([FromQuery] string i_token, [FromBody] Stock i_stock)
        {
            bool userValidated = await HelperMethods.ValidateToken(m_usuarioRepository, i_token);
            if (!userValidated)
            {
                return BadRequest(new { Error = "Invalid token." });
            }

            return Ok(await m_stockRepository.UpdateStock(i_stock));
        }

        private readonly IStockRepository m_stockRepository;
        private readonly IUsuarioRepository m_usuarioRepository;
    }
}
