namespace WebApi.Migrations
{
    using Microsoft.AspNet.Identity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Infrastructure.DataStores;
    using Entities;
    using Infrastructure.Managers;
    using System.Collections.Generic;
    using Helpers;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApi.Infrastructure.Database.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebApi.Infrastructure.Database.ApplicationDbContext context)
        {
            context.ApiClients.AddRange(BuildClientsList());

            context.SaveChanges();

            var userManager = new UserManager(new UserStore());

            var result = userManager.CreateAsync(new User
            {
                UserName = "admin",
            }, "password");
        }

        private static List<ApiClient> BuildClientsList()
        {

            List<ApiClient> ClientsList = new List<ApiClient>
            {
                new ApiClient
                {
                    Id = "WebClient",
                    Secret= CryptoHelper.GetHash("Development"),
                    Name="SAMS Web Client",
                    ApiClientType = ApiClientType.Web,
                    Active = true,
                    RefreshTokenLifeTime = 7200,
                    AllowedOrigin = "http://localhost:8083"
                }
            };

            return ClientsList;
        }
    }
}
