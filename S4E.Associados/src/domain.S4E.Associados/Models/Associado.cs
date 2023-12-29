namespace domain.S4E.Associados.Models
{
    public class Associado
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime Nascimento { get; set; }
        public virtual IList<Empresa>? Empresas { get; set; }
    }
}
