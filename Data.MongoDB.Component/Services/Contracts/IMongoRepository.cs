using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.MongoDB.Component.Services.Contracts
{
    public interface IMongoRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByGuidAsync(string guid);
        Task<string> InsertDocumentAsync(T document);
        Task UpdateDocumentAsync(T document);
        Task DeleteByGuidAsync(string guid);
    }
}
