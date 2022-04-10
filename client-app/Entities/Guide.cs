using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LearnSchoolApp.Entities
{
    public class Guide : UpdateUser
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        //[Required(ErrorMessage = "Is Head Of Depratment Required")]
        //public bool isHeadOfDepratment { get; set; }

        public List<Project> projects { get; set; }

        public bool isActive { get; set; }
    }
}
