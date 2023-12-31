﻿namespace core.S4E.Associados.Implementation
{
    using AutoMapper;
    using core.S4E.Associados.Contracts;
    using domain.S4E.Associados.Extensions;
    using domain.S4E.Associados.Models;
    using repository.S4E.Associados.Repositories;
    using System.Linq.Expressions;

    public class CoreAssociado : ICoreAssociado
    {
        private readonly IAssociadoRepository associadoRepository;
        private readonly IAssociadoEmpresaRepository associadoEmpresaRepository;

        public CoreAssociado(IMapper mapper, IAssociadoRepository associadoRepository, IAssociadoEmpresaRepository associadoEmpresaRepository)
        {
            Convertions.mapper = mapper;
            this.associadoRepository = associadoRepository;
            this.associadoEmpresaRepository = associadoEmpresaRepository;
        }

        public async Task<string> Get(int id)
            => Responses.GetResponse("associado", (await associadoRepository.ReadOne(a => a.Id == id, GetIncludes())).ToAssociadoModel());

        public async Task<string> Get(int skip, int take)
            => Responses.GetResponse("associado", (await associadoRepository.Read(GetIncludes())).Select(a => a.ToAssociadoModel()));
        
        public async Task<string> Get(string filter, int skip, int take)
            => Responses.GetResponse("associado", (await associadoRepository.Read(GetFilter(filter), GetIncludes())).Select(a => a.ToAssociadoModel()));

        public async Task<string> Post(Associado model)
        {
            var entityAssociado = model.ToAssociadoEntity();
            var associadoCriado = await associadoRepository.Create(entityAssociado);

            var associadoEmpresa = model.Empresas.ToAssociadoEmpresaEntity(associadoCriado.Id);
            if (associadoEmpresa != null)
                await associadoEmpresaRepository.Create(associadoEmpresa);

            return Responses.GetCreatedResponse("associado", associadoCriado.Id, "Associado salvo.");
        }

        public async Task<string> Put(Associado model)
        {
            var entityAssociado = model.ToAssociadoEntity();
            var associadoModificado = await associadoRepository.Update(entityAssociado);

            await associadoEmpresaRepository.Delete(ae => ae.AssociadoId == associadoModificado.Id);

            var associadoEmpresa = model.Empresas.ToAssociadoEmpresaEntity(associadoModificado.Id);
            if (associadoEmpresa != null)
                await associadoEmpresaRepository.Create(associadoEmpresa);

            return Responses.GetCreatedResponse("associado", associadoModificado.Id, "Associado modificado.");
        }

        public async Task<string> Delete(int id)
        {
            var associadoEmpresas = await associadoEmpresaRepository.Read(a => a.AssociadoId == id);

            foreach (var associadoEmpresa in associadoEmpresas)
                await associadoEmpresaRepository.Delete(associadoEmpresa);

            await associadoRepository.Delete(id);
            
            return Responses.GetObjectResponse("associado", "Associado removido.");
        }

        private Expression<Func<entities.S4E.Associados.Associado, bool>> GetFilter(string filter)
            => p => p.Nome.Contains(filter) || p.CPF.Contains(filter);

        private List<string> GetIncludes()
            => new List<string> { "AssociadoEmpresas", "AssociadoEmpresas.Empresa" };
    }
}
