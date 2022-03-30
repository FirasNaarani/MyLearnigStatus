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
        public string name { get; set; }

        public string guideId { get; set; }

        [Required(ErrorMessage = "Main Student ID Required")]
        public string studentId { get; set; }

        public string assistantStudentId { get; set; }
        
        public bool isActive { get; set; }

        public bool isPass { get; set; }

        public List<Status> projectStatuses { get; set; }

        public List<Status> guidingStatuses { get; set; }

        public ProjectProposal projectProposal { get; set; }
    }
}
