using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;
using TheBakeryApp.Interfaces;

namespace TheBakeryApp.Pages.Produto
{
    public class CreateModel : PageModel
    {
        private readonly IProduto _produto;

        public CreateModel(IProduto produto)
        {
            _produto = produto;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TheBakeryApp.Model.Produto Produto { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            /*if (!ModelState.IsValid)
            {
                return Page();
            }*/

            await _produto.AdicionarProdutos(Produto);

            return RedirectToPage("./Index");
        }
    }
}
