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
