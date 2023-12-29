using AutoMapper;

namespace domain.S4E.Associados.Extensions
{
    public static class Convertions
    {
        public static IMapper mapper;

        #region Associado

        public static Models.Associado ToAssociadoModel(this entities.S4E.Associados.Associado associado)
        {
            var converted = mapper.Map<Models.Associado>(associado);
            converted.Empresas = mapper.Map<List<Models.Empresa>>(associado.AssociadoEmpresas.Select(e => e.Empresa)); 

            return converted;
        }

        public static entities.S4E.Associados.Associado ToAssociadoEntity(this Models.Associado associado)
            => mapper.Map<entities.S4E.Associados.Associado>(associado);

        #endregion Associado

        #region Empresa

        public static Models.Empresa ToEmpresaModel(this entities.S4E.Associados.Empresa empresa)
        {
            var converted = mapper.Map<Models.Empresa>(empresa);
            converted.Associados = mapper.Map<List<Models.Associado>>(empresa.AssociadosEmpresa.Select(e => e.Associado));

            return converted;

        }

        public static entities.S4E.Associados.Empresa ToEmpresaEntity(this Models.Empresa empresa)
            => mapper.Map<entities.S4E.Associados.Empresa>(empresa);

        #endregion Empresa

        #region AssociadoEmpresa

        public static List<entities.S4E.Associados.AssociadoEmpresa> ToAssociadoEmpresaEntity(this IList<Models.Empresa> empresas, long id)
        {
            var associadoEmpresa = new List<entities.S4E.Associados.AssociadoEmpresa>();

            foreach (var entity in empresas)
            {
                associadoEmpresa.Add(new entities.S4E.Associados.AssociadoEmpresa(id, entity.Id));
            }

            return associadoEmpresa;
        }

        public static List<entities.S4E.Associados.AssociadoEmpresa> ToAssociadoEmpresaEntity(this IList<Models.Associado> associados, long id)
        {
            var associadoEmpresa = new List<entities.S4E.Associados.AssociadoEmpresa>();

            foreach (var entity in associados)
            {
                associadoEmpresa.Add(new entities.S4E.Associados.AssociadoEmpresa(entity.Id, id));
            }

            return associadoEmpresa;
        }

        #endregion AssociadoEmpresa
    }
}
