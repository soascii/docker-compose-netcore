using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DockerCompose.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DockerCompose
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

            var connection = @"Server=ms-sql-server,1433;Database=master;User=sa;Password=PasSword2021!;";

            // var server = Configuration["DBServer"] ?? "ms-sql-server";
            // var port = Configuration["DBPort"] ?? "1433";
            // var user = Configuration["DBUser"] ?? "sa";
            // var password = Configuration["DBPassword"] ?? "PasSword2021!";
            // var databaseName = Configuration["DBName"] ?? "ComposeDB";

            services.AddDbContext<ComposeContext>(options => options.UseSqlServer(connection));

            services.AddControllers();
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

            Seed.PrepPopulation(app);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
