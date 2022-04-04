using LearnSchoolApp.Entities;
using LearnSchoolApp.Models;
using LearnSchoolApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnSchoolApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProjectController : ControllerBase
    {
        private readonly ProjectService _projectService;

        public ProjectController(ProjectService projectService)
        {
            _projectService = projectService;
        }
        [HttpGet]
        public ActionResult<List<Project>> Get() =>
            _projectService.Get();

        [HttpGet("{id:length(24)}", Name = "GetProject")]
        public ActionResult<Result<Project>> Get(string id)
        {
            var Project = _projectService.Get(id);
            if (Project == null)
            {
                return NotFound();
            }
            return new Result<Project>(Project);
        }

        [HttpPost]
        public ActionResult<Result<Project>> Create(Project project)
        {
            try
            {
                if (!_projectService.isDuplicateProject(project.name, project.studentId))
                {

                    _projectService.Create(project);
                    return CreatedAtRoute("GetProject", new { id = project.Id.ToString() }, project);
                }
                else
                {
                    return StatusCode(403, "Duplicate Project");
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, new Result<Project>(e.Message));
            }
        }

        //[HttpPut("{id:length(24)}")]
        //public IActionResult Update(string id, UpdateUser ProjectIn)
        //{
        //    var book = _projectService.Get(id);

        //    if (book == null)
        //    {
        //        return NotFound();
        //    }
        //    _projectService.Update(id, ProjectIn);
        //    return NoContent();
        //}

        //[HttpPut("password/{id:length(24)}")]
        //public IActionResult UpdatePassword(string id, UpdatePassword ProjectIn)
        //{
        //    var book = _projectService.Get(id);

        //    if (book == null)
        //    {
        //        return NotFound();
        //    }
        //    _projectService.UpdatePassword(id, ProjectIn);
        //    return NoContent();
        //}

        [HttpDelete("{id:length(24)}")]
        [Authorize]
        public IActionResult Delete(string id)
        {
            var command = _projectService.Get(id);

            if (command == null)
            {
                return NotFound();
            }
            _projectService.Delete(id);
            return NoContent();
        }
    }
}
