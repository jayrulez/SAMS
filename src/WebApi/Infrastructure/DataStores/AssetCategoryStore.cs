using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}