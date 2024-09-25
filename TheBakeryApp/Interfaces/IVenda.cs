using Microsoft.Extensions.Primitives;
using TheBakeryApp.Model;

namespace TheBakeryApp.Interfaces
{
    public interface IVenda
    {
        Task<int> CriarNovaVenda(Venda venda);
        Task<Venda> BuscarVendaPorId(int id);
    }
}
