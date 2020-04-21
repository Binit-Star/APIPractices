using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using APIPractices.DataAccess.interfaces;
using APIPractices.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;


namespace APIPractices.DataAccess
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private APIPracticesDB db;
        private DbSet<T> table;
        public GenericRepository(APIPracticesDB DB)
        {
            this.db = DB;
            table = db.Set<T>();
        }
        
        public int Add(T entity)
        {
            table.Add(entity);
            int x = db.SaveChanges();
            return x;
        }

        public int Delete(T entity)
        {
            table.Remove(entity);
            int x = db.SaveChanges();
            return x;
        }

        public int Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
            return db.SaveChanges();
            
        }

        public int Edit(T entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            return db.SaveChanges();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public List<T> SelectAll()
        {
            return table.ToList();
        }

        public T SelectByID(object id)
        {
            return table.Find(id);
        }

        public int Update(T entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            return db.SaveChanges();
        }

        #region Stored Proc Call #1

        public List<T> Get_StoredProc(string sPName)
        {
            return db.Set<T>().FromSqlRaw(sPName).ToList();
            //return db.Database.SqlQuery<T>(sPName).ToList();
        }

        public T Get_StoredProcForT(string sPName)
        {
            return db.Set<T>().FromSqlRaw(sPName).FirstOrDefault();
            //return db.Database.ExecuteSqlCommand<T>(sPName).FirstOrDefault();

        }

        public List<T> Get_StoredProc2(string Spname, Dictionary<object, object> parms)
        {
            var spname = "Exec " + Spname + " ";
            var objParams = new SqlParameter[0];

            try
            {
                if (parms.Count > 0)
                {
                    objParams = new SqlParameter[parms.Count];
                    int i = 0;
                    foreach (var item in parms)
                    {
                        SqlParameter param = new SqlParameter(item.Key.ToString(), item.Value);
                        objParams[i] = param;
                        if (i == 0)
                        {
                            spname += item.Key.ToString();
                        }
                        else
                        {
                            spname += "," + item.Key.ToString();
                        }
                        i++;
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return db.Set<T>().FromSqlRaw(spname, objParams).ToList();
        }

        public List<T> Get_StoredProc_Name(T entity, Dictionary<object, object> parms)
        {
            Type typeParameterType = typeof(T);
            var spname = "Exec " + typeParameterType.Name + " ";
            var objParams = new SqlParameter[0];
            try
            {
                if (parms.Count > 0)
                {
                    objParams = new SqlParameter[parms.Count];
                    int i = 0;
                    foreach (var item in parms)
                    {
                        SqlParameter param = new SqlParameter(item.Key.ToString(), item.Value);
                        objParams[i] = param;
                        if (i == 0)
                        {
                            spname += item.Key.ToString();
                        }
                        else
                        {
                            spname += "," + item.Key.ToString();
                        }
                        i++;
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //return db.Database.ExecuteSqlCommand<T>(spname, objParams).ToList();
            return db.Set<T>().FromSqlRaw(spname, objParams).ToList();
        }


        public T Details(T entity, Dictionary<object, object> parms)
        {
            Type typeParameterType = typeof(T);
            var spname = typeParameterType.Name + " ";
            var objParams = new SqlParameter[0];
            try
            {
                if (parms.Count > 0)
                {
                    objParams = new SqlParameter[parms.Count];
                    int i = 0;
                    foreach (var item in parms)
                    {
                        SqlParameter param = new SqlParameter(item.Key.ToString(), item.Value);
                        objParams[i] = param;
                        if (i == 0)
                        {
                            spname += item.Key.ToString();
                        }
                        else
                        {
                            spname += "," + item.Key.ToString();
                        }
                        i++;
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return db.Set<T>().FromSqlRaw(spname, objParams).FirstOrDefault();
        }





        public void void_sp(string Procname, Dictionary<object, object> parms)
        {

            var spname = "EXEC " + Procname + " ";
            var objParams = new SqlParameter[0];
            try
            {
                if (parms.Count > 0)
                {
                    objParams = new SqlParameter[parms.Count];
                    int i = 0;
                    foreach (var item in parms)
                    {
                        SqlParameter param = new SqlParameter(item.Key.ToString(), item.Value);
                        objParams[i] = param;
                        if (i == 0)
                        {
                            spname += item.Key.ToString();
                        }
                        else
                        {
                            spname += "," + item.Key.ToString();
                        }
                        i++;
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            db.Database.ExecuteSqlCommand(spname, objParams);
        }
        #endregion


        #region Stored Proc Call #2

        /// <summary>
        /// Get Data From Database
        /// <para>Use it when to retive data through a stored procedure</para>
        /// </summary>
        public IEnumerable<T> ExecuteQuery(string spQuery, object[] parameters)
        {

            return db.Set<T>().FromSqlRaw(spQuery, parameters).ToList();

        }

        /// <summary>
        /// Get Single Data From Database
        /// <para>Use it when to retive single data through a stored procedure</para>
        /// </summary>
        public T ExecuteQuerySingle(string spQuery, object[] parameters)
        {

            return db.Set<T>().FromSqlRaw(spQuery, parameters).FirstOrDefault();

        }

        /// <summary>
        /// Insert/Update/Delete Data To Database
        /// <para>Use it when to Insert/Update/Delete data through a stored procedure</para>
        /// </summary>
        public virtual int ExecuteCommand(string spQuery, object[] parameters)
        {
            int result = 0;
            try
            {

                result = db.Database.ExecuteSqlCommand(spQuery, parameters);

            }
            catch { }
            return result;
        }

        public virtual int JCExecuteCommand(string spQuery, Dictionary<object, object> parms)
        {
            var spname = "EXEC " + spQuery + " ";
            var objParams = new SqlParameter[0];
            try
            {
                if (parms.Count > 0)
                {
                    objParams = new SqlParameter[parms.Count];
                    int i = 0;
                    foreach (var item in parms)
                    {
                        SqlParameter param = new SqlParameter(item.Key.ToString(), item.Value);
                        objParams[i] = param;
                        if (i == 0)
                        {
                            spname += item.Key.ToString();
                        }
                        else
                        {
                            spname += "," + item.Key.ToString();
                        }
                        i++;
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return db.Database.ExecuteSqlCommand(spname, objParams);

        }

        public virtual string JCExecuteCommandString(string spQuery, Dictionary<object, object> parms)
        {
            var spname = "EXEC " + spQuery + " ";
            var objParams = new SqlParameter[0];
            try
            {
                if (parms.Count > 0)
                {
                    objParams = new SqlParameter[parms.Count];
                    int i = 0;
                    foreach (var item in parms)
                    {
                        SqlParameter param = new SqlParameter(item.Key.ToString(), item.Value);
                        objParams[i] = param;
                        if (i == 0)
                        {
                            spname += item.Key.ToString();
                        }
                        else
                        {
                            spname += "," + item.Key.ToString();
                        }
                        i++;
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            string x = db.Set<string>().FromSqlRaw(spname, objParams).FirstOrDefault();
            return x;
        }

        #endregion

    }
}
