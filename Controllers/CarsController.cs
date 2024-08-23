using CheckPoint.Interfaces;
using Microsoft.AspNetCore.Mvc;
using CheckPoint.Models;
using CheckPoint.ViewModels;

namespace CheckPoint.Controllers
{
    /// <summary>
    /// Управление списками машин сотрудников
    /// </summary>
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
            if (cars == null || cars.Count <= 0)
            {
                return NotFound();
            }
            return Ok(cars);
        }

        [HttpGet("{id:int}")]
        public ActionResult<Car> GetCarById([FromRoute] int id)
        {
            var car = _carRepository.GetCarById(id);
            if (car == null)
            {
                return NotFound();
            }
            return Ok(car);
        }

        /// <summary>
        /// Проверка номера машины на посту охраны
        /// </summary>
        /// <param name="check"></param>
        /// <returns></returns>
        [HttpPost("checkpoint")]
        private ActionResult<Car> GetCarByNumber([FromBody] CheckNumberViewModel check)
        {
            var car = _carRepository.GetCarByNumber(check.Number);
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
            if (employee == null)
            {
                return BadRequest(new
                {
                    message = string.Format("Сотрудника с идентификатором {0} не существует", car.EmployeeId),
                    id = car.EmployeeId
                });
            }
            var result = _carRepository.AddCar(car);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(new
            {
                message = "Автомобиль успешно добавлен!",
                id = result?.Id
            });
        }

        [HttpPut]
        public ActionResult<Car> UpdateCar([FromBody] Car car)
        {
            // Проверяем есть ли такой автомобиль
            var existCar = _carRepository.GetCarById(car.Id);
            if (existCar == null)
            {
                return BadRequest(new
                {
                    message = string.Format("Автомобиль с идентификатором {0} не существует", car.Id),
                    id = car.Id
                });
            }
            // Проверяем есть ли такой сотрудник
            var employee = _employeeRepository.GetById(car.EmployeeId);
            if (employee == null)
            {
                return BadRequest(new
                {
                    message = string.Format("Сотрудника с идентификатором {0} не существует", car.EmployeeId),
                    id = car.EmployeeId
                });
            }
            var result = _carRepository.UpdateCar(car);
            return Ok(new
            {
                message = "Автомобиль успешно обновлен!",
                id = car.Id
            });
        }

        [HttpDelete("{id:int}")]
        public ActionResult<bool> DeleteCar(int id)
        {
            // Проверяем есть ли такой автомобиль
            var existCar = _carRepository.GetCarById(id);
            if (existCar == null)
            {
                return BadRequest(new
                {
                    message = string.Format("Автомобиль с идентификатором {0} не существует", id),
                    id = id
                });
            }
            if (!_carRepository.DeleteCar(id))
            {
                return NotFound();
            }
            return Ok(new
            {
                message = "Автомобиль успешно удален!",
                id = id
            });
        }
    }
}
