using Core.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarRentalDbContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (CarRentalDbContext context = new CarRentalDbContext())
            {
                var result = from r in context.Rentals
                             join c in context.Customers on r.CarId equals c.CustomerId
                             join u in context.Users on c. UserId equals u.UserId
                             
                             
                             select new RentalDetailDto { RentalId = r.RentalId, UserFirstName=u.UserFirstName  ,RentDate = r.RentDate, ReturnDate = r.ReturnDate };
                return result.ToList();
            }
        }
    }
}
