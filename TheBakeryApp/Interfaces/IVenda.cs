using Microsoft.Extensions.Primitives;
using TheBakeryApp.Model;

namespace TheBakeryApp.Interfaces
{
    public interface IVenda
    {
        Task CriarNovaVenda(Venda venda);
    }
}
