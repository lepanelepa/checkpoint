using CheckPoint.Interfaces;
using Microsoft.AspNetCore.Mvc;
using CheckPoint.Models;
using CheckPoint.ViewModels;

namespace CheckPoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : Controller
    {
        readonly ICarRepository _carRepository;
        readonly IEmployeeRepository _employeeRepository;
        public CarsController(ICarRepository carRepository, IEmployeeRepository employeeRepository)
        {
            _carRepository = carRepository;
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public ActionResult<List<Car>> Get()
        {
            var cars = _carRepository.GetCars();
            if (cars == null || cars.Count<=0)
            {
                return NotFound();
            }
            return Ok(cars);
        }

        [HttpGet("{id:int}")]
        public ActionResult<Car> GetCarById([FromRoute ] int id)
        {
            var car =  _carRepository.GetCarById(id);
            if (car == null)
            {
                return NotFound();
            }
            return Ok(car);
        }
     
        [HttpPost("checkpoint")]
        private ActionResult<Car> GetCarByNumber([FromBody] CheckNumberViewModel check)
        {
            var car =  _carRepository.GetCarByNumber(check.Number);
            if (car == null)
            {
                return NotFound();
            }
            return Ok(car);
        }

        /// <summary>
        /// Собрать список машин сотрудников
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<Car> SaveCar([FromBody] Car car)
        {
            // Проверяем есть ли такой сотрудник
            var employee = _employeeRepository.GetById(car.EmployeeId);
            if (employee==null)
            {
                return BadRequest(string.Format("Сотрудника с идентификатором {0} не существует", car.EmployeeId));
            }
            var result = _carRepository.AddCar(car);
            return Ok(result);
        }

        [HttpPut]
        public ActionResult<Car> UpdateCar([FromBody] Car car)
        {
            // Проверяем есть ли такой автомобиль
            var existCar = _carRepository.GetCarById(car.Id);
            if (existCar == null)
            {
                return BadRequest(string.Format("Автомобиль с идентификатором {0} не существует", car.Id));
            }
            // Проверяем есть ли такой сотрудник
            var employee = _employeeRepository.GetById(car.EmployeeId);
            if (employee == null)
            {
                return BadRequest(string.Format("Сотрудника с идентификатором {0} не существует", car.EmployeeId));
            }            
            var result = _carRepository.UpdateCar(car);
            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<bool> DeleteCar(int id)
        {
            // Проверяем есть ли такой автомобиль
            var existCar = _carRepository.GetCarById(id);
            if (existCar == null)
            {
                return BadRequest(string.Format("Автомобиль с идентификатором {0} не существует", id));
            }
            var result = _carRepository.DeleteCar(id);
            return Ok(result);
        }
       
    }
}
