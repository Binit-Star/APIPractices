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
        List<T> Get_StoredProc(string Spname);
        List<T> Get_StoredProc2(string Spname, Dictionary<object, object> parms);
        List<T> Get_StoredProc_Name(T entity, Dictionary<object, object> parms);
        void void_sp(string spname, Dictionary<object, object> parms);
        IEnumerable<T> ExecuteQuery(string spQuery, object[] parameters);
        T ExecuteQuerySingle(string spQuery, object[] parameters);
        int ExecuteCommand(string spQuery, object[] parameters);
        int JCExecuteCommand(string spQuery, Dictionary<object, object> parms);
        string JCExecuteCommandString(string spQuery, Dictionary<object, object> parms);
        T Details(T entity, Dictionary<object, object> parms);
        T Get_StoredProcForT(string SpName);
    }
}
