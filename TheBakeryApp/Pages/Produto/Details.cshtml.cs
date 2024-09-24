using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheBakeryApp.Interfaces;

namespace TheBakeryApp.Pages.Produto
{
    public class DetailsModel : PageModel
    {
        private readonly IProduto _produto;

        public DetailsModel(IProduto produto)
        {
            _produto = produto;
        }

        public TheBakeryApp.Model.Produto Produto { get; set; } = default!;

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
            else
            {
                Produto = produto;
            }
            return Page();
        }
    }
}
