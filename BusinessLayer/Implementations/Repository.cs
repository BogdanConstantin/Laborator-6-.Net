using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Abstractions;
using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Implementations
{
    public abstract class Repository : IRepository
    {
        protected readonly PoiContext _poiContext;

        protected Repository(PoiContext poiContext)
        {
            _poiContext = poiContext;
        }

        public void Create<T>(T entity) where T : BaseEntity
        {
            _poiContext.Set<T>().Add(entity);
        }

        public void Update<T>(T entity) where T : BaseEntity
        {
            _poiContext.Set<T>().Update(entity);
        }

        public async Task<ICollection<T>> GetAll<T>() where T : BaseEntity
        {
            return await _poiContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetById<T>(Guid Id) where T : BaseEntity
        {
            return await _poiContext.Set<T>().SingleOrDefaultAsync(p => p.Id == Id);
        }

        public void Delete<T>(T entity) where T : BaseEntity
        {
            _poiContext.Set<T>().Remove(entity);
        }

        public  void Save()
        {
            _poiContext.SaveChanges();
        }
    }
}
