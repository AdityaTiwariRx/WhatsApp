#region Namespace
using Microsoft.Extensions.DependencyInjection;
using WhatsApp.Infrastructure.Security;
using RxWeb.Core.Data;
using RxWeb.Core.Security;
using RxWeb.Core.Annotations;
using RxWeb.Core;
using WhatsApp.UnitOfWork.DbEntityAudit;
using WhatsApp.BoundedContext.Main;
using WhatsApp.UnitOfWork.Main;
using WhatsApp.Domain.UserModule;
            #endregion Namespace




namespace WhatsApp.Api.Bootstrap
{
    public static class ScopedExtension
    {

        public static void AddScopedService(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IRepositoryProvider, RepositoryProvider>();
            serviceCollection.AddScoped<ITokenAuthorizer, TokenAuthorizer>();
            serviceCollection.AddScoped<IModelValidation, ModelValidation>();
            serviceCollection.AddScoped<IAuditLog, AuditLog>();
            serviceCollection.AddScoped<IApplicationTokenProvider, ApplicationTokenProvider>();
            serviceCollection.AddScoped(typeof(IDbContextManager<>), typeof(DbContextManager<>));

            #region ContextService

            serviceCollection.AddScoped<ILoginContext, LoginContext>();
            serviceCollection.AddScoped<ILoginUow, LoginUow>();
                        serviceCollection.AddScoped<IUserContext, UserContext>();
            serviceCollection.AddScoped<IUserUow, UserUow>();
                       
            #endregion ContextService





            #region DomainService

            
            serviceCollection.AddScoped<IUserDomain, UserDomain>();
            
            serviceCollection.AddScoped<IOtpDomain, OtpDomain>();
            
            serviceCollection.AddScoped<ICheckOtpDomain, CheckOtpDomain>();
            
            serviceCollection.AddScoped<IUserDetailDomain, UserDetailDomain>();
            #endregion DomainService




        }
    }
}




