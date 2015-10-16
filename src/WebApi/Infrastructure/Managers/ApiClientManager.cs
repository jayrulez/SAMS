using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Infrastructure.DataStores;

namespace WebApi.Infrastructure.Managers
{
    public class ApiClientManager : EntityManager
    {
        internal ApiClientStore _store;

        public ApiClientManager()
        {
            _store = new ApiClientStore();
        }

        public IResponse<ApiClient> FindById(string id)
        {
            var response = new Response<ApiClient>();

            try
            {
                response.Result = _store.FindById(id);
            }catch(Exception ex)
            {
                response.Error = new Error(ex.Message);
            }

            return response;
        }
    }
}