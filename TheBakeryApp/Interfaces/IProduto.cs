using Microsoft.EntityFrameworkCore;

namespace TheBakeryApp.Interfaces;

public interface IProduto
{
    Task<List<Model.Produto>> ObterTodosProdutos();
    Task<Model.Produto> GetProdutosById(int id);
    Task<bool> ProdutoExiste(int id);
    Task<Model.Produto> UpdateProduto(Model.Produto produto);
    Task AdicionarProdutos(Model.Produto produto);
    Task RemoverProdutos(int id);
}