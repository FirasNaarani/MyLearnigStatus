using LearnSchoolApp.Entities;
using LearnSchoolApp.Models;
using LearnSchoolApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LearnSchoolApp.Controllers
{
    public class HeadOfDepramentController : Controller
    {
        private readonly IHeadOfDepramentService _headOfDeprament;

        public HeadOfDepramentController(HeadOfDepramentService headOfDeprament)
        {
            _headOfDeprament = headOfDeprament;
        }

        [ActionName("Index")]
        [Authorize(Roles = "Admin,HeadOfDeprament")]
        public ActionResult Index()
        {
            var ls = _headOfDeprament.Get();
            if (ls == null)
            {
                return NotFound();
            }
            List<HeadOfDeprament> res = ls.ToList();
            return View(res);
        }

        [ActionName("MyInfo")]
        [Authorize(Roles = "HeadOfDeprament")]
        public ActionResult MyInfo()
        {
            var HeadOfDepramentID = GetHeadOfDepramentID();
            var currentHeadOfDeprament = _headOfDeprament.Get(HeadOfDepramentID);
            if (currentHeadOfDeprament != null)
            {
                return View(currentHeadOfDeprament);
            }
            return RedirectToAction("MyInfo");
        }

        [ActionName("MyIndex")]
        [Authorize(Roles = "HeadOfDeprament")]
        public ActionResult MyIndex()
        {
            var HeadOfDepramentID = GetHeadOfDepramentID();
            var currentHeadOfDeprament = _headOfDeprament.Get(HeadOfDepramentID);
            if (currentHeadOfDeprament != null)
            {
                return View(currentHeadOfDeprament);
            }
            return RedirectToAction("MyIndex");
        }

        private string GetHeadOfDepramentID()
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
            if (_headOfDeprament.Get(id) == null)
                return NotFound();
            return View(_headOfDeprament.Get(id));
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
        public ActionResult Create(HeadOfDeprament collection)
        {
            try
            {
                _headOfDeprament.Create(collection);
                TempData["AlertMessage"] = $"הוספת מנחה בוצעה בהצלחה";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return StatusCode(500, new Result<HeadOfDeprament>(e.Message));
            }
        }

        [ActionName("Edit")]
        [Authorize(Roles = "Admin,HeadOfDeprament")]
        public ActionResult Edit(string id)
        {
            if (id == null)
                return BadRequest();

            HeadOfDeprament HeadOfDeprament = _headOfDeprament.Get(id);

            if (HeadOfDeprament == null)
                return NotFound();

            return View(HeadOfDeprament);
        }

        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HeadOfDeprament collection)
        {
            try
            {
                _headOfDeprament.Update(collection.Id, collection);
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

            HeadOfDeprament HeadOfDeprament = _headOfDeprament.Get(id);

            if (HeadOfDeprament == null)
                return NotFound();

            return View(HeadOfDeprament);
        }

        [HttpPost]
        [ActionName("EditPassword")]
        [ValidateAntiForgeryToken]
        public ActionResult EditEditPassword(string id, HeadOfDeprament collection)
        {
            try
            {
                _headOfDeprament.UpdatePassword(id, collection);
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

            HeadOfDeprament student = _headOfDeprament.Get(id);

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
                _headOfDeprament.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return StatusCode(500, new Result<HeadOfDeprament>(e.Message));
            }
        }
    }
}
