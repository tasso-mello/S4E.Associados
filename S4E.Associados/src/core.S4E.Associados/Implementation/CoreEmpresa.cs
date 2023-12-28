namespace core.S4E.Associados.Implementation
{
    using core.S4E.Associados.Contracts;
    using domain.S4E.Associados.Models;

    public class CoreEmpresa : ICoreEmpresa
    {
        public Task<string> Delete(int id)
        {
            throw new NotImplementedException();
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

        public Task<string> Post(Empresa model)
        {
            throw new NotImplementedException();
        }

        public Task<string> Put(Empresa model)
        {
            throw new NotImplementedException();
        }
    }
}
