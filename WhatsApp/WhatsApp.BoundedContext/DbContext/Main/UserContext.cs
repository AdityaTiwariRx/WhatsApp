using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WhatsApp.BoundedContext.SqlContext;
using WhatsApp.Models.Main;
using WhatsApp.Models;
using WhatsApp.BoundedContext.Singleton;
using RxWeb.Core.Data;
using RxWeb.Core.Data.Models;
using RxWeb.Core.Data.BoundedContext;

namespace WhatsApp.BoundedContext.Main
{
    public class UserContext : BaseBoundedContext, IUserContext
    {
        public UserContext(MainSqlDbContext sqlDbContext,  IOptions<DatabaseConfig> databaseConfig, IHttpContextAccessor contextAccessor,ITenantDbConnectionInfo tenantDbConnection): base(sqlDbContext, databaseConfig.Value, contextAccessor,tenantDbConnection){ }

            #region DbSets
            		public DbSet<User> User { get; set; }
		public DbSet<UserDetail> UserDetail { get; set; }
		public DbSet<Country> Country { get; set; }
		public DbSet<Otp> Otp { get; set; }
            #endregion DbSets


    }


    public interface IUserContext : IDbContext
    {
    }
}

