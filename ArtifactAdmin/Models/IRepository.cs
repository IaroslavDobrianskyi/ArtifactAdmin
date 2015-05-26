// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRepository.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the IRepository interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ArtifactAdmin.DAL.Models
{
    using System;
    using System.Linq;

    public interface IRepository<T>
    {
        IQueryable<T> GetAll();
        
        void Insert(T entity);
        
        void InsertDependent(T entity, string[] obj);
        
        void Update(T entity);

        void UpdateDependent(T entity, string[] obj);
        
        void Delete(T entity);
        
        void SaveChanges();
    }
}