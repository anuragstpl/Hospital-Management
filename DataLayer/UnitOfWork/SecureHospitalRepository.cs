﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace DataLayer.UnitOfWork
{
    public class SecureHospitalRepository<T> where T : class
    {
        internal SecureHospitalEntities context;
        internal DbSet<T> dbset;

        public SecureHospitalRepository(SecureHospitalEntities context)
        {
            this.context=context;
            this.dbset=context.Set<T>();
        }

        public virtual IEnumerable<T> Get()
        {
            IQueryable<T> query = dbset;
            return query.ToList();
        }

        public virtual T GetById(object id)
        {
            return dbset.Find(id);
        }

        public virtual void Insert(T entity)
        {
            dbset.Add(entity);
        }

        public virtual void Delete(object id)
        {
            T entityToDelete = dbset.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(T entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbset.Attach(entityToDelete);
            }
            dbset.Remove(entityToDelete);
        }

        public virtual void Update(T entityToUpdate)
        {
            dbset.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public virtual IEnumerable<T> SQLQuery<T>(string sql)
        {
            return context.Database.SqlQuery<T>(sql);
        }

        public virtual IEnumerable<T> SQLQueryWithParameters<T>(string sql, params object[] parameters)
        {
            return context.Database.SqlQuery<T>(sql, parameters);
        }

    }
}
