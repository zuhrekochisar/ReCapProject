using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        //public List<Brand> GetAll()
        //{
        //    return _brandDal.GetAll();
        //}



        //public Brand GetById(int id)
        //{
        //    return _brandDal.Get(b => b.BrandId == id);
        //}

        //public void Add(Brand brand)
        //{
           
        //        _brandDal.Add(brand);
           
        //        Console.WriteLine("Ekleme Başarılı.");
        // }

            
          

        //public void Update(Brand brand)
        //{
            
        //       _brandDal.Update(brand);
        //       Console.WriteLine("Güncelleme Gerçekleştirildi.");
        // }

        //public void Delete(Brand brand)
        //{
        //    _brandDal.Delete(brand);
        //    Console.WriteLine("Silme İşlemi Tamamlandı.");
        //}

        IDataResult<List<Brand>> IBrandService.GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
        }

        public IDataResult<List<Brand>> GetAllByBrandId(int id)
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(b => b.BrandId == id));
        }

        

        

        IResult IBrandService.Add(Brand brand)
        {
            ValidationTool.Validate(new BrandValidator(), brand);
            _brandDal.Add(brand);
            return new SuccessResult();
        }

        IResult IBrandService.Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult();
        }

        IResult IBrandService.Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult();
        }

      
    }
    }
    
