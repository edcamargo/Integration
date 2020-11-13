using Integration.Domain.Entities;
using System;

namespace Integration.Domain.Core.Interfaces.Services
{
    public interface IEmployeeService : IServiceBase<Employee>
    {
        /// <summary>
        /// Méthod for Update Salary
        /// </summary>
        /// <param name="idEmployee"></param>
        /// <returns></returns>
        Employee UpdateSalary(Guid idEmployee);
    }
}
