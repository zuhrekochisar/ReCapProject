using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IBrandService
    {
        List<Brand> GetAll();
        Brand GetById(int id);

        //IDataResult<List<Brand>> GetAll();   
        //IDataResult<List<Brand>> GetAllByBrandId(int id);
        //IDataResult<List<Brand>> GetByDailyPrice(decimal min, decimal max);

        //IDataResult<Brand> GetById(int BrandId);
        //IResult Add(Brand brand);
    }
}
