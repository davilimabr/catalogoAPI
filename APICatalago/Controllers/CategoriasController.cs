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
        private readonly IObterCategorias _obterCategorias;
        private readonly IObterCategoriaPorId _obterCategoriaPorId;
        private readonly IAdicionarCategoria _adicionarCategoria;
        private readonly IAtualizarCategoria _atualizarCategoria;
        private readonly IDeletarCategoria _deletarCategoria;

        public CategoriasController(
            IObterCategorias obterCategorias, IObterCategoriaPorId obterCategoriaPorId,
            IAdicionarCategoria adicionarCategoria, IAtualizarCategoria atualizarCategoria,
            IDeletarCategoria deletarCategoria)
        {
            _obterCategorias = obterCategorias;
            _obterCategoriaPorId = obterCategoriaPorId;
            _adicionarCategoria = adicionarCategoria;
            _atualizarCategoria = atualizarCategoria;
            _deletarCategoria = deletarCategoria;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaResponseDto>>> ObterCategorias()
        {
            var categorias = await _obterCategorias.Executar();

            if (categorias is null)
                return NotFound();

            return Ok(categorias);
        }

        [HttpGet]
        [Route("{id:int:min(1)}", Name = "ObterCategoria")]
        public async Task<ActionResult<CategoriaResponseDto>> ObterCategoriaPorId(int id)
        {
            var categoria = await _obterCategoriaPorId.Executar(id);

            if (categoria is null)
                return NotFound();

            return Ok(categoria);
        }

        [HttpPost]
        public async Task<ActionResult> CriarNovacategoria([FromBody] CategoriaRequestDto categoria)
        {
            if (categoria is null)
                return BadRequest();

            await _adicionarCategoria.Executar(categoria);

            return Ok(categoria);
        }

        [HttpPut]
        [Route("{id:int:min(1)}")]
        public async Task<ActionResult> AtualizarCategoria(int id, [FromBody] CategoriaModel categoria)
        {
            if (categoria is null || id != categoria.CategoriaId)
                return BadRequest();

            await _atualizarCategoria.Executar(categoria);

            return Ok(categoria);
        }

        [HttpDelete]
        [Route("{id:int:min(1)}")]
        public async Task<ActionResult> DeletarCategoria(int id)
        {
            await _deletarCategoria.Executar(id);

            return NoContent();
        }
    }
}
