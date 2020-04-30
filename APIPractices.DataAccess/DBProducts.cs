using APIPractices.DataAccess.interfaces;
using APIPractices.Models;
using APIPractices.Models.VM;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APIPractices.DataAccess
{
    
    public class DBProducts : GenericRepository<ProductsModel>, IProducts
    {

        public DBProducts(APIPracticesDB db):base(db)
        {

        }

       
    }

    public class DBProductVM : GenericRepository<ProductVM>, IProductVM
    {

        public DBProductVM(APIPracticesDB db) : base(db)
        {

        }


    }
}
