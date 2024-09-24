namespace TheBakeryApp.Model
{
    public class CupomFiscal
    {
        public int Id { get; set; }
        public string FormaPagamento { get; set; }
        public Cliente? Cliente { get; set; }
        public List<Produto> Produtos { get; set; } = new List<Produto>();
        public DateTime DataVenda { get; set; }
    }
}
