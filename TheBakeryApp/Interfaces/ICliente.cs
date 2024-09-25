using TheBakeryApp.Model;

namespace TheBakeryApp.Interfaces;

public interface ICliente
{
    Task<List<Model.Cliente>> ObterTodosClientes();
    Task<Model.Cliente> GetClienteById(int id);
    Task<bool> ClienteExiste(int id);
    Task<Model.Cliente> UpdateCliente(Model.Cliente cliente);
    Task AdicionarCliente(Model.Cliente cliente);
    Task RemoverCliente(int id);
    Task<Cliente> BuscaPontoClientePorCPF(string cpf);
}