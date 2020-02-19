using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using APIPractices.Models;

namespace APIPractices.DataAccess.interfaces
{
    public interface IProducts:IGenericRepository<ProductsModel>
    {
        //Task<int> AddProduct(ProductsModel product);
        //Task<int> UpdateProduct(ProductsModel product);
        //Task<int> DeleteProduct(ProductsModel product);
        //Task<List<ProductsModel>> GetProducts();
    }
}
