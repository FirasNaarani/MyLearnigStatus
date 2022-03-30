using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LearnSchoolApp.Entities
{
    public class Manager : UpdateUser
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        public bool isActive { get; set; }


    }
}
