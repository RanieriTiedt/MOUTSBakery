using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TheBakeryApp.Interfaces;

namespace TheBakeryApp.Pages.Venda
{
    public class IndexModel : PageModel
    {
        private readonly TheBakeryApp.Infrastructure.AppDBContext _context;

        public IndexModel(TheBakeryApp.Infrastructure.AppDBContext context)
        {
            _context = context;
        }

        public IList<TheBakeryApp.Model.Venda> Venda { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Venda = await _context.Vendas
                .Include(v => v.Cliente).ToListAsync();
        }
    }
}
