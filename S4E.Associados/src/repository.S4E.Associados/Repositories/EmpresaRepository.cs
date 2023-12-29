using entities.S4E.Associados;
using repository.S4E.Associados.Context;
using repository.S4E.Associados.Infrastructure;

namespace repository.S4E.Associados.Repositories
{
    public interface IEmpresaRepository : IRepository<Empresa> { }

    public class EmpresaRepository : Repository<Empresa>, IEmpresaRepository
    {
        public EmpresaRepository(ApplicationDbContext dbContext) : base(dbContext) { }
    }
}
