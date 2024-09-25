using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheBakeryApp.Infrastructure;
using TheBakeryApp.Interfaces;
using TheBakeryApp.Model;

namespace TheBakeryApp.Services;

public class ClienteService : ICliente
{
    private readonly AppDBContext _context;

    public ClienteService(AppDBContext context)
    {
        _context = context;
    }
    public async Task<List<Model.Cliente>> ObterTodosClientes()
    {
        return await _context.Clientes.ToListAsync();
    }

    public async Task<Model.Cliente> GetClienteById(int id)
    {
        return await _context.Clientes.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<bool> ClienteExiste(int id)
    {
        return await _context.Clientes.AnyAsync(x => x.Id == id);
    }

    public async Task<Cliente> UpdateCliente(Cliente cliente)
    {
        _context.Clientes.Attach(cliente).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return cliente;
    }

    public async Task AdicionarCliente(Model.Cliente cliente)
    {
        if(cliente.Fidelizado && cliente.Pontos == null)
        {
            cliente.Pontos = 0;
        }
        _context.Clientes.Add(cliente);
        await _context.SaveChangesAsync();
    }

    public async Task RemoverCliente(int id)
    {
        var getProduct = await GetClienteById(id);
        _context.Remove(getProduct);
    }

    public async Task<Cliente> BuscaPontoClientePorCPF(string cpf)
    {
        return await _context.Clientes.FirstOrDefaultAsync(x => x.CPF == cpf);

    }
}