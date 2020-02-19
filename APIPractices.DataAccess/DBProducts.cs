using APIPractices.DataAccess.interfaces;
using APIPractices.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APIPractices.DataAccess
{
    public class DBProducts : GenericRepository<ProductsModel>, IProducts
    {
        
        public DBProducts(APIPracticesDB aPIPracticesDB) : base(aPIPracticesDB)
        {
            
        }

        //public Task<int> AddProduct(ProductsModel product)
        //{
        //    return Task.Run(() => products.Add(product));

        //}

        //public Task<int> DeleteProduct(ProductsModel product)
        //{
        //    return Task.Run(() => products.Delete(product));
        //}

        //public Task<List<ProductsModel>> GetProducts()
        //{
        //    return Task.Run(() => products.SelectAll());
        //}

        //public Task<int> UpdateProduct(ProductsModel product)
        //{
        //    return Task.Run(() => products.Update(product));
        //}
    }
}