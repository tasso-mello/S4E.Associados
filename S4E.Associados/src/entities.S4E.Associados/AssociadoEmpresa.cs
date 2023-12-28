using System.ComponentModel.DataAnnotations.Schema;

namespace entities.S4E.Associados;

public class AssociadoEmpresa
{
    public long AssociadoId { get; set; }
    [ForeignKey("Associado")]
    public virtual Associado Associado { get; set; }    
    public long EmpresaId { get; set; }
    [ForeignKey("Empresa")]
    public virtual Empresa Empresa { get; set; }
}
