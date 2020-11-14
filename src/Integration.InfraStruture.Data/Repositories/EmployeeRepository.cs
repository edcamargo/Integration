using Integration.Domain.Core.Interfaces.Repositories;
using Integration.Domain.Entities;
using Integration.InfraStruture.Data.Context;

namespace Integration.InfraStruture.Data.Repositories
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(DataContext dataContext) : base(dataContext)
        { }
    }
}