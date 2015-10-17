using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Infrastructure.DataStores;

namespace WebApi.Infrastructure.Managers
{
    public class AssetCategoryManager : EntityManager
    {
        internal AssetCategoryStore _store;

        public IQueryable<AssetCategory> AssetCategories
        {
            get
            {
                return _store.AssetCategories;
            }
        }

        public AssetCategoryManager()
        {
            _store = new AssetCategoryStore();
        }

        public async Task<IResponse<bool>> CreateAsync(AssetCategory entity)
        {
            var response = new Response<bool>();

            try
            {
                await _store.CreateAsync(entity);

                response.Result = true;
            }catch(Exception ex)
            {
                response.Error = new Error(ex.Message);
            }

            return response;
        }

        public async Task<IResponse<bool>> UpdateAsync(AssetCategory entity)
        {
            var response = new Response<bool>();

            try
            {
                await _store.UpdateAsync(entity);

                response.Result = true;
            }
            catch (Exception ex)
            {
                response.Error = new Error(ex.Message);
            }

            return response;
        }
    }
}