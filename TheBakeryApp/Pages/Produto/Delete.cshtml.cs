using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TheBakeryApp.Infrastructure;
using TheBakeryApp.Interfaces;

namespace TheBakeryApp.Pages.Produto
{
    public class DeleteModel : PageModel
    {
        private readonly IProduto _produto;
        private readonly AppDBContext _dbContext;

        public DeleteModel(IProduto produto, AppDBContext dBContext)
        {
            _produto = produto;
            _dbContext = dBContext;
        }

        [BindProperty]
        public TheBakeryApp.Model.Produto Produto { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _dbContext.Produtos.FirstOrDefaultAsync(m => m.Id == id);

            if (produto == null)
            {
                return NotFound();
            }
            else
            {
                Produto = produto;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _dbContext.Produtos.FindAsync(id);
            if (produto != null)
            {
                Produto = produto;
                _dbContext.Produtos.Remove(produto);
                await _dbContext.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
