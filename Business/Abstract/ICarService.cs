using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface ICarService
    {
        //List<Car> GetAll();
        //List<Car> GetAllByBrandId(int id);
        //List<Car> GetByDailyPrice(decimal min, decimal max);

        //List<CarDetailDto> GetCarDetails();

        IDataResult<List<Car>> GetAll();  //Business a sağ tıklayıp proje başvurusu ekledik. DataAccess ve Entities i seçtik. Ardından ampule tıkladık.
        IDataResult<List<Car>> GetAllByBrandId(int id);
        IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<Car> GetById(int carId);
        IResult Add(Car car);


    }
}
