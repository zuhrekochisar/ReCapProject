using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarImageValidator : AbstractValidator<CarImage>
    {

        public CarImageValidator()
        {
            RuleFor(image => image.ImageId).NotEmpty();
            RuleFor(c => c.CarId).GreaterThan(0);
        }
    }
}
