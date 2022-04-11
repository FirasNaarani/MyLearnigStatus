using LearnSchoolApp.Entities;
using LearnSchoolApp.Models;
using LearnSchoolApp.Services;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IProjectService _projectService;
        private readonly IGuideService _guideService;
        private readonly IStudentService _studentService;

        public ProjectController(ProjectService projectService, GuideService guideService, StudentService studentService)
        {
            _projectService = projectService;
            _guideService = guideService;
            _studentService = studentService;
        }

        [ActionName("Index")]
        [Authorize(Roles = "Admin,HeadOfDeprament")]
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

        [ActionName("Details")]
        [Authorize(Roles = "Admin,HeadOfDeprament")]
        public ActionResult Details(string id)
        {
            if (_projectService.Get(id) == null)
                return NotFound();
            return View(_projectService.Get(id));
        }

        [ActionName("GetGuide")]
        [Authorize(Roles = "Admin,HeadOfDeprament")]
        public ActionResult GetGuide(string id)
        {
            if (_guideService.GetMyGuide(id) == null)
                return NotFound();
            return View(_guideService.GetMyGuide(id));
        }

        [ActionName("Create")]
        [Authorize(Roles = "Admin,HeadOfDeprament")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        [Authorize(Roles = "Admin,HeadOfDeprament")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Project collection)
        {
            try
            {
                if (_studentService.isValidStudent(collection.studentId, collection.studentName))
                {
                    if (_studentService.isValidProject(collection.studentId))
                    {
                        if (collection.assistantStudentId != null && collection.assistantStudentName != null)
                        {
                            if (_studentService.isValidStudent(collection.assistantStudentId, collection.assistantStudentName))
                            {
                                if (_studentService.isValidProject(collection.assistantStudentId))
                                {
                                    _studentService.isProject(collection.assistantStudentId, true);
                                }
                                else
                                {
                                    TempData["AlertMessage"] = $"לסטודנט השותף קיים פרויקט";
                                    return RedirectToAction("Index");
                                }

                            }
                            else
                            {
                                TempData["AlertMessage"] = $"סטודנט השותף לא קיים במערכת";
                                return RedirectToAction("Index");
                            }
                        }
                        _studentService.isProject(collection.studentId, true);
                        _projectService.Create(collection);
                        TempData["AlertMessage"] = $"הוספת פרויקט בוצעה בהצלחה";
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    TempData["AlertMessage"] = $"סטודנט הראשי לא קיים במערכת";
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return StatusCode(500, new Result<Project>(e.Message));
            }
        }

        [ActionName("Edit")]
        [Authorize(Roles = "Admin,HeadOfDeprament")]
        public ActionResult Edit(string id)
        {
            if (id == null)
                return BadRequest();

            Project project = _projectService.Get(id);

            if (project == null)
                return NotFound();

            return View(project);
        }

        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Project collection)
        {
            try
            {
                Console.WriteLine(collection.assistantStudentId);
                if (collection.assistantStudentId != null && collection.assistantStudentName != null)
                {
                    if (_studentService.isValidStudent(collection.assistantStudentId, collection.assistantStudentName))
                    {
                        if (_studentService.isValidProject(collection.assistantStudentId))
                        {
                            _studentService.isProject(collection.assistantStudentId, collection.isPass);
                        }
                        else
                        {
                            TempData["AlertMessage"] = $"לסטודנט השותף קיים פרויקט";
                            return RedirectToAction("Index");
                        }
                    }
                    else
                    {
                        TempData["AlertMessage"] = $"סטודנט השותף לא קיים במערכת";
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    _studentService.isProject(collection.assistantStudentId, false);
                }
                _studentService.isProject(collection.studentId, collection.isPass);
                _projectService.Update(collection.Id, collection);
                TempData["AlertMessage"] = $"עריכת הניתונים בוצעה בהצלחה";

                return RedirectToAction("Index");
            }
            catch
            {
                return View(collection);
            }
        }

        [ActionName("EditGuide")]
        [Authorize(Roles = "Admin,HeadOfDeprament")]
        public ActionResult EditGuide(string id)
        {
            if (id == null)
                return BadRequest();

            Project project = _projectService.Get(id);

            if (project == null)
                return NotFound();

            return View(project);
        }

        [HttpPost]
        [ActionName("EditGuide")]
        [ValidateAntiForgeryToken]
        public ActionResult EditGuide(Project collection)
        {
            try
            {
                if (collection.guideId != null && collection.guideName!= null)
                {
                    if (_guideService.isValidGuide(collection.guideId, collection.guideName))
                    {
                        _projectService.UpdateGuide(collection.Id, collection);
                        TempData["AlertMessage"] = $"עריכת הניתונים בוצעה בהצלחה";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["AlertMessage"] = $"המנחה לא קיים במערכת";
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    _projectService.UpdateGuide(collection.Id, collection);
                    TempData["AlertMessage"] = $"המנחה נמחק בהצלחה";
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View(collection);
            }
        }

        [ActionName("Delete")]
        [Authorize(Roles = "Admin,HeadOfDeprament")]
        public ActionResult Delete(string id)
        {
            if (id == null)
                return BadRequest();

            Project student = _projectService.Get(id);

            if (student == null)
                return NotFound();

            return View(student);
        }

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
