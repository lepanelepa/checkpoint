using CheckPoint.Models;

namespace CheckPoint.Interfaces
{
    public interface ICarRepository
    {
        public Car AddCar(Car car);
        public int UpdateCar(Car car);  
        public int DeleteCar(int id);
        public Car GetCarById(int id);
        public List<Car> GetCars();
        public List<Car> GetCarsByEmployeeId(int employeeId);
        public Car GetCarByNumber(string number);
    }
}
