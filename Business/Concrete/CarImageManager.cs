using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using Core.Utilities.Rules;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {

        //BEGINNING

        //ICarImageDal _carImageDal;
        //public CarImageManager(ICarImageDal carImageDal)
        //{
        //    _carImageDal = carImageDal;
        //}


        ////[ValidationAspect(typeof(CarImageValidator))]
        ////public IResult Add(CarImage carImage)
        ////{
        ////    _carImageDal.Add(carImage);
        ////    return new SuccessResult(Messages.ImageAdded);
        ////}


        //[ValidationAspect(typeof(CarImageValidator))]
        //public IResult Add(IFormFile file, CarImage carImage)
        //{
        //    IResult result = BusinessRules.Run(CheckImageLimitExceeded(carImage.CarId));
        //    if (result != null)
        //    {
        //        return result;
        //    }
        //    carImage.ImagePath = FileHelper.Add(file);
        //    carImage.Date = DateTime.Now;
        //    _carImageDal.Add(carImage);
        //    return new SuccessResult(Messages.ImageAdded);
        //}

        //[ValidationAspect(typeof(CarImageValidator))]
        //public IResult Delete(CarImage carImage)
        //{
        //    _carImageDal.Delete(carImage);


        //    return new SuccessResult(Messages.ImageDeleted);
        //}
        //[ValidationAspect(typeof(CarImageValidator))]
        //public IDataResult<List<CarImage>> GetAll()
        //{
        //    return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        //}

        ////public IResult Update(CarImage carImage)
        ////{
        ////    _carImageDal.Update(carImage);
        ////    return new SuccessResult(Messages.ImageUpdated);
        ////}


        //[ValidationAspect(typeof(CarImageValidator))]
        //public IResult Update(IFormFile file, CarImage carImage)
        //{

        //    carImage.ImagePath = FileHelper.Update(_carImageDal.Get(p => p.Id == carImage.Id).ImagePath, file);
        //    carImage.Date = DateTime.Now;
        //    _carImageDal.Update(carImage);
        //    return new SuccessResult();
        //}



        //    [ValidationAspect(typeof(CarImageValidator))]
        //public IDataResult<CarImage> Get(int id)
        //{
        //    return new SuccessDataResult<CarImage>(_carImageDal.Get(image => image.Id == id));
        //}


        //[ValidationAspect(typeof(CarImageValidator))]
        //public IDataResult<List<CarImage>> GetImagesByCarId(int id)
        //{
        //    return new SuccessDataResult<List<CarImage>>(CheckIfCarImageNull(id));
        //}


        //private IResult CheckImageLimitExceeded(int carId)
        //{
        //    var carImagecount = _carImageDal.GetAll(c => c.CarId == carId).Count;
        //    if (carImagecount >= 5)
        //    {
        //        return new ErrorResult(Messages.CarImageLimitExceeded);
        //    }


        //    return new SuccessResult();
        //}




        //private List<CarImage> CheckIfCarImageNull(int id)
        //{
        //    //    string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName + @"\Images");
        //    //    var result = _carImageDal.GetAll(c => c.CarId == id).Any();
        //    //    if (!result)
        //    //    {
        //    //        return new List<CarImage> { new CarImage { CarId = id, ImagePath = path, Date = DateTime.Now } };
        //    //    }
        //    //    return _carImageDal.GetAll(c => c.CarId == id);
        //    //



        //    string path = @"\Images";
        //    var result = _carImageDal.GetAll(c => c.CarId == id).Any();
        //    if (!result)
        //    {
        //        return new List<CarImage> { new CarImage { CarId = id, ImagePath = path, Date = DateTime.Now } };
        //    }
        //    return _carImageDal.GetAll(p => p.CarId == id);
        //}

        // END



        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageLimitExceeded(carImage.CarId));

            if (result != null)
            {
                return result;
            }

            carImage.ImagePath = FileHelper.Add(file);
            carImage.ImageDate = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Delete(CarImage carImage)
        {
            FileHelper.Delete(carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(IFormFile file, CarImage carImage)
        {
            carImage.ImagePath = FileHelper.Update(_carImageDal.Get(c => c.ImageId == carImage.ImageId).ImagePath, file);
            carImage.ImageDate = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.ImageId == id));
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {

            List<CarImage> carImageList = _carImageDal.GetAll(c => c.CarId == carId);
            return new SuccessDataResult<List<CarImage>>(carImageList);
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        private IResult CheckIfCarImageLimitExceeded(int carId)
        {
            var carImagecount = _carImageDal.GetAll(p => p.CarId == carId).Count;
            if (carImagecount >= 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceeded);
            }

            return new SuccessResult();
        }

        private List<CarImage> CheckIfAnyCarImageExists(int carId)
        {
            string path = Environment.CurrentDirectory + @"\images\DefaultCar.jpg";
            var result = _carImageDal.GetAll(c => c.CarId == carId).Any();

            if (result)
            {
                return _carImageDal.GetAll(p => p.CarId == carId);
            }

            return new List<CarImage> { new CarImage { CarId = carId, ImagePath = path, ImageDate = DateTime.Now } };
        }


    }
    }

