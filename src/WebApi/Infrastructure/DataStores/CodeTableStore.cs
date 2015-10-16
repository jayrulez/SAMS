using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Entities;

namespace WebApi.Infrastructure.DataStores
{
    public class CodeTableStore: EntityStore
    {
        public IQueryable<CodeTable> CodeTables
        {
            get
            {
                return _dbContext.CodeTables;
            }
        }
    }
}