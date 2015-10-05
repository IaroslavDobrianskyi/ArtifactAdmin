using System;

namespace ArtifactAdmin.BL.Interfaces
{
    public interface ICacheService
    {
        T GetOrSet<T>(string cacheKey, Func<T> getItemCallback) where T : class;
    }
}
