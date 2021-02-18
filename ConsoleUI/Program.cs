using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete;
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
            
            ICarService carManager = new CarManager(new InMemoryCarDal());
           

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Model" + "   "+ "Yıl" +"  " + "Fiyat");
                Console.WriteLine(car.Description + " " + car.ModelYear + " " + car.DailyPrice);
                Console.WriteLine("---------------------------------");
                
            }
            
         }
    }
    }

//Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\USER\OneDrive\Belgeler\CarRental.accdb



