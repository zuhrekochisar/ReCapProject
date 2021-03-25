using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
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

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            //ValidationTool.Validate(new CarValidator(), car);

            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 17)        
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }

        public IDataResult<List<Car>> GetAllByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id));
        }

        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max));
        }

        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == carId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            //if (DateTime.Now.Hour == 23)
            //{
            //    return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
            //}
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IResult Update(Car car)
        {
            if (car.CarName.Length < 2)
            {

                return new ErrorResult(Messages.CarNameInvalid);
            }
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }



        //public IResult Add(Car car)
        //{

        //    if (car.CarName.Length < 2)
        //    {

        //        return new ErrorResult(Messages.CarNameInvalid);
        //    }
        //    _carDal.Add(car);
        //    return new SuccessResult(Messages.CarAdded); 
        //}



        //public List<Car> GetAllByBrandId(int id)
        //{
        //    return _carDal.GetAll(c => c.BrandId == id);
        //}

        //public List<Car> GetByDailyPrice(decimal min, decimal max)
        //{
        //    return _carDal.GetAll(c=>c.DailyPrice>=min && c.DailyPrice<=max);
        //}

        //List<Car> ICarService.GetAll()
        //{
        //    return _carDal.GetAll();
        //}
        //public void Add(Car car)
        //{
        //    if (car.CarName.Length>=2 && car.DailyPrice>0 )
        //    {
        //        _carDal.Add(car);
        //    }
        //    else
        //    {
        //        Console.WriteLine("Lütfen En Az 2 Karakter Giriniz ve Fiyat 0'dan Büyük Olmalıdır");
        //    }
        //}

        //public void Update(Car car)
        //{
        //    if (car.CarName.Length >= 2 && car.DailyPrice > 0)
        //    {
        //        _carDal.Add(car);
        //    }
        //    else
        //    {
        //        Console.WriteLine("Lütfen En Az 2 Karakter Giriniz ve Fiyat 0'dan Büyük Olmalıdır");
        //    }
        //}

        //public List<CarDetailDto> GetCarDetails()
        //{
        //    return _carDal.GetCarDetails();
        //}
    }
}
