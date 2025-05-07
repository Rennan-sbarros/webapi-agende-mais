using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi_agende_mais.src.Repositories;

namespace webapi_agende_mais.src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TestController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("test-connection")]
        public IActionResult TestConnection()
        {
            try
            {
                // Obter a conexão subjacente do banco de dados
                var connection = _context.Database.GetDbConnection();
                connection.Open(); // Abrir a conexão
                connection.Close(); // Fechar a conexão
                return Ok("Conexão com o banco de dados bem-sucedida!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao conectar ao banco de dados: {ex.Message}");
            }
        }
    }
}
