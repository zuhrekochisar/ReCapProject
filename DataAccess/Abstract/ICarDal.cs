using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal: IEntityRepository<Car>
    {
        //List<Car> GetAll();
        //List<Car> GetById(int BrandId);
        //void Add(Car car);                    IEntityRepository interface class ı ile her yere aynı kodu yazmaktan kurtulunur.                      
        //void Update(Car car); 
        //void Delete(Car car);

        List<CarDetailDto> GetCarDetails();


    }
}
