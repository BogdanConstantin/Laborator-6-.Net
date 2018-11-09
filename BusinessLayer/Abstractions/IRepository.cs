using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer.Entities;

namespace BusinessLayer.Abstractions
{
    public interface IRepository
    {
        void Create<T>(T entity)
            where T : BaseEntity;

        void Update<T>(T entity)
            where T : BaseEntity;

        Task<ICollection<T>> GetAll<T>()
            where T : BaseEntity;

        Task<T> GetById<T>(Guid Id)
            where T : BaseEntity;

        void Delete<T>(T entity)
            where T : BaseEntity;

        void Save();
    }
}
