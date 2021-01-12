
using asp_net_Poject_WSEI.Middleware;
using Microsoft.AspNetCore.Builder;

namespace asp_net_Project_WSEI.Extensions
{
    public static class Middleware_Builder
    {
        public static IApplicationBuilder UseElapsedTimeMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ElapsedTimeMiddleware>();
        }
    }
}