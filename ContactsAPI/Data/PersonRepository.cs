using ContactsAPI.Data.Interface;
using ContactsAPI.Model;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Reflection;

namespace ContactsAPI.Data
{
    public class PersonRepository: IPersonRepository
    {
        private readonly IMongoCollection<Person> _personCollection;
        private readonly ILogger _logger;

        public PersonRepository(
            IMongoClient mongoClient,
            MongoDbSettings settings,
            ILogger logger)
        {
            logger = logger ?? throw new ArgumentNullException(nameof(logger));

            var database = mongoClient.GetDatabase("DatabaseName");
            _personCollection = database.GetCollection<Person>("Persons");
            _logger = logger;
        }


        public async Task<List<Person>> GetPersonAsync() 
        {
            const string methodName = nameof(GetPersonAsync);

            try
            {
                var people = await _personCollection.Find(_ => true).ToListAsync();

                return people;
            }
            catch (Exception ex)
            {
                _logger.LogError($"[{methodName}] Failed, reason: {ex.Message}");
                throw;
            }
        }

        public async Task<Person> GetPersonByIdAsync(ObjectId id)
        {
            const string methodName = nameof(GetPersonByIdAsync);

            try
            {
                var peopleById = await _personCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

                return peopleById;
            }
            catch (Exception ex)
            {
                _logger.LogError($"[{methodName}] Failed, reason: {ex.Message}");
                throw;
            }
        }

        public async Task CreatePersonAsync(Person person)
        {
            const string methodName = nameof(CreatePersonAsync);

            try
            {
                await _personCollection.InsertOneAsync(person);
            }

            catch (Exception ex)
            {
                _logger.LogError($"[{methodName}] Failed, reason: {ex.Message}");
                throw;
            }
        }

        public async Task UpdatePersonAsync(ObjectId id, Person person)
        {
            const string methodName = nameof(UpdatePersonAsync);

            try
            {
                await _personCollection.ReplaceOneAsync(x => x.Id == id, person);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[{methodName}] Failed, reason: {ex.Message}");
                throw;
            }
        }

        public async Task DeletePersonAsync(ObjectId id)
        {
            const string methodName = nameof(DeletePersonAsync);

            try
            {
                await _personCollection.DeleteOneAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"[{methodName}] Failed, reason: {ex.Message}");
                throw;
            }
        }
    }
}
