
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Catalogo.Aplicacao.DTO.Response
{
    public class ProdutoResponseDto
    {
        public int? ProdutoId { get; set; }

        public string? Nome { get; set; }

        public string? Descricao { get; set; }

        public double? Preco { get; set; }

        public string? ImagemURL { get; set; }
    }
}
