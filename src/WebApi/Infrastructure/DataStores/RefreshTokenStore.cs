using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebApi.Entities;

namespace WebApi.Infrastructure.DataStores
{
    public class RefreshTokenStore : EntityStore
    {
        public IQueryable<RefreshToken> RefreshTokens
        {
            get
            {
                return _dbContext.RefreshTokens;
            }
        }

        public Task Create(RefreshToken refreshToken)
        {
            var existingToken = _dbContext.RefreshTokens.Where(r => r.Subject == refreshToken.Subject && r.ApiClientId == refreshToken.ApiClientId).SingleOrDefault();

            _dbContext.RefreshTokens.Add(refreshToken);

            if (existingToken != null)
            {
                var result = Delete(existingToken);
            }

            _dbContext.SaveChanges();

            return Task.FromResult(0);
        }

        public Task<bool> Delete(RefreshToken refreshToken)
        {
            _dbContext.Entry<RefreshToken>(refreshToken).State = EntityState.Deleted;

            var result = _dbContext.SaveChanges() > 0;

            return Task.FromResult<bool>(result);
        }

        public Task<bool> Delete(string id)
        {
            var result = false;
            var refreshToken = RefreshTokens.FirstOrDefault(r => r.Id == id);

            if (refreshToken != null)
            {
                _dbContext.Entry<RefreshToken>(refreshToken).State = EntityState.Deleted;

                result = _dbContext.SaveChanges() > 0;
            }

            return Task.FromResult<bool>(result);
        }

        public Task<RefreshToken> FindById(string id)
        {
            var refreshToken = RefreshTokens.FirstOrDefault(r => r.Id == id);

            return Task.FromResult<RefreshToken>(refreshToken);
        }
    }
}