using System;
using System.Collections.Generic;
using System.Linq;
using CognitiveServices.Domain.Entities;

namespace CognitiveServices.Persistance
{
    public class CognitiveServicesInitializer 
    {
        private readonly Dictionary<int, CategoryEntity> _roles = new Dictionary<int, CategoryEntity>();

        public static void Initialize(CognitiveServicesDbContext context)
        {
            new CognitiveServicesInitializer().Seed(context);
        }

        public void Seed(CognitiveServicesDbContext context)
        {
            SeedCategories(context);
        }

        private void SeedCategories(CognitiveServicesDbContext context)
        {
            if (context.Categories.Any())
            {
                return;
            }

            var carsCategory = new CategoryEntity
            {
                Name = "cars",
                SingularName = "car"
            };


            var animalsCategory = new CategoryEntity
            {
                Name = "animals",
                SingularName = "animal"
            };

            context.Categories.Add(carsCategory);
            context.Categories.Add(animalsCategory);

            context.SaveChanges();
        }
    }
}
