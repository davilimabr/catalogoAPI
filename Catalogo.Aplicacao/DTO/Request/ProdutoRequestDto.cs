namespace Catalogo.Aplicacao.DTO.Request
{
    public class ProdutoRequestDto
    {
        public string? Nome { get; set; }

        public string? Descricao { get; set; }

        public double? Preco { get; set; }

        public string? ImagemURL { get; set; }

        public int Categoriaid { get; set; }
    }
}
