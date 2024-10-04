using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace WebTemplate.Info
{
    public static class BuildInfoHelper
    {
        public static IEndpointRouteBuilder MapBuildInfoRoute(this IEndpointRouteBuilder app)
        {
            app.MapGet("/api/info/build-info", (HttpContext context) => context.RequestServices.GetRequiredService<BuildInfo>());

            return app;
        }
    }
}
