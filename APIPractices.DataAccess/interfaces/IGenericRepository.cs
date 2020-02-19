using System;
using System.Collections.Generic;
using System.Text;

namespace APIPractices.DataAccess.interfaces
{
    public interface IGenericRepository<T> where T:class
    {
        List<T> SelectAll();
        T SelectByID(object id);
        int Add(T entity);
        int Edit(T entity);
        int Update(T entity);
        int Delete(T entity);
        int Delete(object id);
        void Save();
    }
}
