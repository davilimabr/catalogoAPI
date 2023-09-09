
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Catalogo.Aplicacao.DTO.Response
{
    public class CategoriaResponseDto
    {
        public int CategoriaId { get; set; }

        public string? Nome { get; set; }

        public string? ImagemURL { get; set; }
    }
}
