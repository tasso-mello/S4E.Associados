using System.ComponentModel.DataAnnotations.Schema;

namespace entities.S4E.Associados;

public class AssociadoEmpresa
{
    public AssociadoEmpresa(long associadoId, long empresaId)
    {
        AssociadoId = associadoId;
        EmpresaId = empresaId;
    }

    public long AssociadoId { get; set; }
    public virtual Associado Associado { get; set; }    
    public long EmpresaId { get; set; }
    public virtual Empresa Empresa { get; set; }
}
