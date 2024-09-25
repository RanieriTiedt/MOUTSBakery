using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using TheBakeryApp.Infrastructure;
using TheBakeryApp.Interfaces;
using TheBakeryApp.Model;

namespace TheBakeryApp.Services
{
    public class VendaService : IVenda
    {
        private readonly AppDBContext _context;
        private readonly ICliente _cliente;
        public VendaService(AppDBContext context, ICliente cliente)
        {
            _context = context;
            _cliente = cliente;

        }

        public async Task<Venda> BuscarVendaPorId(int id)
        {
            var venda = await _context.Vendas.FirstOrDefaultAsync(v => v.Id == id);

            var produtoVenda = await _context.VendaProduto.Where(x => x.VendaId == id).ToListAsync();

            var produtoIds = produtoVenda.Select(y => y.ProdutoId).ToList();

            var produtos = await _context.Produtos.Where(p => produtoIds.Contains(p.Id)).ToListAsync();

            venda.Produtos.AddRange(produtos);

            if(venda.ClienteId != null)
            {
                var cliente = await _cliente.GetClienteById(venda.ClienteId.Value);
                venda.Cliente = cliente;
            }

            return venda;
        }

        public async Task<int> CriarNovaVenda(Venda venda)
        {
            if (venda.ClienteId == 0)
            {
                venda.ClienteId = null;
            }
            var v = _context.Vendas.OrderByDescending(x => x.Id).FirstOrDefault();
            venda.NumeroCupomFiscal = v.NumeroCupomFiscal + 1;
            venda.DataVenda = DateTime.Now;
            _context.Vendas.Add(venda);
            await _context.SaveChangesAsync();
            var cliente = await _cliente.GetClienteById(venda.ClienteId.Value);
            if (venda.ClienteId > 0 && cliente.Fidelizado)
            {
                cliente.Pontos += 5;
                await _cliente.UpdateCliente(cliente);
            }
            return venda.Id;
        }
    }
}
