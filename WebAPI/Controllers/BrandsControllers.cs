using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsControllers : ControllerBase
    {
        IBrandService _brandService;

        public BrandsControllers(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        public List<Brand> Get()
        {
            IBrandService brandService = new BrandManager(new EfBrandDal());
            var result = brandService.GetAll();
            return result.Data;
        }
    }
}
