using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Catalogo.Domain.Models;

[Table("Categorias")]
public class CategoriaModel
{
    [Key]
    public int CategoriaId { get; set; }

    [Required]
    [StringLength(80)]
    public String? Nome{ get; set; }

    [Required]
    [StringLength(300)]
    public String? ImagemURL{ get; set; }

    [JsonIgnore]
    public ICollection<ProdutoModel>? Produtos { get; set; }

    public CategoriaModel() => Produtos = new Collection<ProdutoModel>();
}
