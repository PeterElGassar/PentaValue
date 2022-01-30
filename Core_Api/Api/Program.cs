using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
            CreateHostBuilder(args).Build().Run();

            //using (var scope = host.Services.CreateScope())
            //{
            //    var services = scope.ServiceProvider;
            //    var LoggerFactory = services.GetRequiredService<ILoggerFactory>();
            //    try
            //    {
            //        var context = services.GetRequiredService<Context>();
            //        await context.Database.MigrateAsync();
            //        //await StoreContextSeed2.SeedAsync(context, LoggerFactory);

            //        var userManager = services.GetRequiredService<UserManager<AppUser>>();
            //        var identityContext = services.GetRequiredService<IdentityDbContext>();

            //        await identityContext.Database.MigrateAsync();
            //    }
            //    catch (Exception ex)
            //    {
            //        var logger = LoggerFactory.CreateLogger<Program>();
            //        logger.LogError(ex, "An Error occured during migration");

            //    }
            //}

            //host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    //var p = System.Reflection.Assembly.GetEntryAssembly().Location;
                    //p = p.Substring(0, p.LastIndexOf(@"\") + 1);
                    //webBuilder.UseContentRoot(p);
                    webBuilder.UseStartup<Startup>();
                });
    }
}
