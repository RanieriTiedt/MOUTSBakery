using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TheBakeryApp.Interfaces;

namespace TheBakeryApp.Pages.Produto
{
    public class EditModel : PageModel
    {
        private readonly IProduto _produto;

        public EditModel(IProduto produto)
        {
            _produto = produto;
        }

        [BindProperty] public TheBakeryApp.Model.Produto Produto { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _produto.GetProdutosById(id.Value);
            if (produto == null)
            {
                return NotFound();
            }

            Produto = produto;
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
                await _produto.UpdateProduto(Produto);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _produto.ProdutoExiste(Produto.Id))
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