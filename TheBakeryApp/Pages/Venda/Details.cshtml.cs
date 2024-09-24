using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TheBakeryApp.Infrastructure;
using TheBakeryApp.Model;

namespace TheBakeryApp.Pages.Venda
{
    public class DetailsModel : PageModel
    {
        private readonly TheBakeryApp.Infrastructure.AppDBContext _context;

        public DetailsModel(TheBakeryApp.Infrastructure.AppDBContext context)
        {
            _context = context;
        }

        public TheBakeryApp.Model.Venda Venda { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venda = await _context.Vendas.FirstOrDefaultAsync(m => m.Id == id);
            if (venda == null)
            {
                return NotFound();
            }
            else
            {
                Venda = venda;
            }
            return Page();
        }
    }
}
