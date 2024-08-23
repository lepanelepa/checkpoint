using CheckPoint.Models;
namespace CheckPoint.ViewModels
{
    public class EmployeeCarsViewModel: Employee
    {
        public List<Car> cars { get; set; }
    }
}
