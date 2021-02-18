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
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=C:\USERS\USER\SOURCE\REPOS\RECAPPROJECT\DATAACCESS\CARRENTALSYSTEMDBCONTEXT.MDF; Trusted_Connection=True");
        }
    }
}

