using APICatalago.Context;
using APICatalago.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace APICatalago.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDBContext _context;

        public ProdutosController(AppDBContext context) => _context = context;
        
        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            var produtos = _context.produtos.ToList();

            if (produtos is null) {
                return NotFound();
            }
            
            return produtos;
        }
        
    }
}
