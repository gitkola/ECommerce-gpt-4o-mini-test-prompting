// ECommerce.Api.Search/Startup.cs
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddHttpClient<ISearchService, SearchService>();
        services.AddScoped<ISearchService, SearchService>();
        services.AddControllers();
        services.AddAutoMapper(typeof(Startup));
        services.AddSwaggerGen();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();
        app.UseAuthorization();

        // Додати обслуговування статичних файлів
        app.UseStaticFiles();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapGet("/", async context =>
            {
                context.Response.ContentType = "text/html";
                await context.Response.SendFileAsync(Path.Combine(env.ContentRootPath, "wwwroot", "index.html"));
            });
        });

        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ECommerce.Api.Search v1"));
    }
}