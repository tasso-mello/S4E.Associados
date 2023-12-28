using entities.S4E.Associados;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace repository.S4E.Empresas.Configurations;

public class EmpresaConfiguration : IEntityTypeConfiguration<Empresa>
{
    public void Configure(EntityTypeBuilder<Empresa> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(a => a.Id).ValueGeneratedOnAdd();
        builder.Property(e => e.CNPJ).IsRequired().HasMaxLength(14);
        builder.HasIndex(e => e.CNPJ).IsUnique();
    }
}
