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

            var vehicleCategory = new CategoryEntity
            {
                Name = "vehicles",
                SingularName = "vehicle"
            };

            var carCategory = new CategoryEntity
            {
                Name = "cars",
                SingularName = "car",
                Parent = vehicleCategory
            };

            var truckCategory = new CategoryEntity
            {
                Name = "truck",
                SingularName = "truck",
                Parent = vehicleCategory
            };
            
            var animalsCategory = new CategoryEntity
            {
                Name = "animals",
                SingularName = "animal"
            };

            var dogCategory = new CategoryEntity
            {
                Name = "dogs",
                SingularName = "dog",
                Parent = animalsCategory
            };

            var catCategory = new CategoryEntity
            {
                Name = "cats",
                SingularName = "cat",
                Parent = animalsCategory
            };
            
            var rabbitCategory = new CategoryEntity
            {
                Name = "rabbits",
                SingularName = "rabbit",
                Parent = animalsCategory
            };

            var plantCategory = new CategoryEntity
            {
                Name = "plants",
                SingularName = "plant"
            };

            var treeCategory = new CategoryEntity
            {
                Name = "trees",
                SingularName = "tree",
                Parent = plantCategory
            };

            var flowerCategory = new CategoryEntity
            {
                Name = "flowers",
                SingularName = "flower",
                Parent = plantCategory
            };
            
            context.Categories.Add(vehicleCategory);
            context.Categories.Add(carCategory);
            context.Categories.Add(truckCategory);
            context.Categories.Add(animalsCategory);
            context.Categories.Add(dogCategory);
            context.Categories.Add(catCategory);
            context.Categories.Add(rabbitCategory);
            context.Categories.Add(plantCategory);
            context.Categories.Add(treeCategory);
            context.Categories.Add(flowerCategory);

            context.SaveChanges();
        }
    }
}
