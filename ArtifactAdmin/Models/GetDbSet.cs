// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetDbSet.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the DbSet type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ArtifactAdmin.DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Reflection;

    public partial class artEntities 
    {
        private static readonly Dictionary<Type, PropertyInfo> DictionaryProperties = new Dictionary<Type, PropertyInfo>();

        public DbSet<T> GetPropertyByType<T>() where T : class
        {
            PropertyInfo property;
            if (!DictionaryProperties.TryGetValue(typeof(T), out property))
            {
                property = this.GetType()
                               .GetProperties()
                               .SingleOrDefault(p => p.PropertyType == typeof(DbSet<T>));

                if (property == null)
                {
                    return null;
                }

                DictionaryProperties.Add(typeof(T), property);
            }

            return (DbSet<T>)property.GetValue(this);
        }
    }
}