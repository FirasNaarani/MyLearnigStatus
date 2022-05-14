using LearnSchoolApp.Entities;
using LearnSchoolApp.Models;
using LearnSchoolApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LearnSchoolApp.Controllers
{
    public class ManagerController : Controller
    {
        private readonly IManagerService _managerService;

        public ManagerController(ManagerService managerService)
        {
            _managerService = managerService;
        }

        [ActionName("Index")]
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var ls = _managerService.Get();
            if (ls == null)
            {
                return NotFound();
            }
            List<Manager> res = ls.ToList();
            return View(res);
        }

        [ActionName("MyIndex")]
        [Authorize(Roles = "Admin")]
        public ActionResult MyIndex()
        {
            var AdminID = GetAdminID();
            var currentAdmin = _managerService.Get(AdminID);
            if (currentAdmin != null)
            {
                return View(currentAdmin);
            }
            return RedirectToAction("MyIndex");
        }

        private string GetAdminID()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var userClaims = identity.Claims;

                return userClaims.FirstOrDefault(o => o.Type == ClaimTypes.SerialNumber)?.Value;
            }
            return null;
        }

        [ActionName("MyInfo")]
        [Authorize(Roles = "Admin")]
        public ActionResult MyInfo()
        {
            var AdminID = GetAdminID();
            var currentAdmin = _managerService.Get(AdminID);
            if (currentAdmin != null)
            {
                return View(currentAdmin);
            }
            return RedirectToAction("MyInfo");
        }

        [ActionName("Details")]
        [Authorize(Roles = "Admin")]
        public ActionResult Details(string id)
        {
            if (_managerService.Get(id) == null)
                return NotFound();
            return View(_managerService.Get(id));
        }

        [ActionName("Create")]
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Manager collection)
        {
            try
            {
                _managerService.Create(collection);
                TempData["AlertMessage"] = $"הוספת מנהל בוצעה בהצלחה";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return StatusCode(500, new Result<Manager>(e.Message));
            }
        }

        [ActionName("Edit")]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(string id)
        {
            if (id == null)
                return BadRequest();

            Manager student = _managerService.Get(id);

            if (student == null)
                return NotFound();

            return View(student);
        }

        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Manager collection)
        {
            try
            {
                _managerService.Update(collection.Id, collection);
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

            Manager guide = _managerService.Get(id);

            if (guide == null)
                return NotFound();

            return View(guide);
        }

        [HttpPost]
        [ActionName("EditPassword")]
        [ValidateAntiForgeryToken]
        public ActionResult EditEditPassword(string id, Manager collection)
        {
            try
            {
                _managerService.UpdatePassword(id, collection);
                TempData["AlertMessage"] = $"עריכת הניתונים בוצעה בהצלחה";
                return RedirectToAction("Index");
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

            Manager student = _managerService.Get(id);

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
                _managerService.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return StatusCode(500, new Result<Manager>(e.Message));
            }
        }

    }
}
