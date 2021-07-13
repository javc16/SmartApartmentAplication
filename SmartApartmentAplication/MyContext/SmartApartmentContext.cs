using Microsoft.EntityFrameworkCore;
using SmartApartmentAplication.Features.Mgmt;
using SmartApartmentAplication.Features.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartApartmentAplication.MyContext
{
    public class SmartApartmentContext : DbContext
    {
        public SmartApartmentContext(DbContextOptions<SmartApartmentContext> options) : base(options)
        { }

        public DbSet<mgmtHeader> mgmtHeader { get; set; }
        public DbSet<mgmtDetail> mgmtDetail { get; set; }
        public DbSet<propertyHeader> propertyHeader { get; set; }
        public DbSet<propertyDetail> propertyDetail { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {            
            optionBuilder.UseSqlServer(@"Server=database-1.cwyafa0gf6ea.us-east-1.rds.amazonaws.com,1433;Database=SmartApartment;User Id=admin;Password=hola1234");           
        }
    }
}
