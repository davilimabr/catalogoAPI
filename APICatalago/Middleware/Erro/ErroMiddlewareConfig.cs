namespace Catalogo.API.Middleware.Erro
{
    public static class ErroMiddlewareConfig
    {
        public static IApplicationBuilder UseErroMiddleware(this IApplicationBuilder app) =>
            app.UseMiddleware<ErroMiddleware>();
       
    }
}
