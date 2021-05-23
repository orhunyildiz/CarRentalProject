using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine("Araba: " + car.Description + " Marka: " + car.BrandName + " Renk: " + car.ColorName + " Günlük Ücret: " + car.DailyPrice);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
            Console.WriteLine("**********************");
            Console.WriteLine(carManager.GetById(4).Description);
            Console.WriteLine("**********************");
            //carManager.Add(new Entities.Concrete.Car {DailyPrice = 5, ModelYear = 2015, Description = "deneme", BrandId = 3, ColorId = 2 });
            Console.WriteLine("**********************");
            //carManager.Delete(new Entities.Concrete.Car { Id = 1004});
            carManager.Update(new Entities.Concrete.Car { Id = 1006, BrandId = 1, ColorId = 3, DailyPrice = 7, Description = "güncel", ModelYear = 145 });
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
        }
    }
}
