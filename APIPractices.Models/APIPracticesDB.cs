using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using APIPractices.Models.VM;
using Microsoft.EntityFrameworkCore;


namespace APIPractices.Models
{
    public class APIPracticesDB:DbContext
    {
       

        public APIPracticesDB(DbContextOptions<APIPracticesDB> options):base(options)
        {

        }

        public DbSet<ProductsModel> Product { get; set; }
        public DbSet<ProductVM> ProductVM { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ProductVM>().HasNoKey().ToView(null);


        }
    }
}
