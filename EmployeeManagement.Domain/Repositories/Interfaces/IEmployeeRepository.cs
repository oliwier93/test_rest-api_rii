

using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Domain.Repositories
{
    public interface IEmployeeRepository
    {
        void Add(Employee employee);
        Employee GetById(Guid id);
        void Update(Employee employee);
        List<Employee> GetAll();
        void Delete(Guid id);
    }
}