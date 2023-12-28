namespace entities.S4E.Associados;
public class Empresa : Audit
{
    public long Id { get; set; }
    public string Nome { get; set; }
    public string CNPJ { get; set; }
    public virtual ICollection<Associado>? Associados { get; set; }
}
