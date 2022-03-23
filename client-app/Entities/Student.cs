using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace LearnSchoolApp.Entities
{
    public class Student : UpdateUser
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [Required(ErrorMessage = "Study Year Required")]
        public StudyYear StudyYear { get; set; }

        public bool isActive { get; set; }


    }
}
