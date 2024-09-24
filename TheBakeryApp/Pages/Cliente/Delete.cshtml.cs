using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TheBakeryApp.Infrastructure;
using TheBakeryApp.Interfaces;
using TheBakeryApp.Model;

namespace TheBakeryApp.Pages.Cliente
{
    public class DeleteModel : PageModel
    {
        private readonly ICliente _cliente;
        private readonly AppDBContext _dbContext;

        public DeleteModel(ICliente cliente, AppDBContext dBContext)
        {
            _cliente = cliente;
            _dbContext = dBContext;
        }

        [BindProperty]
        public TheBakeryApp.Model.Cliente Cliente { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _dbContext.Clientes.FirstOrDefaultAsync(m => m.Id == id);

            if (cliente == null)
            {
                return NotFound();
            }
            else
            {
                Cliente = cliente;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente =  await _dbContext.Clientes.FindAsync(id);
            if (cliente != null)
            {
                Cliente = cliente;
                _dbContext.Clientes.Remove(cliente);
                await _dbContext.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
