using APICatalago.Domain;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace APICatalago.DTO
{
    public class CategoriaDto
    {
        public int CategoriaId { get; set; }

        public String? Nome { get; set; }

        public String? ImagemURL { get; set; }
    }
}
