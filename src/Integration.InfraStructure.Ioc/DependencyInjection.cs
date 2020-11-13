using FluentValidation;
using Integration.Domain.Core.Interfaces.Repositories;
using Integration.Domain.Core.Interfaces.Services;
using Integration.Domain.Entities;
using Integration.Domain.Services.Services;
using Integration.InfraStruture.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Integration.InfraStructure.Ioc
{
    public static class DependencyInjection
    {
        public static void DependencyInjectionServices(ref IServiceCollection services)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();
        }

        public static void DependencyInjectionRepositories(ref IServiceCollection services)
        {
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        }

        public static void DependencyInjectionValidations(ref IServiceCollection services)
        {
            services.AddTransient<IValidator<Employee>, EmployeeValidation>();
        }
    }
}
