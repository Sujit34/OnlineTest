using Microsoft.Extensions.DependencyInjection;
using OnlineTest.Contract.Contracts;
using OnlineTest.Contract.DataContracts;
using OnlineTest.Data.DbContext;
using OnlineTest.Data.Repository;

namespace OnlineTest.Data
{
    public static class DependencyRegister
    {
        public static IServiceCollection AddRepositoryDependency(
            this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ISqlConnectionFactory, SqlConnectionFactory>();
            return services;
        }
    }
}
