using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using APIPractices.DataAccess.interfaces;
using APIPractices.Models;
using APIPractices.Models.VM;
using APIPractices.Services.interfaces;

namespace APIPractices.Services
{
    public class HomeServices:IHomeServices
    {
        private readonly IProducts _products;
        private readonly IProductVM _productVM;
        public HomeServices(IProducts products, IProductVM productVM)
        {
            this._products = products;
            this._productVM = productVM;
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

        public Task<List<ProductVM>> GetProductsVM(string spName)
        {
            //var x = _products.Get_StoredProc(spName);
            //foreach (var y in x)
            //{
            //    y.
            //}
            //throw new NotImplementedException();

            return Task.Run(() => _productVM.Get_StoredProc(spName));
        }

        public Task<int> UpdateProduct(ProductsModel product)
        {
            return Task.Run(() => _products.Update(product));
        }
    }
}
