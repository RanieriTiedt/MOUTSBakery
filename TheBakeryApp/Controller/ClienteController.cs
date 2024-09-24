using Microsoft.AspNetCore.Mvc;
using TheBakeryApp.Model;

namespace TheBakeryApp.Controller
{
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        [HttpGet("{cpf}/pontos")]
        public IActionResult GetPontosCliente(string cpf)
        {
            var cliente = new Cliente();
        if (cliente == null)
                return NotFound("Cliente não encontrado");

            return Ok(new { cliente.Nome, cliente.Pontos });
        }
    }
}
