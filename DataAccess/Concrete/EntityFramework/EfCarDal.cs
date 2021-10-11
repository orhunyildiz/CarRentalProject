using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             select new CarDetailDto
                             {
                                 Description = c.Description,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 DailyPrice = c.DailyPrice
                             };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from c in filter is null ? context.Cars : context.Cars.Where(filter)
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             select new CarDetailDto
                             {
                                 Id = c.Id,
                                 CarId = c.Id,
                                 BrandName = b.BrandName,
                                 Description = c.Description,
                                 ModelYear = c.ModelYear,
                                 ColorName = co.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 ImagePath = (from a in context.CarImages where a.CarId == c.Id select a.ImagePath).FirstOrDefault()
                             };
                return result.ToList();
            }
        }
        public CarDetailDto GetCarDetailsById(Expression<Func<Car, bool>> filter)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from c in filter is null ? context.Cars : context.Cars.Where(filter)
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             select new CarDetailDto
                             {
                                 Id = c.Id,
                                 CarId = c.Id,
                                 BrandName = b.BrandName,
                                 Description = c.Description,
                                 ModelYear = c.ModelYear,
                                 ColorName = co.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 ImagePath = (from a in context.CarImages where a.CarId == c.Id select a.ImagePath).FirstOrDefault()
                             };

                return result.FirstOrDefault();
            }
        }
    }
}
