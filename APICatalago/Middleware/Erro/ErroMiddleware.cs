using Newtonsoft.Json;
using System.Net;
using Catalogo.Domain.Exceptions;

namespace Catalogo.API.Middleware.Erro
{
    public class ErroMiddleware
    {
        private readonly RequestDelegate _next;

        public ErroMiddleware(RequestDelegate next) =>
            _next = next;

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (RecursoNaoEncontradoException recursoNaoEncontrado)
            {
                await HandleExceptionAsync(context, recursoNaoEncontrado.Mensagens, HttpStatusCode.NotFound);
            }
            catch
            {
                await HandleExceptionAsync(context, new List<string>() { "Erro interno do servidor."}, HttpStatusCode.InternalServerError);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, IEnumerable<string> mensagens, HttpStatusCode httpStatusCode)
        {
            var erro = new ErroDto()
            {
                Mensagens = mensagens
            };

            var resultado = JsonConvert.SerializeObject(erro);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)httpStatusCode;
            await context.Response.WriteAsync(resultado);
        }
    }
}
