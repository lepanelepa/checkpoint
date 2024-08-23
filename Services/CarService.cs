using CheckPoint.Interfaces;
using CheckPoint.Models;



namespace CheckPoint.Services
{
    public class CarService : ICarRepository
    {
        public Car AddCar(Car car)
        {
            using (var context = new CheckPointDBContext())
            {
                context.Cars.Add(car);
                context.SaveChanges();
                return car;
            }
        }

        public Car GetCarByNumber(string number)
        {
            using (var context = new CheckPointDBContext())
            {
                var car = context.Cars.First(e => e.Number == number);               
                return car;
            }
        }

        public int DeleteCar(int id)
        {
            using (var context = new CheckPointDBContext())
            {
                context.Remove(context.Cars.Single(a => a.Id == id));
                return  context.SaveChanges();          
            }
        }

        public Car GetCarById(int id)
        {
            using (var context = new CheckPointDBContext())
            {
                var car = context.Cars.Find(id);
                return car;
            }
        }

        public List<Car> GetCars()
        {
            using (var context = new CheckPointDBContext())
            {
                var list = context.Cars.ToList();
                return list;
            }
        }

        public int UpdateCar(Car car)
        {
            using (var context = new CheckPointDBContext())
            {
                context.Cars.Update(car);
                return context.SaveChanges();                
            }
        }

        public List<Car> GetCarsByEmployeeId(int employeeId)
        {
            using (var context = new CheckPointDBContext())
            {
                var list = context.Cars.Where(c =>c.EmployeeId==employeeId).ToList();
                return list;
            }
        }
    }
}
