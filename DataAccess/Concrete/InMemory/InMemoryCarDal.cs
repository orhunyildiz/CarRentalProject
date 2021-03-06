using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id=1, BrandId=1, ColorId=1, DailyPrice=500, ModelYear=2016, Description="Hyundai - i10 (Beyaz)"},
                new Car{Id=2, BrandId=1, ColorId=2, DailyPrice=700, ModelYear=2017, Description="Hyundai - TUCSON (Siyah)"},
                new Car{Id=3, BrandId=2, ColorId=3, DailyPrice=650, ModelYear=2017, Description="Nissan - Qashqai (Kırmızı)"},
                new Car{Id=4, BrandId=2, ColorId=1, DailyPrice=500, ModelYear=2018, Description="Nissan - Juke (Beyaz)"},
                new Car{Id=5, BrandId=3, ColorId=1, DailyPrice=750, ModelYear=2020, Description="Honda - Civic Type R (Beyaz)"},
                new Car{Id=6, BrandId=4, ColorId=2, DailyPrice=600, ModelYear=2019, Description="Toyota - Corolla (Siyah)"},
                new Car{Id=7, BrandId=4, ColorId=3, DailyPrice=550, ModelYear=2018, Description="Toyota - Yaris (Kırmızı)"},
                new Car{Id=8, BrandId=5, ColorId=2, DailyPrice=550, ModelYear=2019, Description="Ford - Fiesta (Siyah)"},
                new Car{Id=9, BrandId=5, ColorId=1, DailyPrice=800, ModelYear=2020, Description="Ford - Focus (Beyaz)"},
                new Car{Id=10, BrandId=5, ColorId=3, DailyPrice=1250, ModelYear=2021, Description="Ford - Mustang (Kırmızı)"}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(c => c.Id == id).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public CarDetailDto GetCarDetailsById(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
