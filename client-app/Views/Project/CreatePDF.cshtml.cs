using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnSchoolApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LearnSchoolApp.Views.Project
{
    public class CreatePDFModel : PageModel
    {
        private readonly IProjectProposalService _projectProposalService;

        public CreatePDFModel(ProjectProposalService projectProposalService)
        {
            _projectProposalService = projectProposalService;
        }

        public void OnGet()
        {
        }
    }
}
