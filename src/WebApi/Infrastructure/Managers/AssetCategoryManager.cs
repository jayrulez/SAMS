using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Infrastructure.DataStores;

namespace WebApi.Infrastructure.Managers
{
    public class AssetCategoryManager : EntityManager
    {
        internal AssetCategoryStore _store;

        public AssetCategoryManager()
        {
            _store = new AssetCategoryStore();
        }
    }
}