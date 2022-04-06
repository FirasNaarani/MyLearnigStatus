using LearnSchoolApp.Entities;
using LearnSchoolApp.Models;
using LearnSchoolApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnSchoolApp.Controllers
{
    public class ProjectController : Controller
    {
        private readonly ProjectService _projectService;

        public ProjectController(ProjectService projectService)
        {
            _projectService = projectService;
        }
        // GET: ProjectController
        [ActionName("Index")]
        //[Authorize(Roles = "Admin,HeadOfDeprament")]
        public ActionResult Index()
        {
            var ls = _projectService.Get();
            if (ls == null)
            {
                return NotFound();
            }
            List<Project> res = ls.ToList();
            return View(res);
        }

        // GET: ProjectController/Details/5
        [ActionName("Details")]
        //[Authorize]
        public ActionResult Details(string id)
        {
            if (_projectService.Get(id) == null)
                return NotFound();
            return View(_projectService.Get(id));
        }

        // GET: ProjectController/Create
        [ActionName("Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProjectController/Create
        [HttpPost]
        [ActionName("Create")]
        //[Authorize(Roles = "Admin,HeadOfDeprament")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Project collection)
        {
            try
            {
                //if (ModelState.IsValid)
                {
                    _projectService.Create(collection);

                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return StatusCode(500, new Result<Project>(e.Message));
            }
        }

        // GET: ProjectController/Edit/5
        [ActionName("Edit")]
        //[Authorize(Roles = "Admin,HeadOfDeprament")]
        public ActionResult Edit(string id)
        {
            if (id == null)
                return BadRequest();

            Project student = _projectService.Get(id);

            if (student == null)
                return NotFound();

            return View(student);
        }

        // POST: ProjectController/Edit/5
        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Project collection)
        {
            try
            {
                //if (ModelState.IsValid)
                {
                    _projectService.Update(collection.Id, collection);
                    Console.WriteLine("Updated");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(collection);
            }
        }

        // GET: ProjectController/Delete/5
        [ActionName("Delete")]
        //[Authorize(Roles = "Admin")]
        public ActionResult Delete(string id)
        {
            if (id == null)
                return BadRequest();

            Project student = _projectService.Get(id);

            if (student == null)
                return NotFound();

            return View(student);
        }

        // POST: ProjectController/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            try
            {
                _projectService.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return StatusCode(500, new Result<Student>(e.Message));
            }
        }
    }
}
