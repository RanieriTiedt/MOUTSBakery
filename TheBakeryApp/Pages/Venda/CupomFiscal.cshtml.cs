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
    public class CupomFiscalModel : PageModel
    {
        private readonly TheBakeryApp.Infrastructure.AppDBContext _context;

        public CupomFiscalModel(TheBakeryApp.Infrastructure.AppDBContext context)
        {
            _context = context;
        }

        public CupomFiscal CupomFiscal { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cupomfiscal = await _context.CupomFiscal.FirstOrDefaultAsync(m => m.Id == id);
            if (cupomfiscal == null)
            {
                return NotFound();
            }
            else
            {
                CupomFiscal = cupomfiscal;
            }
            return Page();
        }
    }
}
