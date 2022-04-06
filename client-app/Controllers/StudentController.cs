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
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(StudentService studentService)
        {
            _studentService = studentService;
        }

        // GET: CStudentController
        [ActionName("Index")]
        //[Authorize(Roles = "Admin,HeadOfDeprament")]
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

        // GET: CStudentController/Details/5
        [ActionName("Details")]
        //[Authorize(Roles = "Admin,HeadOfDeprament")]
        public ActionResult Details(string id)
        {
            if (_studentService.Get(id) == null)
                return NotFound();
            return View(_studentService.Get(id));
        }

        // GET: CStudentController/Create
        [ActionName("Create")]
        //[Authorize(Roles = "Admin,HeadOfDeprament")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: CStudentController/Create
        [HttpPost]
        [ActionName("Create")]
        //[Authorize(Roles = "Admin,HeadOfDeprament")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student collection)
        {
            try
            {
                //if (ModelState.IsValid)
                {
                    _studentService.Create(collection);

                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return StatusCode(500, new Result<Student>(e.Message));
            }
        }

        // GET: CStudentController/Edit/5
        [ActionName("Edit")]
        //[Authorize(Roles = "Admin,HeadOfDeprament")]
        public ActionResult Edit(string id)
        {
            if (id == null)
                return BadRequest();

            Student student = _studentService.Get(id);

            if (student == null)
                return NotFound();

            return View(student);
        }

        // POST: CStudentController/Edit/5
        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student collection)
        {
            try
            {
                //if (ModelState.IsValid)
                {
                    _studentService.Update(collection.Id, collection);
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
                //if (ModelState.IsValid)
                {
                    _studentService.UpdatePassword(id, collection);
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
        //[Authorize(Roles = "Admin")]
        public ActionResult Delete(string id)
        {
            if (id == null)
                return BadRequest();

            Student student = _studentService.Get(id);

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
                _studentService.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return StatusCode(500, new Result<Student>(e.Message));
            }
        }
    }
}
