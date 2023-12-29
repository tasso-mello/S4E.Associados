using entities.S4E.Associados;
using repository.S4E.Associados.Context;
using repository.S4E.Associados.Infrastructure;

namespace repository.S4E.Associados.Repositories
{
    public interface IAssociadoEmpresaRepository : IRepository<AssociadoEmpresa> { }

    public class AssociadoEmpresaRepository : Repository<AssociadoEmpresa>, IAssociadoEmpresaRepository
    {
        public AssociadoEmpresaRepository(ApplicationDbContext dbContext) : base(dbContext) { }
    }
}
