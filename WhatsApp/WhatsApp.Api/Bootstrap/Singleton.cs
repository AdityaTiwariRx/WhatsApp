using Microsoft.Extensions.DependencyInjection;
using WhatsApp.Infrastructure.Singleton;
using WhatsApp.BoundedContext.Singleton;
using RxWeb.Core.Data;

namespace WhatsApp.Api.Bootstrap
{
    public static class Singleton
    {
        public static void AddSingletonService(this IServiceCollection serviceCollection)
        {
            #region Singleton
            serviceCollection.AddSingleton<ITenantDbConnectionInfo, TenantDbConnectionInfo>();
            serviceCollection.AddSingleton(typeof(UserAccessConfigInfo));
            #endregion Singleton
        }

    }
}




