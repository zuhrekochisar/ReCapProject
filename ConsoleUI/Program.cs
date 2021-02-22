using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;


namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // CarTest();
            //BrandTest();

            //ColorTest();

            RentalTest();

        }

        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());




            var result = rentalManager.GetRentalDetails();

            if (result.Success == true)
            {
                foreach (var rental in result.Data)
                {

                    Console.WriteLine(rental.UserFirstName + "/" + rental.RentDate + "/" + rental.ReturnDate);

                }

            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        //private static void ColorTest()
        //{
        //    ColorManager colorManager = new ColorManager(new EfColorDal());
        //    foreach (var color in colorManager.GetAll())
        //    {
        //        Console.WriteLine(color.ColorName);
        //    }
        //}



        //private static void BrandTest()
        //{
        //    BrandManager brandManager = new BrandManager(new EfBrandDal());
        //    foreach (var brand in brandManager.GetAll())
        //    {
        //        Console.WriteLine(brand.BrandName);
        //    }
        //}



        private static void CarTest()
        {
            ICarService carManager = new CarManager(new EfCarDal());



            //foreach (var car in carManager.GetAll())
            //{
            //    //Console.WriteLine("Model" + "   " + "Yıl" + "  " + "Fiyat");
            //    Console.WriteLine(car.CarId + " " + car.BrandId + " " + car.ColorId + " " + car.Descriptions + " " + car.ModelYear + " " + car.DailyPrice);
            //    //Console.WriteLine(car.Descriptions + " " + car.ModelYear + " " + car.DailyPrice);
            //    Console.WriteLine("---------------------------------");

            //}

            //foreach (var car in carManager.GetCarDetails())
            //{
            //    Console.WriteLine("CarName:" + car.CarName + " / " + "BrandName:" + car.BrandName + " / " + "ColorName:" + car.ColorName + " / " + "DailyPrice:" + car.DailyPrice);
            //}


            //foreach (var car in carManager.GetCarDetails())
            //{
            //    Console.WriteLine(car.CarName + "/" + car.BrandName + "/" + car.ColorName + "/" + car.DailyPrice);
            //}


            var result = carManager.GetCarDetails();

            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {

                    Console.WriteLine(car.CarName + "/" + car.BrandName + "/" +car.ColorName);

                }

            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
    }





