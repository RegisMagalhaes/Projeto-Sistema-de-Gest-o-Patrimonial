using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace senai_sistemadegestao_webapi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services
                //Adiciona o serviço dos Controllers
                .AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    //Ignora os loopings nas consultas
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    //Ignora valores nulos ao fazer junções nas consultas
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                });

                services
                .AddAuthentication(Options =>
                {
                     Options.DefaultAuthenticateScheme = "JwtBearer";
                     Options.DefaultChallengeScheme = "JwtBearer";
                })

                 .AddJwtBearer("JwtBearer", options =>
                 {
                     options.TokenValidationParameters = new TokenValidationParameters
                     {
                         ValidateIssuer = true,
                         ValidateAudience = true,
                         ValidateLifetime = true,
                         IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("sistemadegestao-chave-autenticacao")),
                         ClockSkew = TimeSpan.FromMinutes(15),
                         ValidIssuer = "sistemadegestao.webAPI",
                         ValidAudience = "sistemadegestao.webAPI"
                     };

                 });
                    services.AddCors(options =>
                    {
                        options.AddPolicy("CorsPolicy",
                            builder =>
                            {
                                builder.WithOrigins("http://localhost:3000/%22")
                                                                            .AllowAnyHeader()
                                                                            .AllowAnyMethod();
                            }
                        );
                    });
                    

            //Adiciona o serviço do swagger
            //https://docs.microsoft.com/pt-br/aspnet/core/tutorials/web-api-help-pages-using-swagger?view=aspnetcore-5.0
            services.AddSwaggerGen(c => {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Patrimonios.WebAPI", Version = "v1" });
                    // Set the comments path for the Swagger JSON and UI.
                    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                    c.IncludeXmlComments(xmlPath);
                });


             


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            //Habilita o Cors
            app.UseCors("CorsPolicy");

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sistema de Gestão de Patrimônios");
                c.RoutePrefix = string.Empty;
            });

            app.UseAuthentication();


            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                //Define o mapeamento dos controllers
                endpoints.MapControllers();
            });
        }
    }
}
