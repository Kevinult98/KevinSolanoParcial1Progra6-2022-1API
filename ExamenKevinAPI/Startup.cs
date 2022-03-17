using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamenKevinAPI.Models;
using Microsoft.EntityFrameworkCore;

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

        services.AddControllers();
        //agregar la cadena de conexión para el proyecto 
        //TODO: Debemos guardar esta cadena por medio de usersecrets.json y no por medio de appsttings.json

        var conn = @"SERVER=.;DATABASE=P6Assets20221;";

        services.AddDbContext<P6Assets20221Context>(options => options.UseSqlServer(conn));

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "AnswersAPI_KevinSolano", Version = "v1" });
        });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AnswersAPI_KevinSolano v1"));
        }

        app.UseRouting();

        app.UseAuthorization();

        //TODO: Revisar si hace falta alguna configuración para uso de JWT

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}

