using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnSchoolApp.Entities
{
    public class ProjectProposal
    {
        public IFormFile proposalPdf { get; set; }

        public string proposalPdfUrl { get; set; }

        public bool isPass { get; set; }
    }
}
