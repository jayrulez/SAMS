using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Entities;
using WebApi.Infrastructure.Database;
using WebApi.Infrastructure.DataStores;

namespace WebApi.Infrastructure.Managers
{
    public class UserManager : UserManager<User, int>
    {
        public UserManager(IUserStore<User, int> store) : base(store)
        {
        }

        public override IQueryable<User> Users
        {
            get
            {
                var queryableStore = Store as IQueryableUserStore<User, int>;

                if (queryableStore == null)
                {
                    throw new NotSupportedException("Store is not IQueryableUserStore");
                }

                return queryableStore.Users;
            }
        }

        public static UserManager Create(IdentityFactoryOptions<UserManager> options, IOwinContext context)
        {

            var dbContext = context.Get<ApplicationDbContext>();

            var userManager = new UserManager(new UserStore());

            var dataProtectionProvider = options.DataProtectionProvider;

            if (dataProtectionProvider != null)
            {
                userManager.UserTokenProvider = new DataProtectorTokenProvider<User, int>(dataProtectionProvider.Create("User Identity"))
                {
                    //Code for email confirmation and reset password life time
                    TokenLifespan = TimeSpan.FromHours(6)
                };
            }

            //Configure validation logic for usernames
            userManager.UserValidator = new UserValidator<User, int>(userManager)
            {
                AllowOnlyAlphanumericUserNames = true
            };

            //Configure validation logic for passwords
            userManager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };

            return userManager;
        }
    }
}