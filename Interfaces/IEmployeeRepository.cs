using CheckPoint.Models;

namespace CheckPoint.Interfaces
{
    public interface IEmployeeRepository
    {
        public List<Employee> GetEmployees();
        public Employee GetById(int id);
    }
}
