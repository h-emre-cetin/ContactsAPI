using ContactsAPI.Model;
using MongoDB.Driver;

namespace ContactsAPI.Data
{
    public class MongoDbSettings
    {
        private readonly IConfiguration _configuration;
        private readonly IMongoDatabase _database;

        public MongoDbSettings(IConfiguration configuration)
        {
            _configuration = configuration;

            var connectionString = _configuration.GetConnectionString("DbConnection");
            var databaseName = configuration.GetConnectionString("DatabaseName");

            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }
    }
}
