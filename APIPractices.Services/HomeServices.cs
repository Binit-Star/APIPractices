using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using APIPractices.DataAccess.interfaces;
using APIPractices.Models;
using APIPractices.Services.interfaces;

namespace APIPractices.Services
{
    public class HomeServices:IHomeServices
    {
        private readonly IProducts _products;
        public HomeServices(IProducts products)
        {
            this._products = products;
        }

        public Task<int> AddProduct(ProductsModel product)
        {
            return Task.Run(() => _products.Add(product));
        }

        public Task<int> DeleteProduct(ProductsModel product)
        {
            return Task.Run(() => _products.Delete(product));
        }

        public Task<List<ProductsModel>> GetProducts()
        {
            return Task.Run(() => _products.SelectAll());
        }

        public Task<int> UpdateProduct(ProductsModel product)
        {
            return Task.Run(() => _products.Update(product));
        }
    }
}
