namespace core.S4E.Associados.Implementation
{
    using core.S4E.Associados.Contracts;
    using domain.S4E.Associados.Models;
    using repository.S4E.Associados.Repositories;

    public class CoreAssociado : ICoreAssociado
    {
        private readonly IAssociadoRepository associadoRepository;

        public CoreAssociado(IAssociadoRepository associadoRepository)
        {
            this.associadoRepository = associadoRepository;
        }

        public Task<string> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<string> Get(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public Task<string> Get(string filter, int skip, int take)
        {
            throw new NotImplementedException();
        }

        public Task<string> Post(Associado model)
        {
            throw new NotImplementedException();
        }

        public Task<string> Put(Associado model)
        {
            throw new NotImplementedException();
        }

        public Task<string> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
