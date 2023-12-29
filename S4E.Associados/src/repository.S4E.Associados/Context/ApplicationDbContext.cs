namespace repository.S4E.Associados.Context
{
    using entities.S4E.Associados;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Associado> Associados { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<AssociadoEmpresa> AssociadoEmpresa { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
