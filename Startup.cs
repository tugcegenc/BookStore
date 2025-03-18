using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace WebApi;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        
        // Swagger servisini ekle ve API bilgilerini tanımla
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "BookStore API",
                Version = "v1",
                Description = "Kitap Mağazası için API Dokümantasyonu"
            });
        });

        // In-memory database kullanımı
        services.AddDbContext<BookStoreDbContext>(options => options.UseInMemoryDatabase("BookStoreDB"));
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
    }
    
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            
            // Swagger'ı etkinleştir
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "BookStore API v1");
                c.RoutePrefix = string.Empty; // Swagger'ı otomatik olarak ana sayfada aç
            });
        }
        
        app.UseRouting();
        
        app.UseAuthorization();

        // API controller endpointlerini etkinleştir
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}