using entities.S4E.Associados;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace repository.S4E.Associados.Configurations;

public class AssociadoEmpresaConfiguration : IEntityTypeConfiguration<AssociadoEmpresa>
{
    public void Configure(EntityTypeBuilder<AssociadoEmpresa> builder)
    {
        builder.HasKey(ae => new { ae.AssociadoId, ae.EmpresaId });

        builder.HasOne(ae => ae.Associado)
               .WithMany(a => a.AssociadoEmpresas)
               .HasForeignKey(ae => ae.AssociadoId)
               .OnDelete(DeleteBehavior.Cascade); ;

        builder.HasOne(ae => ae.Empresa)
               .WithMany(e => e.AssociadosEmpresa)
               .HasForeignKey(ae => ae.EmpresaId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
