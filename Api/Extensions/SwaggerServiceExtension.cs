using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Api.Extensions
{
    public static class SwaggerServiceExtension
    {
        public static IServiceCollection AddSwaggerDoc(this IServiceCollection services)
        {

            services.AddSwaggerGen(Options =>
            {
                Options.SwaggerDoc("v1", new OpenApiInfo { Title = "ShopApp Api", Version = "v1" });

            });



            return services;
        }

        public static IApplicationBuilder UseSwaggerDoc(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "ShopApp API v1");
            });
            return app;
        }
    }
}