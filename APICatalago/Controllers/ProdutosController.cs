using Catalogo.Aplicacao.DTO.Request;
using Catalogo.Aplicacao.DTO.Response;
using Catalogo.Aplicacao.Interface.Produto;
using Catalogo.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace APICatalago.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IObterProdutos _obterProdutos;
        private readonly IObterProdutoPorId _obterProdutoPorId;
        private readonly IAdicionarProduto _adicionarProduto;
        private readonly IAtualizarProduto _atualizarProduto;
        private readonly IDeletarProduto _deletarProduto;

        public ProdutosController(
            IObterProdutos obterProdutos, IObterProdutoPorId obterProdutoPorId, IAdicionarProduto adicionarProduto,
            IAtualizarProduto atualizarProduto, IDeletarProduto deletarProduto)
        {
            _obterProdutos = obterProdutos;
            _obterProdutoPorId = obterProdutoPorId;
            _adicionarProduto = adicionarProduto;
            _atualizarProduto = atualizarProduto;
            _deletarProduto = deletarProduto;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoResponseDto>>> ObterProdutos()
        {
            var produtos =  await _obterProdutos.Executar();

            if (produtos is null)
                return NotFound();

            return Ok(produtos);
        }

        [HttpGet]
        [Route("{id:int:min(1)}", Name = "ObterProduto")]
        public async Task<ActionResult<ProdutoResponseDto>> ObterProdutoPorId(int id)
        {
            var produto = await _obterProdutoPorId.Executar(id);

            if (produto is null)
                return NotFound();

            return Ok(produto);
        }

        [HttpPost]
        public async Task<ActionResult> CriarNovoProduto([FromBody] ProdutoRequestDto produto)
        {
            if (produto is null)
                return BadRequest();
            
            await _adicionarProduto.Executar(produto);

            return Ok();
        }

        [HttpPut]
        [Route("{id:int:min(1)}")]
        public async Task<ActionResult> AtualizarProduto(int id, [FromBody] ProdutoModel produto)
        {
            if (produto is null || id != produto.ProdutoId)
                return BadRequest();

            await _atualizarProduto.Executar(produto);

            return Ok(produto);
        }

        [HttpDelete]
        [Route("{id:int:min(1)}")]
        public async Task<ActionResult> DeletarProduto(int id)
        {
            await _deletarProduto.Executar(id);

            return NoContent();
        }
    }
}
