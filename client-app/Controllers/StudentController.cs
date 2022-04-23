using LearnSchoolApp.Entities;
using LearnSchoolApp.Models;
using LearnSchoolApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LearnSchoolApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IProjectService _projectService;
        private readonly IGuideService _guideService;

        public StudentController(StudentService studentService, ProjectService projectService, GuideService guideService)
        {
            _studentService = studentService;
            _projectService = projectService;
            _guideService = guideService;
        }

        [ActionName("Index")]
        [Authorize(Roles = "Admin,HeadOfDeprament")]
        public ActionResult Index()
        {
            var ls = _studentService.Get();
            if (ls == null)
            {
                return NotFound();
            }
            List<Student> res = ls.ToList();
            return View(res);
        }

        [ActionName("MyInfo")]
        [Authorize(Roles = "Student")]
        public ActionResult MyInfo()
        {
            var StudentID = GetStudentID();
            var currentStudent = _studentService.Get(StudentID);
            if (currentStudent != null)
            {
                return View(currentStudent);
            }
            return RedirectToAction("MyInfo");
        }

        [ActionName("MyIndex")]
        [Authorize(Roles = "Student")]
        public ActionResult MyIndex()
        {
            var studentID = GetStudentID();
            var currentStudent = _studentService.Get(studentID);
            if (currentStudent != null)
            {
                return View(currentStudent);
            }
            return RedirectToAction("MyIndex");
        }

        private string GetStudentID()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var userClaims = identity.Claims;

                return userClaims.FirstOrDefault(o => o.Type == ClaimTypes.SerialNumber)?.Value;
            }
            return null;
        }

        [ActionName("Details")]
        [Authorize(Roles = "Admin,HeadOfDeprament")]
        public ActionResult Details(string id)
        {
            if (_studentService.Get(id) == null)
                return NotFound();
            return View(_studentService.Get(id));
        }

        [ActionName("GetProject")]
        [Authorize]
        public ActionResult GetProject(string id)
        {
            if (_projectService.GetMyProject(id) == null)
            {
                return RedirectToAction("Index");
            }
            return View(_projectService.GetMyProject(id));
        }

        [ActionName("GetGuide")]
        [Authorize]
        public ActionResult GetGuide(string id)
        {
            if (_guideService.GetMyGuide(id) == null)
                return NotFound();
            return View(_guideService.GetMyGuide(id));
        }

        [ActionName("CheckHeadNotes")]
        [Authorize]
        public ActionResult CheckHeadNotes(string id)
        {
            var student = _studentService.Get(id);
            Console.WriteLine($"STUDENT {JsonConvert.SerializeObject(student)}");
            var project = _projectService.GetMyProject(student.userId);
            Console.WriteLine($"PROJECT {JsonConvert.SerializeObject(project)}");
            var ls = _projectService.GetHeadStatuses(project.Id);
            Console.WriteLine($"STATUSES {JsonConvert.SerializeObject(ls)}");
            int conut = 0;
            foreach (var item in ls)
            {
                if (!item.isPass)
                    conut++;
            }
            if (conut > 0)
                TempData["HeadNotes"] = $"יש {conut} הודעות חדשות, תעבור להנחיות ראש המגמה";
            else
                TempData["HeadNotes"] = $"אין הודעות חדשות מראש המגמה";
            return RedirectToAction("MyIndex");
        }

        [ActionName("CheckGuidNotes")]
        [Authorize]
        public ActionResult CheckGuidNotes(string id)
        {
            var student = _studentService.Get(id);
            Console.WriteLine($"STUDENT {JsonConvert.SerializeObject(student)}");
            var project = _projectService.GetMyProject(student.userId);
            Console.WriteLine($"PROJECT {JsonConvert.SerializeObject(project)}");
            var ls = _projectService.GetGuidStatuses(project.Id);
            Console.WriteLine($"STATUSES {JsonConvert.SerializeObject(ls)}");
            int conut = 0;
            foreach (var item in ls)
            {
                if (!item.isPass)
                    conut++;
            }
            if (conut > 0)
                TempData["GuidNotes"] = $"יש {conut} הודעות חדשות, תעבור להנחיות המנחה";
            else
                TempData["GuidNotes"] = $"אין הודעות חדשות מהמנחה";
            return RedirectToAction("MyIndex");
        }

        [ActionName("ProjectStatus")]
        [Authorize]
        public ActionResult ProjectStatus(string id)
        {
            var ls = _projectService.GetGuidStatuses(id);
            if (ls == null)
            {
                return NotFound();
            }
            return View(ls);
        }

        [ActionName("ReturnToProjectProfile")]
        [Authorize]
        public ActionResult ReturnToProjectProfile()
        {
            var id = GetStudentID();
            if (id == null)
            {
                return NotFound();
            }
            return RedirectToAction("GetProject", new { id = id });
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
        public ActionResult Create(Student collection)
        {
            try
            {
                _studentService.Create(collection);
                TempData["AlertMessage"] = $"הוספת סטודנט בוצעה בהצלחה";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return StatusCode(500, new Result<Student>(e.Message));
            }
        }

        [ActionName("Edit")]
        [Authorize(Roles = "Admin,HeadOfDeprament")]
        public ActionResult Edit(string id)
        {
            if (id == null)
                return BadRequest();

            Student student = _studentService.Get(id);

            if (student == null)
                return NotFound();

            return View(student);
        }

        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student collection)
        {
            try
            {
                _studentService.Update(collection.Id, collection);
                TempData["AlertMessage"] = $"עריכת הניתונים בוצעה בהצלחה";
                return RedirectToAction("Index");
            }
            catch
            {
                return View(collection);
            }
        }

        [ActionName("EditPassword")]
        [Authorize(Roles = "Admin,HeadOfDeprament")]
        public ActionResult EditPassword(string id)
        {
            if (id == null)
                return BadRequest();

            Student guide = _studentService.Get(id);

            if (guide == null)
                return NotFound();

            return View(guide);
        }

        [HttpPost]
        [ActionName("EditPassword")]
        [ValidateAntiForgeryToken]
        public ActionResult EditEditPassword(string id, Student collection)
        {
            try
            {
                _studentService.UpdatePassword(id, collection);
                TempData["AlertMessage"] = $"עריכת הניתונים בוצעה בהצלחה";
                return RedirectToAction("Index");
            }
            catch
            {
                return View(collection);
            }
        }

        [ActionName("EditProject")]
        [Authorize(Roles = "Student")]
        public ActionResult EditProject(int statusId, string projectId)
        {
            if (projectId == null)
                return BadRequest();

            Project project = _projectService.GetProject(projectId);

            if (project == null)
                return NotFound();
            Status status = _projectService.EditGuidStatus(projectId, statusId);
            return View(status);
        }

        [HttpPost]
        [ActionName("EditProject")]
        [ValidateAntiForgeryToken]
        public ActionResult EditProject(Status collection)
        {
            try
            {
                _projectService.UpdateGuideStatusPass(collection.projectId, collection);
                TempData["AlertMessage"] = $"עריכת הניתונים בוצעה בהצלחה";
                return RedirectToAction("ProjectStatus", new { id = collection.projectId });
            }
            catch
            {
                return View(collection);
            }
        }

        [ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(string id)
        {
            if (id == null)
                return BadRequest();

            Student student = _studentService.Get(id);

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
                _studentService.Delete(id);
                TempData["AlertMessage"] = $"עריכת הניתונים בוצעה בהצלחה";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return StatusCode(500, new Result<Student>(e.Message));
            }
        }
    }
}
