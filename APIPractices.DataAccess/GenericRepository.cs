using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using APIPractices.DataAccess.interfaces;
using APIPractices.Models;
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
    }
}
