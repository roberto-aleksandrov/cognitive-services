using CognitiveServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CognitiveServices.Persistance.Configurations
{
    public class ImageCategoryConfiguration : IEntityTypeConfiguration<ImageCategoryEntity>
    {
        public void Configure(EntityTypeBuilder<ImageCategoryEntity> builder)
        {
            builder.HasKey(c => new { c.CategoryId, c.ImageId });

            builder.HasOne(ic => ic.Category)
                .WithMany(c => c.ImageCategories)
                .HasForeignKey(c => c.CategoryId);

            builder.HasOne(ic => ic.Image)
                .WithMany(i => i.ImageCategories)
                .HasForeignKey(i => i.ImageId);
        }
    }
}
