using EbanxAssignment.Interface;
using EbanxAssignment.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace EbanxAssignment.Application
{
    public static class IoCModuleApplication
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IAccountRepository, AccountRepository>();

            return services;
        }
    }
}
