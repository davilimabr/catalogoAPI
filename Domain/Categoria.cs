using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

    public ICollection<Produto>? Produtos { get; set; }

    public Categoria() => Produtos = new Collection<Produto>();
}
