using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;


namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            
            ICarService carManager = new CarManager(new EfCarDal());


            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine("Model" + "   "+ "Yıl" +"  " + "Fiyat");
            //    Console.WriteLine(car.Description + " " + car.ModelYear + " " + car.DailyPrice);
            //    Console.WriteLine("---------------------------------");

            //}

            foreach (var car in carManager.GetAllByBrandId(3))
            {
                Console.WriteLine(car.Description);
            }
            
         }
    }
    }





