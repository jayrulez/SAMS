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
    public class RefreshTokenManager : EntityManager
    {
        internal RefreshTokenStore _store;

        public IQueryable<RefreshToken> RefreshTokens { get { return _store.RefreshTokens; } }

        public RefreshTokenManager()
        {
            _store = new RefreshTokenStore();
        }

        public async Task<IResponse<bool>> Create(RefreshToken refreshToken)
        {
            var response = new Response<bool>();

            try
            {
                await _store.Create(refreshToken);

                response.Result = true;
            }
            catch (Exception ex)
            {
                response.Error = new Error(ex.Message);
            }

            return response;
        }

        public async Task<IResponse<bool>> Delete(string id)
        {
            var response = new Response<bool>();

            try
            {
                response.Result = await _store.Delete(id);
            }
            catch (Exception ex)
            {
                response.Error = new Error(ex.Message);
            }

            return response;
        }

        public async Task<IResponse<bool>> Delete(RefreshToken refreshToken)
        {
            var response = new Response<bool>();

            try
            {
                response.Result = await _store.Delete(refreshToken);
            }
            catch (Exception ex)
            {
                response.Error = new Error(ex.Message);
            }

            return response;
        }

        public async Task<IResponse<RefreshToken>> FindByIdAsync(string id)
        {
            var response = new Response<RefreshToken>();

            try
            {
                response.Result = await _store.FindById(id);
            }
            catch (Exception ex)
            {
                response.Error = new Error(ex.Message);
            }

            return response;
        }

        public override void Dispose()
        {
            _store.Dispose();
        }
    }
}