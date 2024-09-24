using Microsoft.AspNetCore.Mvc.RazorPages;
using TheBakeryApp.Interfaces;

namespace TheBakeryApp.Pages.Produto
{
    public class IndexModel : PageModel
    {
        private readonly IProduto _produto;

        public IndexModel(IProduto produto)
        {
            _produto = produto;
        }

        public IList<TheBakeryApp.Model.Produto> Produto { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Produto = await _produto.ObterTodosProdutos();
        }
    }
}
