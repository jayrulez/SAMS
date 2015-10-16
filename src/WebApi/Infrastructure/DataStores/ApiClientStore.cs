using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Entities;

namespace WebApi.Infrastructure.DataStores
{
    public class ApiClientStore : EntityStore
    {
        public IQueryable<ApiClient> ApiClients
        {
            get
            {
                return _dbContext.ApiClients;
            }
        }

        public ApiClient FindById(string id)
        {
            return _dbContext.ApiClients.FirstOrDefault(a => a.Id == id);
        }
    }
}