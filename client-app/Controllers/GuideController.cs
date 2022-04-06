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
    public class GuideController : Controller
    {
        private readonly IGuideService _guideService;

        public GuideController(GuideService guideService)
        {
            _guideService = guideService;
        }

        // GET: CStudentController
        [ActionName("Index")]
        //[Authorize(Roles = "HeadOfDeprament")]
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

        // GET: CStudentController/Details/5
        [ActionName("Details")]
        //[Authorize(Roles = "HeadOfDeprament")]
        public ActionResult Details(string id)
        {
            if (_guideService.Get(id) == null)
                return NotFound();
            return View(_guideService.Get(id));
        }

        // GET: CStudentController/Create
        [ActionName("Create")]
        //[Authorize(Roles = "HeadOfDeprament")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: CStudentController/Create
        [HttpPost]
        [ActionName("Create")]
        //[Authorize(Roles = "HeadOfDeprament")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Guide collection)
        {
            try
            {
                //if (ModelState.IsValid)
                {
                    _guideService.Create(collection);

                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return StatusCode(500, new Result<Guide>(e.Message));
            }
        }

        // GET: CStudentController/Edit/5
        [ActionName("Edit")]
        //[Authorize(Roles = "HeadOfDeprament")]
        public ActionResult Edit(string id)
        {
            if (id == null)
                return BadRequest();

            Guide guide = _guideService.Get(id);

            if (guide == null)
                return NotFound();

            return View(guide);
        }

        // POST: CStudentController/Edit/5
        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guide collection)
        {
            try
            {
                //if (ModelState.IsValid)
                {
                    _guideService.Update(collection.Id, collection);
                    Console.WriteLine("Updated");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(collection);
            }
        }

        [ActionName("EditPassword")]
        //[Authorize(Roles = "Admin")]
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
                //if (ModelState.IsValid)
                {
                    _guideService.UpdatePassword(id, collection);
                    Console.WriteLine("Updated");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(collection);
            }
        }

        // GET: CStudentController/Delete/5
        [ActionName("Delete")]
        //[Authorize(Roles = "HeadOfDeprament")]
        public ActionResult Delete(string id)
        {
            if (id == null)
                return BadRequest();

            Guide student = _guideService.Get(id);

            if (student == null)
                return NotFound();

            return View(student);
        }

        // POST: CStudentController/Delete/5
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
