using Bionet4.Data.Common;
using Bionet4.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;

namespace Bionet4.Data.Repository
{
    public abstract class RepositoryBase<T, TKey> : IRepository<T, TKey> where T : class, IEntity<TKey>
    {
        private bool disposed;

        protected DbContext DbContext { get; private set; }
        protected IDbSet<T> DbSet
        {
            get
            {
                return this.DbContext.Set<T>();
            }
        }

        public RepositoryBase(IDbContextFactory factory) : this(factory.GetDbContext())
        {
        }

        public RepositoryBase(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            this.DbContext = context;
        }

        public virtual T GetById(TKey id)
        {
            return this.DbSet.Find(id);
        }

        public virtual IPagedCollection GetPaged(IFilter<T, TKey> filter)
        {
            T[] entities;

            if (filter.OrderBy == null && filter.OrderByDescending == null)
            {
                entities = this.DbSet
                .Where(filter.Where)
                .Skip((filter.PageIndex - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToArray();
            }
            else if (filter.OrderBy == null)
            {
                entities = this.DbSet
                .OrderByDescending(filter.OrderByDescending)
                .Where(filter.Where)
                .Skip((filter.PageIndex - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToArray();
            }
            else
            {
                entities = this.DbSet
                .OrderBy(filter.OrderBy)
                .Where(filter.Where)
                .Skip((filter.PageIndex - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToArray();
            }

            int totalCount = this.DbSet.Count(filter.Where);

            return new PagedCollection<T>(entities, filter.PageIndex, filter.PageSize, totalCount);
        }

        public ICollection<T> GetPagedList(IFilter<T, TKey> filter)
        {
            T[] entities;

            if (filter.OrderBy == null && filter.OrderByDescending == null)
            {
                entities = this.DbSet
                .Where(filter.Where)
                .Skip((filter.PageIndex - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToArray();
            }
            else if (filter.OrderBy == null)
            {
                entities = this.DbSet
                .OrderByDescending(filter.OrderByDescending)
                .Where(filter.Where)
                .Skip((filter.PageIndex - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToArray();
            }
            else
            {
                entities = this.DbSet
                .OrderBy(filter.OrderBy)
                .Where(filter.Where)
                .Skip((filter.PageIndex - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToArray();
            }

            return entities.ToList();
        }

        public ICollection<T> GetList()
        {
            return this.DbSet.Where(x => true).ToArray();
        }

        public virtual T Insert(T entity)
        {
            try
            {
                this.DbSet.Add(entity);
                this.DbContext.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                throw;
            }

            return entity;
        }

        public virtual T Update(T entity)
        {
            this.DbSet.Attach(entity);
            this.DbContext.Entry(entity).State = EntityState.Modified;
            this.DbContext.SaveChanges();
            return entity;
        }

        public virtual T Delete(T entity)
        {
            this.DbSet.Remove(entity);
            this.DbContext.SaveChanges();
            return entity;
        }

        public virtual IQueryable<T> Query()
        {
            return this.DbSet;
        }

        public DbContext GetContext()
        {
            return this.DbContext;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (this.DbContext != null)
                    {
                        this.DbContext.Dispose();
                    }
                }
                disposed = true;
            }
        }

        ~RepositoryBase()
        {
            Dispose(false);
        }
    }
}
