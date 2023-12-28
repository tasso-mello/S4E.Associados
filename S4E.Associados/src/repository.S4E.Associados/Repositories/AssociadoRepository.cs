using entities.S4E.Associados;
using repository.S4E.Associados.Context;
using repository.S4E.Associados.Infrastructure;

namespace repository.S4E.Associados.Repositories
{
    public interface IAssociadoRepository : IRepository<Associado> { }

    public class AssociadoRepository : Repository<Associado>, IAssociadoRepository
    {
        public AssociadoRepository(ApplicationDbContext dbContext) : base(dbContext) { }
    }
}
