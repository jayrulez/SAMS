using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Entities;
using System.Threading.Tasks;
using WebApi.Infrastructure.Database;
using System.Data.Entity;

namespace WebApi.Infrastructure.DataStores
{
    public class UserStore : EntityStore, IUserStore<User, int>, IQueryableUserStore<User, int>, IUserPasswordStore<User, int>
    {
        public UserStore()
        {
        }

        public IQueryable<User> Users
        {
            get
            {
                return _dbContext.Users;
            }
        }

        public async Task CreateAsync(User user)
        {
            _dbContext.Users.Add(user);

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(User user)
        {
            _dbContext.Entry<User>(user).State = EntityState.Deleted;

            await _dbContext.SaveChangesAsync();
        }

        public async Task<User> FindByIdAsync(int userId)
        {
            var user = await _dbContext.Users.FindAsync(userId);

            return user;
        }

        public async Task<User> FindByNameAsync(string userName)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.UserName == userName);

            return user;
        }

        public Task<string> GetPasswordHashAsync(User user)
        {
            return Task.FromResult<string>(user.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(User user)
        {
            return Task.FromResult<bool>(!string.IsNullOrEmpty(user.PasswordHash));
        }

        public Task SetPasswordHashAsync(User user, string passwordHash)
        {
            user.PasswordHash = passwordHash;

            return Task.FromResult(0);
        }

        public async Task UpdateAsync(User user)
        {
            _dbContext.Entry<User>(user).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();
        }
    }
}