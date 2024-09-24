using Microsoft.EntityFrameworkCore;
using TheBakeryApp.Infrastructure;
using TheBakeryApp.Interfaces;
using TheBakeryApp.Model;

namespace TheBakeryApp.Services;

public class ProdutoService : IProduto
{
    private readonly AppDBContext _context;

    public ProdutoService(AppDBContext context)
    {
        _context = context;
    }

    public async Task<List<Model.Produto>> ObterTodosProdutos()
    {
        return await _context.Produtos.ToListAsync();
    }

    public async Task<Model.Produto> GetProdutosById(int id)
    {
        return await _context.Produtos.FirstOrDefaultAsync(x => x.Id == id);
    }
    public async Task<bool> ProdutoExiste(int id)
    {
        return await _context.Produtos.AnyAsync(x => x.Id == id);
    }

    public async Task<Model.Produto> UpdateProduto(Model.Produto produto)
    {
        _context.Produtos.Attach(produto).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return produto;
    }
    public async Task AdicionarProdutos(Model.Produto produto)
    {
        _context.Produtos.Add(produto);
        await _context.SaveChangesAsync();
    }

    public async Task RemoverProdutos(int id)
    {
        var getProduct = await GetProdutosById(id);
        _context.Remove(getProduct);
    }
}