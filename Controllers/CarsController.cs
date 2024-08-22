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
        public CarsController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        [HttpGet]
        public ActionResult<List<Car>> Get()
        {
            var cars = _carRepository.GetCars();
            if (cars == null)
            {
                return NotFound();
            }
            return Ok(cars);
        }

        [HttpGet("{id}")]
        private ActionResult<Car> GetCarById(int id)
        {
            var car =  _carRepository.GetCarById(id);
            if (car == null)
            {
                return NotFound();
            }
            return Ok(car);
        }

        [HttpPost]
        private ActionResult<Car> GetCarByNumber([FromBody] CheckNumberVM check)
        {
            var car =  _carRepository.GetCarByNumber(check.Number);
            if (car == null)
            {
                return NotFound();
            }
            return Ok(car);
        }

        [HttpPost]
        public ActionResult<Car> SaveCar([FromBody] Car car)
        {
            var result = _carRepository.AddCar(car);
            return Ok(result);
        }

        [HttpPut]
        public ActionResult<Car> UpdateCar([FromBody] Car car)
        {
            var result = _carRepository.UpdateCar(car);
            return Ok(result);
        }
    }
}
