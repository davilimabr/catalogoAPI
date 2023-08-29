using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APICatalago.Domain;

[Table("Categorias")]
public class Categoria
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
    public ICollection<Produto>? Produtos { get; set; }

    public Categoria() => Produtos = new Collection<Produto>();
}
