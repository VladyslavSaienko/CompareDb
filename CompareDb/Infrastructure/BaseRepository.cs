using System.Configuration;
using MongoDB.Driver;

namespace CompareDb.Infrastructure
{
    public abstract class BaseRepository<T>
    {
        protected IMongoCollection<T> Collection { get; }

        protected BaseRepository(string collectionName)
        {
            var url = new MongoUrl(ConfigurationManager.AppSettings["MongoDbConnectionString"]);
            var client = new MongoClient(url);
            Collection = client.GetDatabase(url.DatabaseName).GetCollection<T>(collectionName);
        }
    }
}
