namespace TheBakeryApp.Model
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco {get; set;}
        public string Descricao { get; set; }
        public ICollection<VendaProduto>? VendasProduto { get; set; }
    }
}
