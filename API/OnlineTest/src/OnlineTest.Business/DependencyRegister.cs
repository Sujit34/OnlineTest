using Microsoft.Extensions.DependencyInjection;
using OnlineTest.Contract.BusinessContracts;


namespace OnlineTest.Business
{
    public static class DependencyRegister
    {
        public static IServiceCollection AddBusinessDependency(
            this IServiceCollection services)
        {
            services.AddScoped<IReconciliationHandler, ReconciliationHandler>();
            return services;
        }
    }
}
