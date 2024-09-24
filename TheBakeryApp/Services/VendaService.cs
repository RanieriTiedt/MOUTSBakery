using Microsoft.Extensions.Primitives;
using TheBakeryApp.Infrastructure;
using TheBakeryApp.Interfaces;
using TheBakeryApp.Model;

namespace TheBakeryApp.Services
{
    public class VendaService : IVenda
    {
        private readonly AppDBContext _context;
        public VendaService(AppDBContext context)
        {
            _context = context;
        }
        public async Task CriarNovaVenda(Venda venda)
        {
            if (venda.ClienteId == 0)
            {
                venda.ClienteId = null;
            }
            Venda v =_context.Vendas.Last();
            venda.NumeroCupomFiscal = v.NumeroCupomFiscal++;
            venda.DataVenda = DateTime.Now;
            _context.Vendas.Add(venda);
            await _context.SaveChangesAsync();
        }
    }
}
