namespace TheBakeryApp.Model
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public bool Fidelizado { get; set; }
        public int? Pontos { get; set; }
    }
}
