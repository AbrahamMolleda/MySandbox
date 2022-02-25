using Data.MongoDB.Component.Persistence;
using Data.MongoDB.Component.Services.Contracts;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.MongoDB.Component.Services
{
    public class MongoRepository<T> : IMongoRepository<T> where T : IMongoDocument
    {
        private readonly IMongoCollection<T> _collection;
        private readonly IConfiguration _configuration;
        public MongoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            var client = new MongoClient(_configuration["MongoDB:ConnectionString"]);
            var db = client.GetDatabase(this.GetDataBaseName(typeof(T)));
            _collection = db.GetCollection<T>(this.GetCollectionName(typeof(T)));
        }


        private protected string GetCollectionName(Type documentType)
        {

            return ((MongoCollectionAttribute)documentType.GetCustomAttributes(typeof(MongoCollectionAttribute), true).FirstOrDefault()).CollectionName;
        }

        private protected string GetDataBaseName(Type documentType)
        {
            return ((MongoDatabaseAttribute)documentType.GetCustomAttributes(typeof(MongoDatabaseAttribute), true).FirstOrDefault()).DatabaseName;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _collection.Find(p => true).ToListAsync();
        }

        public async Task<T> GetByGuidAsync(string id)
        {
            FilterDefinition<T> filter = Builders<T>.Filter.Eq(doc => doc.Id, id);
            return await _collection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<string> InsertDocumentAsync(T document)
        {
            await _collection.InsertOneAsync(document);
            return document.Id;
        }

        public async Task UpdateDocumentAsync(T document)
        {
            FilterDefinition<T> filter1 = Builders<T>.Filter.Eq(doc => doc.Id, document.Id);
            T searchedDocument = await _collection.Find(filter1).SingleOrDefaultAsync();
            document.Id = searchedDocument.Id;

            FilterDefinition<T> filter2 = Builders<T>.Filter.Eq(doc => doc.Id, document.Id);
            await _collection.FindOneAndReplaceAsync(filter2, document);
        }

        public async Task DeleteByGuidAsync(string guid)
        {
            FilterDefinition<T> filter = Builders<T>.Filter.Eq(doc => doc.Id, guid);
            await _collection.FindOneAndDeleteAsync(filter);
        }

        public async Task<T> GetLastGeneratedAsync()
        {
            //T last = _collection.AsQueryable().OrderByDescending(c => c.GenerationDate).LastOrDefault();
            List<T> list = await _collection.Find(p => true).ToListAsync();
            T lastElement = list.OrderByDescending(c => c.Id).LastOrDefault();
            return lastElement;
        }
    }
}
