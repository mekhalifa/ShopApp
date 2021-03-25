using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
          var host=  CreateHostBuilder(args).Build();
          using (var scope = host.Services.CreateScope())
          {
              var services = scope.ServiceProvider;
              var loggerFactory = services.GetService<ILoggerFactory>();
              try{

                  var context= services.GetService<ShopAppDbContext>();

                  context.Database.Migrate();


              }
              catch(Exception ex){
                  var logger = loggerFactory.CreateLogger<Program>();
                  logger.LogInformation(ex ,"Error Occurred when Migrated");

              }
          }


          host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
