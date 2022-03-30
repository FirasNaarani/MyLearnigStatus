using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LearnSchoolApp.Entities
{
    public class StudyYear
    {
        [Required(ErrorMessage = "From Date Required")]
        public string From { get; set; }

        [Required(ErrorMessage = "To Date Required")]
        public string To { get; set; }
    }
}
