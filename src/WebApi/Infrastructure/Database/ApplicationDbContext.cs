using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApi.Entities;

namespace WebApi.Infrastructure.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("ApplicationDbContext")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = true;
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<ApiClient> ApiClients { get; set; }
        public DbSet<AssetAssignment> AssetAssignments { get; set; }
        public DbSet<AssetCategory> AssetCategories { get; set; }
        public DbSet<AssetField> AssetFields { get; set; }
        public DbSet<AssetFieldValue> AssetFieldValues { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<CodeTable> CodeTables { get; set; }
        public DbSet<CodeTableValue> CodeTableValues { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<User> Users { get; set; }
    }
}