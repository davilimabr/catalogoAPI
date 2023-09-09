using AutoMapper;
using Catalogo.Aplicacao.DTO;
using Catalogo.Domain.Models;

namespace Catalogo.Aplicacao.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CategoriaModel, CategoriaDto>().ReverseMap();
            CreateMap<ProdutoModel, ProdutoDto>().ReverseMap(); 
        }
    }
}
