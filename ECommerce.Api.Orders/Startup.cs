// ECommerce.Api.Orders/Startup.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

public class Startup {
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<OrdersDbContext>(options =>
            options.UseMySql(Configuration.GetConnectionString("DefaultConnection"),
            new MySqlServerVersion(new Version(8, 0, 21))));

        services.AddScoped<IOrdersService, OrdersService>();
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
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ECommerce.Api.Orders v1"));
    }
}