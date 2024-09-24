using Microsoft.AspNetCore.Mvc.RazorPages;
using TheBakeryApp.Interfaces;

namespace TheBakeryApp.Pages.Cliente
{
    public class IndexModel : PageModel
    {
        private readonly ICliente _cliente;

        public IndexModel(ICliente cliente)
        {
            _cliente = cliente;
        }

        public IList<TheBakeryApp.Model.Cliente> Cliente { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Cliente = await _cliente.ObterTodosClientes();
        }
    }
}
