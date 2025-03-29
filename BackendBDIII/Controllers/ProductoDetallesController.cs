using BackendBDIII.Data;
using BackendBDIII.Data.Repositories;
using BackendBDIII.Model;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace BackendBDIII.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ProductoDetallesController : ControllerBase
    {
        public ProductoDetallesController(IProductoDetallesRepository i_productoDetallesRepository, IUsuarioRepository i_usuarioRepository) 
        {
            m_productoDetallesRepository = i_productoDetallesRepository;
            m_usuarioRepository = i_usuarioRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductsDetails([FromQuery] string i_token) 
        {
            bool userValidated = await HelperMethods.ValidateToken(m_usuarioRepository, i_token);
            if (!userValidated)
            {
                return BadRequest(new { Error = "Invalid token." });
            }

            return Ok(await m_productoDetallesRepository.GetAllProductsDetails());
        }

        [HttpPost]
        public async Task<IActionResult> InsertProductDetails([FromQuery] string i_token, [FromBody] ProductoDetalles i_productDetails)
        {
            bool userValidated = await HelperMethods.ValidateToken(m_usuarioRepository, i_token);
            if (!userValidated)
            {
                return BadRequest(new { Error = "Invalid token." });
            }

            return Ok(await m_productoDetallesRepository.InsertProductDetails(i_productDetails));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductDetails([FromQuery] string i_token, [FromQuery] int i_productDetailsId)
        {
            bool userValidated = await HelperMethods.ValidateToken(m_usuarioRepository, i_token);
            if (!userValidated)
            {
                return BadRequest(new { Error = "Invalid token." });
            }

            return Ok(await m_productoDetallesRepository.DeleteProductDetails(new() { Codigo_Producto = i_productDetailsId }));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductDetails([FromQuery] string i_token, [FromBody] ProductoDetalles i_productDetails)
        {
            bool userValidated = await HelperMethods.ValidateToken(m_usuarioRepository, i_token);
            if (!userValidated)
            {
                return BadRequest(new { Error = "Invalid token." });
            }

            return Ok(await m_productoDetallesRepository.UpdateProductDetails(i_productDetails));
        }

        private readonly IProductoDetallesRepository m_productoDetallesRepository;
        private readonly IUsuarioRepository m_usuarioRepository;
    }
}
