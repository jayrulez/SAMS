using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebApi.Entities;

namespace WebApi.Infrastructure.DataStores
{
    public class LocationStore : EntityStore
    {
        public IQueryable<Location> Locations
        {
            get
            {
                return _dbContext.Locations;
            }
        }
        public async Task CreateAsync(Location entity)
        {
            _dbContext.Locations.Add(entity);

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Location entity)
        {
            _dbContext.Entry<Location>(entity).State = EntityState.Deleted;

            await _dbContext.SaveChangesAsync();
        }

        public async Task<Location> FindByIdAsync(int id)
        {
            var entity = await _dbContext.Locations.FindAsync(id);

            return entity;
        }

        public async Task<Location> FindByNameAsync(string name)
        {
            var entity = await _dbContext.Locations.FirstOrDefaultAsync(u => u.Name == name);

            return entity;
        }

        public async Task UpdateAsync(Location entity)
        {
            _dbContext.Entry<Location>(entity).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();
        }
    }
}