namespace entities.S4E.Associados;
public class Empresa
{
    public long Id { get; set; }
    public string Nome { get; set; }
    public string CNPJ { get; set; }
    public virtual ICollection<AssociadoEmpresa>? AssociadosEmpresa { get; set; }
}
