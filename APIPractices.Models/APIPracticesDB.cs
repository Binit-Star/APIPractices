using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;


namespace APIPractices.Models
{
    public class APIPracticesDB:DbContext
    {
        public APIPracticesDB(DbContextOptions<APIPracticesDB> options):base(options)
        {

        }

        public DbSet<ProductsModel> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            

            
        }
    }
}
