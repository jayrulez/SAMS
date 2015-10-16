using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Entities;

namespace WebApi.Infrastructure.DataStores
{
    public class AssetStore : EntityStore
    {
        public IQueryable<Asset> Assets
        {
            get
            {
                return _dbContext.Assets;
            }
        }
    }
}