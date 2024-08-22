using CheckPoint.Models;

namespace CheckPoint.Interfaces
{
    public interface ICarRepository
    {
        public List<Car> GetCars();
        public Car GetCarById(int id);
        public Car GetCarByNumber(string number);
        public Car AddCar(Car car);
        public int UpdateCar(Car car);  
        public int DeleteCar(int id);
    }
}
