using Core.EntityFramework;
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
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalDbContext>, ICarDal
    {
        //        public void Add(Car entity)
        //        {
        //            using (CarRentalDbContext context = new CarRentalDbContext())
        //            {
        //                var addedEntity = context.Entry(entity);
        //                addedEntity.State = EntityState.Added;
        //                context.SaveChanges();
        //            }
        //        }

        //        public void Delete(Car entity)
        //        {
        //            using (CarRentalDbContext context = new CarRentalDbContext())
        //            {
        //                var deletedEntity = context.Entry(entity);
        //                deletedEntity.State = EntityState.Deleted;
        //                context.SaveChanges();
        //            }
        //        }

        //        public Car Get(Expression<Func<Car, bool>> filter)
        //        {
        //            using (CarRentalDbContext context = new CarRentalDbContext())
        //            {
        //                return context.Set<Car>().SingleOrDefault(filter);
        //            }
        //        }

        //        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        //        {
        //            using (CarRentalDbContext context = new CarRentalDbContext())
        //            {
        //                return filter == null ? context.Set<Car>().ToList() : context.Set<Car>().Where(filter).ToList();
        //            }
        //        }

        //        public void Update(Car entity)
        //        {
        //            using (CarRentalDbContext context = new CarRentalDbContext())
        //            {
        //                var updatedEntity = context.Entry(entity);
        //                updatedEntity.State = EntityState.Modified;
        //                context.SaveChanges();
        //            }
        //        }              


        //>>> Bu kodlar EfEntityRepositoryBase'ye kopyalandı ve revize edildi. <<<
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarRentalDbContext context = new CarRentalDbContext())   //CarName, BrandName, ColorName, DailyPrice. 
            {
                var result = from c in context.Cars
                             join color in context.Colors
                             on c.ColorId equals color.ColorId
                             join brand in context.Brands
                             on c.BrandId equals brand.BrandId

                             select new CarDetailDto { CarName = c.CarName,BrandName = brand.BrandName, ColorName = color.ColorName, DailyPrice =c.DailyPrice };
                return result.ToList();







            }
        }
    }
}
