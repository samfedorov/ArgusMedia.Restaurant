using ArgusMedia.Restaurant.Models;
using Microsoft.EntityFrameworkCore;

namespace ArgusMedia.Restaurant.Repositories
{
    public abstract class BaseRepository<TModel, RLogger>
        where TModel : class
        where RLogger : class
    {
        private readonly RestaurantDbContex _context;
        protected readonly DbSet<TModel> Entities;
        protected ILogger<RLogger> Logger;

        protected BaseRepository(RestaurantDbContex context, ILogger<RLogger> logger)
        {
            Logger = logger;
            _context = context;
            Entities = context.Set<TModel>();
        }

        protected async Task<IEnumerable<TModel>> GetAllAsync()
        {
            var items = await Entities.ToListAsync();
            return items;
        }

        protected async Task<TModel> AddAsync(TModel entity, bool shouldSave)
        {
            Logger.LogInformation($"Adding Entity");
            var result = await Entities.AddAsync(entity);
            if (shouldSave)
            {
                Logger.LogInformation("Saving transaction");
                int num = await _context.SaveChangesAsync();
            }
            else
            {
                Logger.LogInformation("Should save was false. Continuing transaction without saving.");
            }

            return result.Entity;
        }

        protected async Task AddRangeAsync(IEnumerable<TModel> entities)
        {
            Logger.LogInformation($"Adding Entity");
            await Entities.AddRangeAsync(entities);
            Logger.LogInformation("Saving transaction");
            int num = await _context.SaveChangesAsync();
        }

        protected async Task DeleteAsync(TModel entity)
        {
            Logger.LogInformation($"Deleting Entity");
            _context.Remove(entity);
            Logger.LogInformation("Saving transaction");
            await _context.SaveChangesAsync();
        }
    }
}
