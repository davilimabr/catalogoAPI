using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Catalogo.Domain.Models;


[Table("Produtos")]
public class ProdutoModel
{

    [Key]
    public int ProdutoId{ get; set; }

    [Required]
    [StringLength(80)]
    public String? Nome { get; set; }

    [Required]
    [StringLength(300)]
    public String? Descricao{ get; set; }

    [Required]
    [Column(TypeName ="decimal(10,2)")]
    public double? Preco{ get; set; }

    [Required]
    [StringLength(300)]
    public String? ImagemURL { get; set; }
    public double? Estoque{ get; set; }
    public DateTime DataCadastro { get; set; }
    public int? CategoriaId { get; set; }

    [JsonIgnore]
    public CategoriaModel? Categoria { get; set; }
}
