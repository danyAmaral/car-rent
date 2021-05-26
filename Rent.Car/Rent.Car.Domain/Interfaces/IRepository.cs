﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rent.Car.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id, params Expression<Func<T, object>>[] includes);
        List<T> GetAll(Expression<Func<T, bool>> where = null, params Expression<Func<T, object>>[] includes);
        T Create(T obj);
        void Delete(int id);
        T Update(T obj);
    }
}
