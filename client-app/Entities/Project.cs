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

        [MaxLength(9, ErrorMessage = "Incorrect ID Number")]
        [MinLength(9, ErrorMessage = "Incorrect ID Number")]
        public string guideId { get; set; }

        public string guideName { get; set; }

        [Required(ErrorMessage = "Main Student ID Required")]
        [MaxLength(9, ErrorMessage = "Incorrect ID Number")]
        [MinLength(9, ErrorMessage = "Incorrect ID Number")]
        public string studentId { get; set; }

        [Required(ErrorMessage = "Main Student Name Required")]
        public string studentName { get; set; }

        [MaxLength(9, ErrorMessage = "Incorrect ID Number")]
        [MinLength(9, ErrorMessage = "Incorrect ID Number")]
        public string assistantStudentId { get; set; }

        public string assistantStudentName { get; set; }

        public bool isActive { get; set; }

        public bool isPass { get; set; }

        public List<Status> projectStatuses { get; set; }

        public List<Status> guidingStatuses { get; set; }

        public ProjectProposal projectProposal { get; set; }
    }
}
