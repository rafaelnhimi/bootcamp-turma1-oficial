using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetCoreEntityFramework.Context;
using NetCoreEntityFramework.Repository;
using NetCoreEntityFramework.Services;
using Microsoft.OpenApi.Models;
using Autofac.Extensions.DependencyInjection;
using System;
using NetCoreEntityFramework.Utils;
using System.Reflection;

namespace NetCoreEntityFramework
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

            services.AddEntityFrameworkNpgsql()
                  .AddDbContext<UsuarioContext>(options =>
                  {
                      options.UseNpgsql("Server=Localhost;Port=5432;Database=instagram;User Id=postgres;Password=123456;",
                      b =>
                      {
                          b.MigrationsAssembly("NetCoreEntityFramework");
                      });
                  });


            var builder = new ContainerBuilder();

            builder.Populate(services);
            builder.RegisterType<UsuarioService>().As<IUsuarioService>();
            builder.RegisterType<UsuarioRepository>().As<IUsuarioRepository>();

            builder.RegisterAssemblyTypes(typeof(RepositoryUsuarioContext<>).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRepositoryUsuarioContext<>));        

            var container = builder.Build();

            return new AutofacServiceProvider(container);

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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Test API V1");
            });
        }
    }
}
