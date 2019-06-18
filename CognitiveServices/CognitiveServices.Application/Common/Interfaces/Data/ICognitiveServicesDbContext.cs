using System.Threading;
using System.Threading.Tasks;
using CognitiveServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CognitiveServices.Application.Common.Interfaces.Data
{
    public interface ICognitiveServicesDbContext
    {
        DbSet<ImageEntity> Images { get; }

        DbSet<CategoryEntity> Categories { get; }

        DbSet<ImageCategoryEntity> ImageCategories { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));

        DbSet<T> Set<T>() where T : class;
    }
}
