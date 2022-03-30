using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnSchoolApp.Entities
{
    public class Status
    {
        public string projectId { get; set; }

        public string currentStatus { get; set; }

        public DateTime date { get; set; }

        public bool isPass { get; set; }
    }
}
