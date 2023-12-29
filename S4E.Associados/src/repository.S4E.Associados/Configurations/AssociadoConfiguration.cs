using entities.S4E.Associados;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace repository.S4E.Associados.Configurations;

public class AssociadoConfiguration : IEntityTypeConfiguration<Associado>
{
    public void Configure(EntityTypeBuilder<Associado> builder)
    {
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Id).ValueGeneratedOnAdd();
        builder.Property(a => a.CPF).IsRequired().HasMaxLength(11);
        builder.HasIndex(a => a.CPF).IsUnique();

        builder.HasMany(a => a.AssociadoEmpresas)
               .WithOne(e => e.Associado)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
