using BackendBDIII.Data;
using BackendBDIII.Data.MongoDBRepositories;
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
        public ProductoController(IProductoRepository i_productoRepository, IUsuarioRepository i_usuarioRepository, IProductsHistoryRepository i_productsHistoryRepository) 
        {
            m_productoRepository = i_productoRepository;
            m_usuarioRepository = i_usuarioRepository;
            m_productsHistoryRepository = i_productsHistoryRepository;
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

            await m_productsHistoryRepository.InsertProductHistory(new()
            {
                Codigo_Producto = i_product.Codigo_Producto,
                Nombre_Producto = i_product.Nombre_Producto,
                Precio_Unitario = i_product.Precio_Unitario,
                Fecha = DateTime.Now,
                Operacion = "Insert"
            });

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

            await m_productsHistoryRepository.InsertProductHistory(new()
            {
                Codigo_Producto = i_productId,
                Fecha = DateTime.Now,
                Operacion = "Delete"
            });

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

            await m_productsHistoryRepository.InsertProductHistory(new() 
            {
                Codigo_Producto = i_product.Codigo_Producto,
                Nombre_Producto = i_product.Nombre_Producto,
                Precio_Unitario = i_product.Precio_Unitario,
                Fecha = DateTime.Now,
                Operacion = "Update"
            });

            return Ok(await m_productoRepository.UpdateProduct(i_product));
        }

        private readonly IProductoRepository m_productoRepository;
        private readonly IUsuarioRepository m_usuarioRepository;
        private readonly IProductsHistoryRepository m_productsHistoryRepository;
    }
}
