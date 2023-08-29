using APICatalago.Domain;
using APICatalago.DTO;
using AutoMapper;

namespace APICatalago.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Categoria, CategoriaDto>().ReverseMap();
            CreateMap<Produto, ProdutoDto>().ReverseMap(); 
        }
    }
}
