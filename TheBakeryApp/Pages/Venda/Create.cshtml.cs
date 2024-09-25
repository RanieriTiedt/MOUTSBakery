using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TheBakeryApp.Interfaces;
using TheBakeryApp.Model;

namespace TheBakeryApp.Pages.Venda
{
    public class CreateModel : PageModel
    {

        private readonly IProduto _produto;
        private readonly ICliente _cliente;
        private readonly IVenda _venda;
        public CreateModel(IProduto produto, ICliente cliente, IVenda venda)
        {
            _produto = produto;
            _cliente = cliente;
            _venda = venda;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            // Adiciona um cliente nulo
            var clientes = await _cliente.ObterTodosClientes();

            // Adiciona a opção nula
            var cliente = new TheBakeryApp.Model.Cliente
            {
                Nome = "Nenhum Cliente"
            };
            clientes.Insert(0, cliente);

            // Prepara a lista de clientes para a view
            ViewData["ClienteId"] = new SelectList(clientes, "Id", "Nome");

            // Obtém todos os produtos
            var produtos = await _produto.ObterTodosProdutos();
            ViewData["Produtos"] = produtos;

            return Page();
        }

        [BindProperty]
        public TheBakeryApp.Model.Venda Venda { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            // Coletar os IDs dos produtos selecionados
            var produtosSelecionados = Request.Form["produtosSelecionados"];
            foreach (var produtoId in produtosSelecionados)
            {
                // Adiciona o produto à venda
                var vendaProduto = new VendaProduto
                {
                    ProdutoId = int.Parse(produtoId),
                    Quantidade = int.Parse(Request.Form[$"VendasProduto[{produtoId}].Quantidade"])
                };

                Venda.VendasProduto.Add(vendaProduto);
            }

            var criaVenda = await _venda.CriarNovaVenda(Venda);

            return Redirect($"./Details?id={criaVenda}");
        }
    }
}
