using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LearnSchoolApp.Entities
{
    public class Project
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [Required(ErrorMessage = "Project Name Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Main Student ID Required")]
        public string StudentId { get; set; }

        public string AssistantStudent { get; set; }
    }
}
