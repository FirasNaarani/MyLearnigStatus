using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace LearnSchoolApp.Entities
{
    public class HeadOfDeprament : UpdateUser
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [Required(ErrorMessage = "Is Guid Required")]
        public bool isGuid { get; set; }

        public bool isActive { get; set; }
    }
}
