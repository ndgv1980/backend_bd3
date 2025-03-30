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
    public class OperatorCommentsController : ControllerBase
    {
        public OperatorCommentsController(IOperatorCommentsRepository i_operatorCommentsRepository, IUsuarioRepository i_usuarioRepository) 
        {
            m_operatorCommentsRepository = i_operatorCommentsRepository;
            m_usuarioRepository = i_usuarioRepository;
        }

        [HttpPost]
        public async Task<IActionResult> InsertStorageLocation([FromQuery] string i_token, [FromBody] Comment i_comment)
        {
            bool userValidated = await HelperMethods.ValidateToken(m_usuarioRepository, i_token);
            if (!userValidated)
            {
                return BadRequest(new { Error = "Invalid token." });
            }

            int userId = await HelperMethods.GetUserIdFromToken(m_usuarioRepository, i_token);

            if (userId == -1) 
            {
                return BadRequest(new { Error = "Something went wrong!" });
            }

            return Ok(await m_operatorCommentsRepository.InsertComment(new()
            {
                Title = i_comment.Title,
                Text = i_comment.Text,
                Time = DateTime.Now,
                UserID = userId,
            }));
        }

        private readonly IOperatorCommentsRepository m_operatorCommentsRepository;
        private readonly IUsuarioRepository m_usuarioRepository;
    }
}
