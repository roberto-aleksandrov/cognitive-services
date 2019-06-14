using CognitiveServices.Application.Common.Interfaces.Data;
using CognitiveServices.Domain.Entities;
using CognitiveServices.Persistance.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CognitiveServices.Persistance
{
    public class CognitiveServicesDbContext : DbContext, ICognitiveServicesDbContext
    {
        public CognitiveServicesDbContext(DbContextOptions<CognitiveServicesDbContext> options)
            : base(options) { }

        public DbSet<ImageEntity> Images { get; set; }

        public DbSet<CategoryEntity> Categories { get; set; }

        public DbSet<ImageCategoryEntity> ImageCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(ImageCategoryConfiguration).Assembly);
        }

    }
}
