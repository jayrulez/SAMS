using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Infrastructure.Database;

namespace WebApi.Infrastructure.DataStores
{
    public class EntityStore : IDisposable
    {
        protected ApplicationDbContext _dbContext;

        public EntityStore()
        {
            _dbContext = new ApplicationDbContext();
        }

        public void Dispose()
        {
            if(_dbContext != null)
            {
                _dbContext.Dispose();
            }
        }
    }
}