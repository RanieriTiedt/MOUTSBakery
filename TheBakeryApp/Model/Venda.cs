namespace TheBakeryApp.Model
{
    public class Venda
    {
        public int Id { get; set; }
        public int? ClienteId { get; set; }
        public Cliente? Cliente { get; set; }
        public List<Produto> Produtos { get; set; } = new List<Produto>();
        public DateTime DataVenda { get; set; }
        public decimal Total { get; set; }
        public string FormaPagamento { get; set; }
        public int NumeroCupomFiscal { get; set; }

        public List<VendaProduto> VendasProduto { get; set; } = new List<VendaProduto>();


        public void ComputarPontos(Venda venda)
        {
            if (venda.Cliente != null)
            {
                int pontosGanhos = (int)(venda.Total / 10); // Exemplo: 1 ponto a cada R$10
                venda.Cliente.Pontos += pontosGanhos;
            }
        }
    }
}
