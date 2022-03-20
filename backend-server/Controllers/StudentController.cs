using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using backend.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;
using backend.Entities;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StudentController : ControllerBase
    {
        private readonly StudentService _studentService;

        public StudentController(StudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpGet]
        public ActionResult<List<Student>> Get() =>
            _studentService.Get();

        [HttpGet("{id:length(24)}", Name = "GetStudent")]
        public ActionResult<Result<Student>> Get(string id)
        {
            var student = _studentService.Get(id);
            if (student == null)
            {
                return NotFound();
            }
            return new Result<Student>(student);
        }

        [HttpPost]
        public ActionResult<Result<Manager>> Create(Student student)
        {
            try
            {
                _studentService.Create(student);
                return CreatedAtRoute("GetManager", new { id = student.Id.ToString() }, student);
            }
            catch (Exception e)
            {
                return StatusCode(500, new Result<Manager>(e.Message));
            }
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, UpdateUser managerIn)
        {
            var book = _studentService.Get(id);

            if (book == null)
            {
                return NotFound();
            }
            _studentService.Update(id, managerIn);
            return NoContent();
        }
        [HttpPut("password/{id:length(24)}")]
        public IActionResult UpdatePassword(string id, UpdatePassword managerIn)
        {
            var book = _studentService.Get(id);

            if (book == null)
            {
                return NotFound();
            }
            _studentService.UpdatePassword(id, managerIn);
            return NoContent();
        }
        [HttpDelete("{id:length(24)}")]
        [Authorize]
        public IActionResult Delete(string id)
        {
            var command = _studentService.Get(id);

            if (command == null)
            {
                return NotFound();
            }
            _studentService.Delete(id);
            return NoContent();
        }
    }
}
