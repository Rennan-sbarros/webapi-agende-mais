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
                // Testa a conexão com o banco de dados
                var canConnect = _context.Database.CanConnect();
                if (canConnect)
                {
                    return Ok("Conexão com o banco de dados bem-sucedida!");
                }
                else
                {
                    return StatusCode(500, "Não foi possível conectar ao banco de dados.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao conectar ao banco de dados: {ex.Message}");
            }
        }
    }
}
