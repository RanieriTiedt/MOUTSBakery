using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheBakeryApp.Interfaces;

namespace TheBakeryApp.Pages.Cliente
{
    public class CreateModel : PageModel
    {
        private readonly ICliente _cliente;

        public CreateModel(ICliente cliente)
        {
            _cliente = cliente;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TheBakeryApp.Model.Cliente Cliente { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            // if (!ModelState.IsValid)
            // {
            //     return Page();
            // }

           await _cliente.AdicionarCliente(Cliente);

            return RedirectToPage("./Index");
        }
    }
}
