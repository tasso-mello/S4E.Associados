using AutoMapper;

namespace domain.S4E.Empresas.Mapper
{
    public class EmpresaMapping : Profile
    {
        public EmpresaMapping()
        {
            CreateMap<Associados.Models.Empresa, entities.S4E.Associados.Empresa>();
            CreateMap<entities.S4E.Associados.Empresa, Associados.Models.Empresa>();
        }
    }
}