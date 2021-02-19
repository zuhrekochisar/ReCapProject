﻿using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    class CarRentalDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=CarRentalSystemNew; Trusted_Connection=True");
        }

        public DbSet<Car> Cars { get; set; }                                 //C:\Users\USER\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\CarRentalSystemNew.mdf
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }
    }
}

