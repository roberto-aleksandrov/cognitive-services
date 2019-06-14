using System.Reflection;
using AutoMapper;
using CognitiveServices.Application.Common.AutoMapper;
using CognitiveServices.Application.Common.Dtos;
using CognitiveServices.Application.Common.Interfaces.Data;
using CognitiveServices.Application.Common.Interfaces.Services;
using CognitiveServices.Application.Common.Interfaces.Validation;
using CognitiveServices.Application.Services;
using CognitiveServices.Application.Services.Interfaces;
using CognitiveServices.Application.Validators;
using CognitiveServices.AutoMapper;
using CognitiveServices.Filters;
using CognitiveServices.ImageRecognition.Infrastructure;
using CognitiveServices.Infrastructure.ImageRecognition;
using CognitiveServices.Infrastructure.Validation;
using CognitiveServices.Persistance;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace CognitiveServices
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
            services.AddAutoMapper(new Assembly[] { typeof(BmToDtoProfile).GetTypeInfo().Assembly, typeof(DtoToEntityProfile).GetTypeInfo().Assembly });
            services.AddCors(options =>
             options.AddPolicy("default",
              builder =>
              {
                  builder.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
              }));
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(CustomExceptionFilterAttribute));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<ICognitiveServicesDbContext, CognitiveServicesDbContext>(c =>
               c.UseSqlServer(Configuration.GetConnectionString("CognitiveServicesConnection")));

            services.AddOptions();

            services.AddTransient<IImagesService, ImagesService>();
            services.AddTransient<ICategoriesService, CategoriesService>();
            services.AddTransient<IImageRecognitionClient, ImageRecognitionClient>();
            services.AddTransient<IValidator<UpsertImageDto>, ImageValidator>();
            services.AddTransient<IValidationService, ValidationService>();
            services.AddTransient<IValidatorFactory>(o => new ValidatorFactory(services.BuildServiceProvider()));

            services.AddSingleton(Configuration.GetSection("ImageRecognition").Get<ImageRecognitionOptions>());

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger");
                c.RoutePrefix = string.Empty;
            });
            app.UseCors("default");
            app.UseMvc();
        }
    }
}
