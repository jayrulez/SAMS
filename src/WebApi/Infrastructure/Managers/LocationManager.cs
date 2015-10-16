using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Infrastructure.DataStores;

namespace WebApi.Infrastructure.Managers
{
    public class LocationManager : EntityManager
    {
        internal LocationStore _store;
    }
}