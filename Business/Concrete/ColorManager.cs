using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        //public List<Color> GetAll()
        //{
        //    return _colorDal.GetAll();
        //}

        //public Color GetByColorName(string colorName)
        //{
        //    return _colorDal.Get(c => c.ColorName == colorName);
        //}

        //public Color GetById(int colorId)
        //{
        //    return _colorDal.Get(c => c.ColorId == colorId);
        //}

        //public void Add(Color color)
        //{
        //    _colorDal.Add(color);
        //    Console.WriteLine("Renk Ekleme İşlemi Başarılı");
        //}

        //public void Update(Color color)
        //{
        //    _colorDal.Update(color);
        //    Console.WriteLine("Renk Güncelleme İşlemi Başarılı");
        //}
        //public void Delete(Color color)
        //{
        //    _colorDal.Delete(color);
        //    Console.WriteLine("Renk Silme İşlemi Başarılı");
        //}



        IDataResult<List<Color>> IColorService.GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
        }


        [ValidationAspect(typeof(ColorValidator))]
        IResult IColorService.Add(Color color)
        {
            //ValidationTool.Validate(new ColorValidator(), color);
            _colorDal.Add(color);
            return new SuccessResult();
        }

        IResult IColorService.Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult();
        }

        IResult IColorService.Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult();
        }
    }
}
