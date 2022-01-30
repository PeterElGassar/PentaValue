using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Api.Models;
using Api.Persistence.Repositories.IRepository;
using Api.Persistence.Repositories;
using Api.Extentions;
using Microsoft.AspNetCore.Identity;
using Api.Core.Interfaces;
using Api.Core.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http.Features;
using System.IO;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Http;

namespace Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            //services.AddControllers();

            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200");
                });
            });


            services.AddDbContext<Context>(options =>
            options.UseSqlServer(
                Configuration.GetConnectionString("DefaultConnection")
                ));

            //Inject Dependencies
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ITokenService, TokenService>();

            services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<Context>().AddDefaultTokenProviders();

            //add some Extension Method 
            services.AddIdentityServices(Configuration);
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            //Setting Of Uplode Files
            services.Configure<FormOptions>(o =>
            {
                o.BufferBodyLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.ValueLengthLimit = int.MaxValue;
            });

            services.AddAuthentication().AddGoogle(option => {
                IConfigurationSection googleAuthSection = Configuration.GetSection("Authentication:Google");

                option.ClientId = googleAuthSection["ClientId"];
                option.ClientSecret = googleAuthSection["ClientSecret"];
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("CorsPolicy");
            //should be Before UseAuthorization
            app.UseAuthentication();
            //Setting Of Uplode Files 
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Resources")),
                RequestPath = new PathString("/Resources")
            });
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
