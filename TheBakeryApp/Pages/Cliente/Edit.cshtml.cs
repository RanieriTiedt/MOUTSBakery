using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TheBakeryApp.Interfaces;

namespace TheBakeryApp.Pages.Cliente
{
    public class EditModel : PageModel
    {
        private readonly ICliente _cliente;

        public EditModel(ICliente cliente)
        {
            _cliente = cliente;
        }

        [BindProperty]
        public TheBakeryApp.Model.Cliente Cliente { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente =  await _cliente.GetClienteById(id.Value);
            if (cliente == null)
            {
                return NotFound();
            }
            Cliente = cliente;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await _cliente.UpdateCliente(Cliente);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _cliente.ClienteExiste(Cliente.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }
        
    }
}
