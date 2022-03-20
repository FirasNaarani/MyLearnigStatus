using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Entities
{
    public class StudyYear
    {
        [BsonId]
        [BsonRepresentation(BsonType.Decimal128)]
        public string Id { get; set; }

        [Required(ErrorMessage = "From Date Required")]
        public DateTime From { get; set; }

        [Required(ErrorMessage = "To Date Required")]
        public DateTime To { get; set; }
    }
}
