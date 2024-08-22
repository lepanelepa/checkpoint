using CheckPoint.Interfaces;
using CheckPoint.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;


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
            throw new NotImplementedException();
            //using (var context = new CheckPointDBContext())
            //{
            //    Car? existCar = context.Cars.Single(a => a.Id == car.Id);
            //    if (existCar != null)
            //    {
            //        existCar.Brand = car.Brand;
            //        existCar.Model = car.Model;
            //        existCar.Number = car.Number;                    
            //        return context.SaveChanges();
            //    }
            //}
        }
    }
}
