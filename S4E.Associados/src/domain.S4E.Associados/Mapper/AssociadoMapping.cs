using AutoMapper;

namespace domain.S4E.Associados.Mapper
{
    public class AssociadoMapping : Profile
    {
        public AssociadoMapping()
        {
            CreateMap<Models.Associado, entities.S4E.Associados.Associado>();
            CreateMap<entities.S4E.Associados.Associado, Models.Associado>();
        }
    }
}
