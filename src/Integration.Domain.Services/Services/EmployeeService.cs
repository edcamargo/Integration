using Integration.Domain.Core.Interfaces.Repositories;
using Integration.Domain.Core.Interfaces.Services;
using Integration.Domain.Entities;

namespace Integration.Domain.Services.Services
{
    public class EmployeeService : ServiceBase<Employee>, IEmployeeService
    {
        public readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository) : base(employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
    }
}
