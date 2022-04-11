using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LearnSchoolApp.Entities
{
    public class Status
    {
        public int Id { get; set; }
        
        public string projectId { get; set; }

        public string userId { get; set; }

        public string currentStatus { get; set; }

        [DataType(DataType.Date)]
        public DateTime date { get; set; }

        public bool isPass { get; set; }
    }
}
