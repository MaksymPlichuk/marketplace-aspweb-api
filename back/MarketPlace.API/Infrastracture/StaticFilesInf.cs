using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.FileProviders;
using System.Runtime.CompilerServices;

namespace MarketPlace.API.Infrastracture
{
    public static class StaticFilesInf
    {
        public static IApplicationBuilder UseStaticFile(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            var items = new List<KeyValuePair<string, string>> {
                new KeyValuePair<string, string>(StaticFilesSettings.ItemPath,StaticFilesSettings.WebItemPath),
                new KeyValuePair<string, string>(StaticFilesSettings.CategoryPath,StaticFilesSettings.WebCategoryPath),

                //new KeyValuePair<string, string>()
            };

            string storagePath = Path.Combine(env.ContentRootPath, StaticFilesSettings.StoragePath);

            if (!Directory.Exists(storagePath)) { Directory.CreateDirectory(storagePath); }

            foreach (var item in items)
            {
                string path = Path.Combine(storagePath, item.Key);
                if (!Directory.Exists(path)) { Directory.CreateDirectory(path); }

                app.UseStaticFiles(new StaticFileOptions
                {
                    FileProvider = new PhysicalFileProvider(path),
                    RequestPath = item.Value,
                });
            }

            string videosStoragePath = Path.Combine(env.ContentRootPath, StaticFilesSettings.VideosStoragePath);
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(videosStoragePath),
                RequestPath = StaticFilesSettings.WebVideosPath,
            });


            return app;
        }
    }
}
