namespace core.S4E.Associados.Implementation
{
    using AutoMapper;
    using core.S4E.Associados.Contracts;
    using domain.S4E.Associados.Extensions;
    using domain.S4E.Associados.Models;
    using repository.S4E.Associados.Repositories;
    using System.Linq.Expressions;

    public class CoreEmpresa : ICoreEmpresa
    {
        private readonly IEmpresaRepository empresaRepository;
        private readonly IAssociadoEmpresaRepository associadoEmpresaRepository;

        public CoreEmpresa(IMapper mapper, IEmpresaRepository associadoRepository, IAssociadoEmpresaRepository associadoEmpresaRepository)
        {
            Convertions.mapper = mapper;
            this.empresaRepository = associadoRepository;
            this.associadoEmpresaRepository = associadoEmpresaRepository;
        }

        public async Task<string> Get(int id)
            => Responses.GetResponse("empresa", (await empresaRepository.ReadOne(a => a.Id == id, GetIncludes())).ToEmpresaModel());

        public async Task<string> Get(int skip, int take)
            => Responses.GetResponse("empresa", (await empresaRepository.Read(GetIncludes())).Select(a => a.ToEmpresaModel()));

        public async Task<string> Get(string filter, int skip, int take)
            => Responses.GetResponse("empresa", (await empresaRepository.Read(GetFilter(filter), GetIncludes())).Select(a => a.ToEmpresaModel()));

        public async Task<string> Post(Empresa model)
        {
            var entityAssociado = model.ToEmpresaEntity();
            var empresaCriada = await empresaRepository.Create(entityAssociado);

            var associadoEmpresa = model.Associados.ToAssociadoEmpresaEntity(empresaCriada.Id);
            if (associadoEmpresa != null)
                await associadoEmpresaRepository.Create(associadoEmpresa);

            return Responses.GetCreatedResponse("empresa", empresaCriada.Id, "Empresa salva.");
        }

        public async Task<string> Put(Empresa model)
        {
            var entityAssociado = model.ToEmpresaEntity();
            var empresaModificada = await empresaRepository.Update(entityAssociado);

            await associadoEmpresaRepository.Delete(ae => ae.EmpresaId == empresaModificada.Id);

            var associadoEmpresa = model.Associados.ToAssociadoEmpresaEntity(empresaModificada.Id);
            if (associadoEmpresa != null)
                await associadoEmpresaRepository.Create(associadoEmpresa);

            return Responses.GetCreatedResponse("empresa", empresaModificada.Id, "Empresa modificada.");
        }

        public async Task<string> Delete(int id)
        {
            var associadosEmpresa = await associadoEmpresaRepository.Read(a => a.AssociadoId == id);

            foreach (var associadoEmpresa in associadosEmpresa)
                await associadoEmpresaRepository.Delete(associadoEmpresa);

            await empresaRepository.Delete(id);
            return Responses.GetObjectResponse("empresa", "Empresa removido.");
        }

        private Expression<Func<entities.S4E.Associados.Empresa, bool>> GetFilter(string filter)
            => p => p.Nome.Contains(filter) || p.CNPJ.Contains(filter);

        private List<string> GetIncludes()
            => new List<string> { "AssociadosEmpresa", "AssociadosEmpresa.Associado" };
    }
}
