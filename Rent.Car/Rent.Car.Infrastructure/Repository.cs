using Microsoft.EntityFrameworkCore;
using Rent.Car.Domain.Entities;
using Rent.Car.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Rent.Car.Infrastructure
{
    public abstract class Repository<T> : IRepository<T> where T : class, IEntity
        {
            protected RentCarContext ctx;
            public Repository(RentCarContext ctx)
            {
                this.ctx = ctx;
            }
            public virtual T Create(T obj)
            {
                this.ctx.Set<T>().Add(obj);
                this.ctx.SaveChanges();

                return obj;
            }

            public virtual void Delete(int id)
            {
                var item = this.ctx.Set<T>().Find(id);
                this.ctx.Set<T>().Remove(item);
                this.ctx.SaveChanges();
            }

            public virtual List<T> GetAll(Expression<Func<T, bool>> where = null, params Expression<Func<T, object>>[] includes)
            {
                var query = this.ctx.Set<T>().AsQueryable();
                if (where != null)
                    query = query.Where(where);

                if (includes != null & includes.Any())
                {
                    foreach (var include in includes)
                    {
                        query = query.Include(include);
                    }
                }

                return query.ToList();
            }

            public virtual T GetById(int id, params Expression<Func<T, object>>[] includes)
            {
                var query = this.ctx.Set<T>().AsQueryable();

                if (includes != null & includes.Any())
                {
                    foreach (var include in includes)
                    {
                        query = query.Include(include);
                    }
                }

                return query.FirstOrDefault(x => x.Id == id);
            }

            public virtual T Update(T obj)
            {
                if (obj == null)
                    return null;

                this.ctx.Entry(obj).CurrentValues.SetValues(obj);
                this.ctx.SaveChanges();

                return obj;
            }
        }
    }