using APICatalago.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APICatalago.DTO
{
    public class ProdutoDto
    {
        public int? ProdutoId { get; set; }

        public String? Nome { get; set; }

        public String? Descricao { get; set; }

        public double? Preco { get; set; }

        public String? ImagemURL { get; set; }
    }
}
