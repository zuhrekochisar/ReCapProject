﻿using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

       

        public List<Car> GetAllByBrandId(int id)
        {
            return _carDal.GetAll(c => c.BrandId == id);
        }

        public List<Car> GetByDailyPrice(decimal min, decimal max)
        {
            return _carDal.GetAll(c=>c.DailyPrice>=min && c.DailyPrice<=max);
        }

        List<Car> ICarService.GetAll()
        {
            return _carDal.GetAll();
        }
        public void Add(Car car)
        {
            if (car.CarName.Length>=2 && car.DailyPrice>0 )
            {
                _carDal.Add(car);
            }
            else
            {
                Console.WriteLine("Lütfen En Az 2 Karakter Giriniz ve Fiyat 0'dan Büyük Olmalıdır");
            }
        }

        public void Update(Car car)
        {
            if (car.CarName.Length >= 2 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
            }
            else
            {
                Console.WriteLine("Lütfen En Az 2 Karakter Giriniz ve Fiyat 0'dan Büyük Olmalıdır");
            }
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }
    }
}
