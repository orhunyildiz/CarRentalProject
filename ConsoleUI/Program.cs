using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //GetCarDetails();
            //ColorTest();
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.GetAll();
            if (result.Success)
            {
                foreach (var customer in result.Data)
                {
                    Console.WriteLine("Customer's Company Name: " + customer.CompanyName);
                }
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Color color = new Color { ColorName = "d" };
            var result = colorManager.Delete(color);
            Console.WriteLine(result.Message);
        }

        private static void GetCarDetails()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("Araba: " + car.Description + " / Marka: " + car.BrandName + " / Renk: " + car.ColorName + " / Günlük Ücret: " + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.Description);
            }
            Console.WriteLine("**********************");
            Console.WriteLine(carManager.GetById(4).Data.Description);
            Console.WriteLine("**********************");
            //carManager.Add(new Entities.Concrete.Car {DailyPrice = 5, ModelYear = 2015, Description = "deneme", BrandId = 3, ColorId = 2 });
            Console.WriteLine("**********************");
            //carManager.Delete(new Entities.Concrete.Car { Id = 1004});
            //carManager.Update(new Entities.Concrete.Car { Id = 1006, BrandId = 1, ColorId = 3, DailyPrice = 7, Description = "güncel", ModelYear = 145 });
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.Description);
            }
        }
    }
}
