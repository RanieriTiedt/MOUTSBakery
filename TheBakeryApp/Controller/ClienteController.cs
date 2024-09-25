using Microsoft.AspNetCore.Mvc;
using TheBakeryApp.Interfaces;
using TheBakeryApp.Model;

namespace TheBakeryApp.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ICliente _cliente;
        public ClienteController(ICliente cliente)
        {
            _cliente = cliente;
        }
        [HttpGet("{cpf}/pontos")]
        public async Task<IActionResult> GetPontosCliente(string cpf)
        {
            var cliente = await _cliente.BuscaPontoClientePorCPF(cpf);
            if (cliente == null)
            {
                return NotFound("Cliente não encontrado!");
            }
            else if (cliente.Fidelizado == false)
            {
                return NotFound("Cliente não fidelizado!");
            }
            else
            {
                return Ok($"Pontos: {cliente.Pontos}");
            }
        }
    }
}
