using CheckPoint.Interfaces;
using Microsoft.AspNetCore.Mvc;
using CheckPoint.Models;
using CheckPoint.ViewModels;

namespace CheckPoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : Controller
    {
        readonly IEmployeeRepository _employeeRepository;
        readonly ICarRepository _carRepository;
        public EmployeesController(IEmployeeRepository employeeRepository, ICarRepository carRepository)
        {
            _employeeRepository = employeeRepository;
            _carRepository = carRepository;
        }

        [HttpGet]
        public ActionResult<List<Employee>> Get()
        {
            var employees = _employeeRepository.GetEmployees();
            if (employees == null || employees.Count <= 0)
            {
                return NotFound();
            }
            return Ok(employees);
        }

        [HttpGet("cars")]
        public ActionResult<List<EmployeeCarsViewModel>> GetEmployeeCars()
        {
            List<EmployeeCarsViewModel> employeeCarsViews = new List<EmployeeCarsViewModel>();
            var employees = _employeeRepository.GetEmployees();
            if (employees == null || employees.Count <= 0)
            {
                return NotFound();
            }
            foreach (var employee in employees)
            {
                EmployeeCarsViewModel ecvm = new()
                {
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Id = employee.Id
                };
                List<Car> existCars = new List<Car>();

                var cars = _carRepository.GetCarsByEmployeeId(employee.Id);
                existCars.AddRange(cars);
                ecvm.cars = existCars;
                employeeCarsViews.Add(ecvm);
            }

            return Ok(employeeCarsViews);
        }
    }
}
