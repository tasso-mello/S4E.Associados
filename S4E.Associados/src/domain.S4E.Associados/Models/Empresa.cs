namespace domain.S4E.Associados.Models
{
    public class Empresa
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public IList<Associado>? Associados { get; set; }
    }
}
