using Integration.Domain.Core.Interfaces.Repositories;
using Integration.InfraStruture.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Integration.InfraStructure.Ioc
{
    public static class DependencyInjection
    {
        public static void DependencyInjectionRepository(ref IServiceCollection services)
        {
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
        }
    }
}
