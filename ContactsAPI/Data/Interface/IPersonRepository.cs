using ContactsAPI.Model;
using MongoDB.Bson;

namespace ContactsAPI.Data.Interface
{
    public interface IPersonRepository
    {
        Task<List<Person>> GetPersonAsync();
        
        Task<Person> GetPersonByIdAsync(ObjectId id);

        Task CreatePersonAsync(Person person);

        Task UpdatePersonAsync(ObjectId id, Person person);

        Task DeletePersonAsync(ObjectId id);

    }
}
