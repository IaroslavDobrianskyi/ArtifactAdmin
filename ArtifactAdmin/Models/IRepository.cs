// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRepository.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the IRepository interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Linq;

namespace ArtifactAdmin.DAL.Models
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();

        IQueryable<T> GetAllNoTracking();
        
        void Insert(T entity);
        
        void InsertWithoutSave(T entity);
 
        void Update(T entity);

        void UpdateWithoutSave(T entity); 
        
        void Delete(T entity);

        void DeleteWithOutSave(T entity);
        
        void SaveChanges();

        int QuestStarter(int id);
    }
}