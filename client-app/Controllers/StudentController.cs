using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LearnSchoolApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnSchoolApp.Models;
using LearnSchoolApp.Entities;

namespace LearnSchoolApp.Controllers
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
        public ActionResult<Result<Student>> Create(Student student)
        {
            try
            {
                _studentService.Create(student);
                return CreatedAtRoute("GetStudent", new { id = student.Id.ToString() }, student);
            }
            catch (Exception e)
            {
                return StatusCode(500, new Result<Student>(e.Message));
            }
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, UpdateUser studentIn)
        {
            var book = _studentService.Get(id);

            if (book == null)
            {
                return NotFound();
            }
            _studentService.Update(id, studentIn);
            return Ok();
        }
        
        [HttpPut("password/{id:length(24)}")]
        public IActionResult UpdatePassword(string id, UpdatePassword studentIn)
        {
            var book = _studentService.Get(id);

            if (book == null)
            {
                return NotFound();
            }
            _studentService.UpdatePassword(id, studentIn);
            return Ok();
        }
       
        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var command = _studentService.Get(id);

            if (command == null)
            {
                return NotFound();
            }
            _studentService.Delete(id);
            return Ok();
        }
    }
}
