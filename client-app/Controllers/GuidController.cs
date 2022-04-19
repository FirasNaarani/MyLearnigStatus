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
    public class GuidController : Controller
    {
        private readonly IGuideService _guideService;
        private readonly IProjectService _projectService;

        public GuidController(GuideService guideService, ProjectService projectService)
        {
            _guideService = guideService;
            _projectService = projectService;
        }

        [ActionName("Index")]
        [Authorize(Roles = "Admin,HeadOfDeprament")]
        public ActionResult Index()
        {
            var ls = _guideService.Get();
            if (ls == null)
            {
                return NotFound();
            }
            List<Guide> res = ls.ToList();
            return View(res);
        }

        [ActionName("MyInfo")]
        [Authorize(Roles = "Guid")]
        public ActionResult MyInfo()
        {
            var GuidID = GetGuideID();
            var currentGuid = _guideService.Get(GuidID);
            if (currentGuid != null)
            {
                return View(currentGuid);
            }
            return RedirectToAction("MyInfo");
        }

        [ActionName("MyIndex")]
        [Authorize(Roles = "Guid")]
        public ActionResult MyIndex()
        {
            var guideID = GetGuideID();
            var currentGuide = _guideService.Get(guideID);
            if (currentGuide != null)
            {
                return View(currentGuide);
            }
            return RedirectToAction("MyIndex");
        }

        private string GetGuideID()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var userClaims = identity.Claims;

                return userClaims.FirstOrDefault(o => o.Type == ClaimTypes.SerialNumber)?.Value;
            }
            return null;
        }

        [ActionName("MyProjects")]
        [Authorize(Roles = "HeadOfDeprament,Guid")]
        public ActionResult MyProjects(string id)
        {
            var ls = _projectService.GetProjects(id);
            if (ls == null)
            {
                return NotFound();
            }
            List<Project> res = ls.ToList();
            return View(res);
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

        [ActionName("CreateStauts")]
        [Authorize(Roles = "Guid")]
        public IActionResult CreateStauts(string id)
        {
            Status status = new Status { projectId = id, userId = GetGuideID() };
            return View(status);
        }

        [HttpPost]
        [ActionName("CreateStauts")]
        [Authorize(Roles = "Guid")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateStauts(Status collection)
        {
            try
            {
                if(collection.currentStatus != null)
                {
                    collection.date = DateTime.UtcNow;
                    collection.userId = GetGuideID();
                    var project = _projectService.GetProject(collection.projectId);
                    _projectService.CreateGuideStauts(project, collection);
                    _projectService.UpdateGuideStatuses(project.Id, project);
                    TempData["AlertMessage"] = $"הוספת הנחיה בוצעה בהצלחה";

                }
                else
                {
                    TempData["AlertMessage"] = $"לא ניתן להוסיף הנחיה ריקה";
                }
                return Redirect("~/Guide/MyProjects/" + GetGuideID());
            }
            catch (Exception e)
            {
                return StatusCode(500, new Result<Guide>(e.Message));
            }
        }

        [ActionName("Details")]
        [Authorize(Roles = "Admin,HeadOfDeprament")]
        public ActionResult Details(string id)
        {
            if (_guideService.Get(id) == null)
                return NotFound();
            return View(_guideService.Get(id));
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
        public ActionResult Create(Guide collection)
        {
            try
            {
                _guideService.Create(collection);
                TempData["AlertMessage"] = $"הוספת מנחה בוצעה בהצלחה";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return StatusCode(500, new Result<Guide>(e.Message));
            }
        }

        [ActionName("Edit")]
        [Authorize(Roles = "Admin,HeadOfDeprament")]
        public ActionResult Edit(string id)
        {
            if (id == null)
                return BadRequest();

            Guide guide = _guideService.Get(id);

            if (guide == null)
                return NotFound();

            return View(guide);
        }

        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guide collection)
        {
            try
            {
                _guideService.Update(collection.Id, collection);
                TempData["AlertMessage"] = $"עריכת הניתונים בוצעה בהצלחה";
                return RedirectToAction("Index");
            }
            catch
            {
                return View(collection);
            }
        }

        [ActionName("EditPassword")]
        [Authorize(Roles = "Admin")]
        public ActionResult EditPassword(string id)
        {
            if (id == null)
                return BadRequest();

            Guide guide = _guideService.Get(id);

            if (guide == null)
                return NotFound();

            return View(guide);
        }

        [HttpPost]
        [ActionName("EditPassword")]
        [ValidateAntiForgeryToken]
        public ActionResult EditEditPassword(string id, Guide collection)
        {
            try
            {
                _guideService.UpdatePassword(id, collection);
                TempData["AlertMessage"] = $"עריכת הניתונים בוצעה בהצלחה";
                return RedirectToAction("Index");
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

            Guide student = _guideService.Get(id);

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
                _guideService.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return StatusCode(500, new Result<Guide>(e.Message));
            }
        }
    }
}
