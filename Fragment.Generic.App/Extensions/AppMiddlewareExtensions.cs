using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.FileProviders;
using WebApiContrib.Core.Results;

namespace Fragment.Generic.App.Extensions
{
    public static class AppMiddlewareExtensions
    {
        public static IApplicationBuilder UseApiDocumentation(this IApplicationBuilder app)
        {
            app.UseStaticFiles(new StaticFileOptions
            {
                // Reach for Fragment.Generic documentation in "dist/_site" foler
                // expose "dist/_site"  as static root
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "dist", "_site"))
            });

            app.UseRouter(r =>
            {
                r.MapGet("/Api", async (HttpContext context) =>
                {
                    string fileName = "index.html";
                    string filePath = Path.Combine(
                        Directory.GetCurrentDirectory(), "dist", "_site", fileName);
                    // respond with static html file as document
                    await context.PhysicalFile(filePath, "text/html");
                });
            });

            return app;
        }


        public static IApplicationBuilder UseBrowserDocumentation(this IApplicationBuilder app)
        {
            app.UseStaticFiles(new StaticFileOptions
            {
                // expose "dist/_site"  as static root
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(),"dist","browser"))
            });

            app.UseRouter(r =>
            {
                r.MapGet("/Browser", async (HttpContext context) =>
                {
                    string fileName = "index.html";
                    string filePath = Path.Combine(
                        Directory.GetCurrentDirectory(), "dist", "browser", fileName);
                    // respond with static html file as document
                    await context.PhysicalFile(filePath, "text/html");
                });
            });

            return app;
        }
    }
}
