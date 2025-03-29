using BackendBDIII.Data;
using BackendBDIII.Data.Repositories;
using BackendBDIII.Model;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace BackendBDIII.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AlmacenController : ControllerBase
    {
        public AlmacenController(IAlmacenRepository i_almacenRepository, IUsuarioRepository i_usuarioRepository) 
        {
            m_almacenRepository = i_almacenRepository;
            m_usuarioRepository = i_usuarioRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStorageLocations([FromQuery] string i_token) 
        {
            bool userValidated = await HelperMethods.ValidateToken(m_usuarioRepository, i_token);
            if (!userValidated) 
            {
                return BadRequest(new { Error = "Invalid token." });
            }

            return Ok(await m_almacenRepository.GetAllStorageLocations());
        }

        [HttpPost]
        public async Task<IActionResult> InsertStorageLocation([FromQuery] string i_token, [FromBody] Almacen i_storageLocation)
        {
            bool userValidated = await HelperMethods.ValidateToken(m_usuarioRepository, i_token);
            if (!userValidated)
            {
                return BadRequest(new { Error = "Invalid token." });
            }

            return Ok(await m_almacenRepository.InsertStorageLocation(i_storageLocation));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteStorageLocation([FromQuery] string i_token, [FromQuery] int i_storageLocationId) 
        {
            bool userValidated = await HelperMethods.ValidateToken(m_usuarioRepository, i_token);
            if (!userValidated)
            {
                return BadRequest(new { Error = "Invalid token." });
            }

            return Ok(await m_almacenRepository.DeleteStorageLocation(new() { Codigo_Almacen = i_storageLocationId }));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStorageLocation([FromQuery] string i_token, [FromBody] Almacen i_storageLocation) 
        {
            bool userValidated = await HelperMethods.ValidateToken(m_usuarioRepository, i_token);
            if (!userValidated)
            {
                return BadRequest(new { Error = "Invalid token." });
            }

            return Ok(await m_almacenRepository.UpdateStorageLocation(i_storageLocation));
        }

        private readonly IAlmacenRepository m_almacenRepository;
        private readonly IUsuarioRepository m_usuarioRepository;
    }
}
