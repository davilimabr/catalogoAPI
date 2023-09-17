using AutoMapper;
using Catalogo.Aplicacao.Context;
using Catalogo.Aplicacao.DTO.Request;
using Catalogo.Aplicacao.DTO.Response;
using Catalogo.Aplicacao.Interface.Categoria;
using Catalogo.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalago.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaResponseDto>>> ObterCategorias([FromServices] IObterCategorias obterCategorias)
        {
            var categorias = await obterCategorias.Executar();

            if (categorias is null)
                return NotFound();

            return Ok(categorias);
        }

        [HttpGet]
        [Route("{id:int:min(1)}", Name = "ObterCategoria")]
        public async Task<ActionResult<CategoriaResponseDto>> ObterCategoriaPorId(int id, [FromServices] IObterCategoriaPorId obterCategoriaPorId)
        {
            var categoria = await obterCategoriaPorId.Executar(id);

            if (categoria is null)
                return NotFound();

            return Ok(categoria);
        }

        [HttpPost]
        public async Task<ActionResult> CriarNovacategoria([FromBody] CategoriaRequestDto categoria, [FromServices] IAdicionarCategoria adicionarCategoria)
        {
            if (categoria is null)
                return BadRequest();

            await adicionarCategoria.Executar(categoria);

            return Ok(categoria);
        }

        [HttpPut]
        [Route("{id:int:min(1)}")]
        public async Task<ActionResult> AtualizarCategoria(int id, [FromBody] CategoriaModel categoria, [FromServices] IAtualizarCategoria atualizarCategoria)
        {
            if (categoria is null || id != categoria.CategoriaId)
                return BadRequest();

            await atualizarCategoria.Executar(categoria);

            return Ok(categoria);
        }

        [HttpDelete]
        [Route("{id:int:min(1)}")]
        public async Task<ActionResult> DeletarCategoria(int id, [FromServices] IDeletarCategoria deletarCategoria)
        {
            await deletarCategoria.Executar(id);

            return NoContent();
        }
    }
}
