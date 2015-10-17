using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebApi.Entities;

namespace WebApi.Infrastructure.DataStores
{
    public class AssetCategoryStore : EntityStore
    {
        public IQueryable<AssetCategory> AssetCategories
        {
            get
            {
                return _dbContext.AssetCategories;
            }
        }

        public Task CreateAsync(AssetCategory entity)
        {
            _dbContext.AssetCategories.Add(entity);

            _dbContext.SaveChangesAsync();

            return Task.FromResult(0);
        }
    }
}