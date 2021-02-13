using Business.Abstract;
using Business.Concrete;
using Entities.Abstract;
using Entities.Concrete;
using Entities.Concrete.InMemory;
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

