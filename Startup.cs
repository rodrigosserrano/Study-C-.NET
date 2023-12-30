using API.Data;
using API.Models;
using API.Repositories;
using API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
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
using Refit;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            // Configure DB
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<DBContext>(
                    options => options.UseSqlServer(
                        connectionString: Configuration.GetConnectionString("DataBase")
                    )
                );

            // Configure refit for each external model
            services.AddRefitClient<IRefit<ViaCepModel>>()
                .ConfigureHttpClient(
                    i => i.BaseAddress = new Uri("https://viacep.com.br")
                );
            
            // Configure DI
            services.AddScoped<IRepository<UsuarioModel>, UsuarioRepository>()
                .AddScoped<IRepository<TarefaModel>, TarefaRepository>()
                .AddScoped<IIntegration<ViaCepModel>, ViaCepRepository>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}