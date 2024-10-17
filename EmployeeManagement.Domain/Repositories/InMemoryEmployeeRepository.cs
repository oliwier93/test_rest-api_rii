using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Domain.Repositories
{
    public class InMemoryEmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> _employees = new List<Employee>();

        public void Add(Employee employee)
        {
            _employees.Add(employee);
        }

        public Employee GetById(Guid id)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                throw new InvalidOperationException("Employee not found.");
            }
            return employee;
        }

        public void Update(Employee employee)
        {
            var existingEmployee = GetById(employee.Id);
            if (existingEmployee != null)
            {
                existingEmployee.Update(employee.LastName, employee.Gender);
            }
        }

        public List<Employee> GetAll()
        {
            return _employees;
        }

        public void Delete(Guid id)
        {
            var employee = GetById(id);
            if (employee != null)
            {
                _employees.Remove(employee);
            }
        }
    }
}
