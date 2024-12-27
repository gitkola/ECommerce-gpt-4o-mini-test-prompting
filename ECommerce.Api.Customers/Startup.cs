// ECommerce.Api.Customers/Startup.cs
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

public class Startup{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<CustomersDbContext>(options =>
            options.UseMySql(Configuration.GetConnectionString("DefaultConnection"),
            new MySqlServerVersion(new Version(8, 0, 21))));

        services.AddScoped<ICustomersService, CustomersService>();
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
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ECommerce.Api.Customers v1"));
    }
}