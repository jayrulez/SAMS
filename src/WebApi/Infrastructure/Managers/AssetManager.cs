﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Infrastructure.DataStores;

namespace WebApi.Infrastructure.Managers
{
    public class AssetManager : EntityManager
    {
        internal AssetStore _store;

        public AssetManager()
        {
            _store = new AssetStore();
        }
    }
}