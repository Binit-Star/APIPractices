using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using APIPractices.Models;
using APIPractices.Models.VM;

namespace APIPractices.Services.interfaces
{
    
    public interface IHomeServices
    {
        Task<int> AddProduct(ProductsModel product);
        Task<int> UpdateProduct(ProductsModel product);
        Task<int> DeleteProduct(ProductsModel product);
        Task<List<ProductsModel>> GetProducts();
        Task<List<ProductVM>> GetProductsVM(string spName);
    }
}
