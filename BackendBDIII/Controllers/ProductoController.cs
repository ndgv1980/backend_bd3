using BackendBDIII.Data;
using BackendBDIII.Data.Repositories;
using BackendBDIII.Model;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace BackendBDIII.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        public ProductoController(IProductoRepository i_productoRepository, IUsuarioRepository i_usuarioRepository) 
        {
            m_productoRepository = i_productoRepository;
            m_usuarioRepository = i_usuarioRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts([FromQuery] string i_token) 
        {
            bool userValidated = await HelperMethods.ValidateToken(m_usuarioRepository, i_token);
            if (!userValidated)
            {
                return BadRequest(new { Error = "Invalid token." });
            }

            return Ok(await m_productoRepository.GetAllProducts());
        }

        [HttpPost]
        public async Task<IActionResult> InsertProduct([FromQuery] string i_token, [FromBody] Producto i_product) 
        {
            bool userValidated = await HelperMethods.ValidateToken(m_usuarioRepository, i_token);
            if (!userValidated)
            {
                return BadRequest(new { Error = "Invalid token." });
            }

            return Ok(await m_productoRepository.InsertProduct(i_product));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct([FromQuery] string i_token, [FromQuery] int i_productId)
        {
            bool userValidated = await HelperMethods.ValidateToken(m_usuarioRepository, i_token);
            if (!userValidated)
            {
                return BadRequest(new { Error = "Invalid token." });
            }

            return Ok(await m_productoRepository.DeleteProduct(new() { Codigo_Producto = i_productId }));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromQuery] string i_token, [FromBody] Producto i_product)
        {
            bool userValidated = await HelperMethods.ValidateToken(m_usuarioRepository, i_token);
            if (!userValidated)
            {
                return BadRequest(new { Error = "Invalid token." });
            }

            return Ok(await m_productoRepository.UpdateProduct(i_product));
        }

        private readonly IProductoRepository m_productoRepository;
        private readonly IUsuarioRepository m_usuarioRepository;
    }
}
