using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace APIPractices.Models
{
    public class ProductsModel
    {
        [Key]
        public int SNo { get; set; }
        public string Name { get; set; }
        public decimal Quantity { get; set; }
        public double Price { get; set; }
    }
}
