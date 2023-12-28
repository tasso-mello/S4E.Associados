namespace entities.S4E.Associados;
public class Associado: Audit
{
    public long Id { get; set; }
    public string Nome { get; set; }
    public string CPF { get; set; }
    public DateTime Nascimento { get; set; }
    public virtual ICollection<Empresa>? Empresas { get; set; }
}
