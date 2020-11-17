using Integration.Domain.Core.Interfaces.Repositories;
using Integration.Domain.Core.Interfaces.Services;
using Integration.Domain.Entities;
using System;

namespace Integration.Domain.Services.Services
{
    public class EmployeeService : ServiceBase<Employee>, IEmployeeService
    {
        public readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository) : base(employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public Employee UpdateSalary(Guid idEmployee)
        {
            var employee = _employeeRepository.GetById(idEmployee);

            // Employee _employee = new Employee("", 10.00, "edwin.desenv@gmail.com");

            if (employee != null)
            {
                employee.UpdateSalary(7);
                _employeeRepository.Update(employee);
            }

            return employee;
        }
    }
}