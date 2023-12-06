using AutoMapper;
using Catalogo.Aplicacao.Context;
using Catalogo.Aplicacao.DTO.Request;
using Catalogo.Aplicacao.Interface.Produto;
using Catalogo.Domain.Models;
using Microsoft.ApplicationInsights;
using Microsoft.Extensions.Logging;

namespace Catalogo.Aplicacao.Services.Produto
{
    public class AdicionarProdutoService : IAdicionarProduto
    {
        private readonly AppDBContext _dbContext;
        private readonly IMapper _mapper;
        private readonly TelemetryClient _telemetryClient;
        private readonly ILogger _logger;

        public AdicionarProdutoService(AppDBContext dBcontext, IMapper mapper, ILogger<AdicionarProdutoService> logger, TelemetryClient telemetryClient)
        {
            _dbContext = dBcontext;
            _mapper = mapper;
            _logger = logger;
            _telemetryClient = telemetryClient;
        } 
        
        public async Task Executar(ProdutoRequestDto produto)
        {
            var produtoModel = _mapper.Map<ProdutoModel>(produto);

            _dbContext.Produtos.Add(produtoModel);
            await _dbContext.SaveChangesAsync();
            _telemetryClient.TrackEvent("produto adicionado");
        }
    }
}
