using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Runtime.Serialization;

namespace ContactsAPI.Model
{
    public class Person
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("firstName")]
        [BsonRequired]
        public string FirstName { get; set; }

        [BsonElement("lastName")]
        [BsonRequired]
        public string LastName { get; set; }

        [BsonElement("company")]
        [BsonRequired]
        public string Company { get; set; }

        [BsonElement("contactInfos")]
        public List<ContactInfo> ContactInfos { get; set; }

    }
}
