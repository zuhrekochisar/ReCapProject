﻿using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()

        {
            _cars = new List<Car>
            {
                new Car {CarId=1, BrandId =1, ColorId=3, DailyPrice=250, ModelYear="2010", Descriptions="Hyundai"},
                new Car {CarId=2, BrandId =1, ColorId=3, DailyPrice=350, ModelYear="2015", Descriptions=" Kia"},
                new Car {CarId=3, BrandId =2, ColorId=1, DailyPrice=400, ModelYear="2010", Descriptions="Renault"},
                new Car {CarId=4, BrandId =3, ColorId=4, DailyPrice=450, ModelYear="2016", Descriptions="Toyota"},
                new Car {CarId=5, BrandId =4, ColorId=3, DailyPrice=550, ModelYear="2010", Descriptions=" BMW"},

            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);

        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.Descriptions = car.Descriptions;

        }
        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int brandId)
        {
            return _cars.Where(p => p.BrandId == brandId).ToList();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }
    }
}