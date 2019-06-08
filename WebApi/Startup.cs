using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using WebApi.IRepository;
using WebApi.Models;
using WebApi.Repository;

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddResponseCompression(x =>
            {
                x.Providers.Add<BrotliCompressionProvider>();
                x.Providers.Add<GzipCompressionProvider>();
                x.EnableForHttps = true;
            });
            services.Configure<BrotliCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Optimal;
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            //services.AddDbContext<DatabaseContext>(opt => opt.UseInMemoryDatabase("MyDB"));
            services.AddDbContext<DatabaseContext>(opt => opt.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\ASPNET_PROJECT\WebApi\WebApi\dbGMT.mdf;Integrated Security=True;Connect Timeout=30"));
            services.AddScoped(typeof(IGMTRepository<>), typeof(Repository<>));
            services.AddCors(ops => ops.AddPolicy(MyAllowSpecificOrigins, builder =>
            {
                builder.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyHeader().AllowAnyMethod().AllowCredentials();
                builder.WithOrigins("http://localhost:5000").AllowAnyMethod().AllowAnyHeader().AllowAnyMethod().AllowCredentials();
            }
            ));
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<DatabaseContext>().AddDefaultTokenProviders();
            var identityBuilder = services.AddIdentityCore<IdentityUser>(o =>
               {
                   o.Password.RequireDigit = true;
                   o.Password.RequiredLength = 8;
                   o.Password.RequireUppercase = false;
                   o.Password.RequireNonAlphanumeric = false;
               }
            );
            services.ConfigureApplicationCookie(o=> {
                o.Cookie.Name = ".GmtCookies";
                o.Cookie.Expiration = TimeSpan.FromDays(1);
                o.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict;

            });
            
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "GMT API", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, DatabaseContext db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                DBInitializer.Initialize(db);
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors(MyAllowSpecificOrigins);
            app.UseHttpsRedirection();
            app.UseResponseCompression();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseAuthentication();
            app.UseMvc();

        }
    }
}
