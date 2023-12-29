namespace entities.S4E.Associados;
public class Associado
{
    public long Id { get; set; }
    public string Nome { get; set; }
    public string CPF { get; set; }
    public DateTime Nascimento { get; set; }
    public virtual ICollection<AssociadoEmpresa>? AssociadoEmpresas { get; set; }
}
