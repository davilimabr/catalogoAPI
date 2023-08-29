using APICatalago.Context;
using APICatalago.Domain;
using APICatalago.DTO;
using AutoMapper;
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
        private readonly AppDBContext _dbContext;
        private readonly IMapper _mapper;


        public ProdutosController(AppDBContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProdutoDto>> ObterProdutos()
        {
            var produtos = _dbContext.produtos.ToList();

            if (produtos is null)
                return NotFound();

            return Ok(_mapper.Map<IEnumerable<ProdutoDto>>(produtos));
        }

        [HttpGet]
        [Route("{id:int}", Name = "ObterProduto")]
        public ActionResult<ProdutoDto> ObterProdutoPorId(int id)
        {
            var produto = _dbContext.produtos.FirstOrDefault(p => p.ProdutoId == id);

            if (produto is null)
                return NotFound();

            return Ok(_mapper.Map<ProdutoDto>(produto));
        }

        [HttpPost]
        public ActionResult CriarNovoProduto([FromBody] Produto produto)
        {
            if (produto is null)
                return BadRequest();

            _dbContext.produtos.Add(produto);
            _dbContext.SaveChanges();

            return new CreatedAtRouteResult("ObterProduto",
              new { id = produto.ProdutoId }, produto);
        }

        [HttpPut]
        [Route("{id:int}")]
        public ActionResult AtualizarProduto(int id, [FromBody] Produto produto)
        {
            if (produto is null || id != produto.ProdutoId)
                return BadRequest();

            _dbContext.Entry(produto).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return Ok(produto);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public ActionResult DeletarProduto(int id)
        {
            var produto = _dbContext.produtos.FirstOrDefault(p => p.ProdutoId == id);

            if (produto is null) return NotFound();

            _dbContext.Remove(produto);
            _dbContext.SaveChanges();

            return NoContent();

        }
    }
}
