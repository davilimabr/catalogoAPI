using Catalogo.Aplicacao.DTO.Request;
using Catalogo.Aplicacao.DTO.Response;
using Catalogo.Aplicacao.Interface.Produto;
using Catalogo.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace APICatalago.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoResponseDto>>> ObterProdutos([FromServices] IObterProdutos obterProdutos)
        {
            var produtos =  await obterProdutos.Executar();

            if (produtos is null)
                return NotFound();

            return Ok(produtos);
        }

        [HttpGet]
        [Route("{id:int:min(1)}", Name = "ObterProduto")]
        public async Task<ActionResult<ProdutoResponseDto>> ObterProdutoPorId([FromRoute] int id, [FromServices] IObterProdutoPorId obterProdutoPorId)
        {
            var produto = await obterProdutoPorId.Executar(id);

            if (produto is null)
                return NotFound();

            return Ok(produto);
        }

        [HttpPost]
        public async Task<ActionResult> CriarNovoProduto([FromBody] ProdutoRequestDto produto, [FromServices] IAdicionarProduto adicionarProduto)
        {
            if (produto is null)
                return BadRequest();
            
            await adicionarProduto.Executar(produto);

            return Ok();
        }

        [HttpPut]
        [Route("{id:int:min(1)}")]
        public async Task<ActionResult> AtualizarProduto(int id, [FromBody] ProdutoModel produto, [FromServices] IAtualizarProduto atualizarProduto)
        {
            if (produto is null || id != produto.ProdutoId)
                return BadRequest();

            await atualizarProduto.Executar(produto);

            return Ok(produto);
        }

        [HttpDelete]
        [Route("{id:int:min(1)}")]
        public async Task<ActionResult> DeletarProduto(int id, [FromServices] IDeletarProduto deletarProduto)
        {
            await deletarProduto.Executar(id);

            return NoContent();
        }
    }
}
