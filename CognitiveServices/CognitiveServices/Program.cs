using System;
using CognitiveServices.Application.Common.Interfaces.Data;
using CognitiveServices.Persistance;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CognitiveServices
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var client = new ImageRecognitionClient(new ImageRecognitionOptions { Key = "3c8629cee37b406cbcee1fdfd93dbe4d", Url = "https://westeurope.api.cognitive.microsoft.com/vision/v2.0/analyze" });

            //var response = client.SendAsync(new ImageRecognitionRequest
            //{
            //    Image = File.ReadAllBytes(@"Z:\people-to-people.jpg"),
            //    VisualFeatures = new List<VisualFeatures> { VisualFeatures.Categories, VisualFeatures.Faces, VisualFeatures.Tags }
            //}).Result;

            var host = CreateWebHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                try
                {
                    var context = (CognitiveServicesDbContext)scope.ServiceProvider.GetService<ICognitiveServicesDbContext>();
                    context.Database.EnsureCreated();
                    CognitiveServicesInitializer.Initialize(context);
                }
                catch (Exception e)
                {
                    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError(e, "An error occurred while initializing the database.");
                }
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                        .UseStartup<Startup>();
        }
    }
}
