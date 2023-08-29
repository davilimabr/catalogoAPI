using APICatalago.Context;
using APICatalago.Domain;
using APICatalago.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalago.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly AppDBContext _dbContext;
        private readonly IMapper _mapper;


        public CategoriasController(AppDBContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CategoriaDto>> ObterCategorias()
        {
            var categorias = _dbContext.Categorias.ToList();

            if (categorias is null)
                return NotFound();

            return Ok(_mapper.Map<IEnumerable<CategoriaDto>>(categorias));
        }

        [HttpGet]
        [Route("{id:int}", Name = "ObterCategoria")]
        public ActionResult<CategoriaDto> ObterCategoriaPorId(int id)
        {
            var categoria = _dbContext.Categorias.FirstOrDefault(c => c.CategoriaId == id);

            if (categoria is null)
                return NotFound();

            return Ok(_mapper.Map<CategoriaDto>(categoria));
        }

        [HttpPost]
        public ActionResult CriarNovacategoria([FromBody] Categoria categoria)
        {
            if (categoria is null)
                return BadRequest();

            _dbContext.Categorias.Add(categoria);
            _dbContext.SaveChanges();

            return new CreatedAtRouteResult("ObterProduto",
              new { id = categoria.CategoriaId }, categoria);
        }

        [HttpPut]
        [Route("{id:int}")]
        public ActionResult AtualizarCategoria(int id, [FromBody] Categoria categoria)
        {
            if (categoria is null || id != categoria.CategoriaId)
                return BadRequest();

            _dbContext.Entry(categoria).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return Ok(categoria);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public ActionResult DeletarCategoria(int id)
        {
            var categoria = _dbContext.Categorias.FirstOrDefault(c => c.CategoriaId == id);

            if (categoria is null) return NotFound();

            _dbContext.Remove(categoria);
            _dbContext.SaveChanges();

            return NoContent();

        }
    }
}
