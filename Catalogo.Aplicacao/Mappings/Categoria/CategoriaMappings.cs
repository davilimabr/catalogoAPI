using AutoMapper;
using Catalogo.Aplicacao.DTO.Request;
using Catalogo.Aplicacao.DTO.Response;
using Catalogo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Aplicacao.Mappings.Categoria
{
    public class CategoriaMappings : Profile
    {
        public CategoriaMappings() 
        {
            CreateMap<CategoriaModel, CategoriaResponseDto>().ReverseMap();
            CreateMap<CategoriaRequestDto, CategoriaModel>().ReverseMap();
        }
    }
}
