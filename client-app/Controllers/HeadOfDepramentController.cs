using LearnSchoolApp.Entities;
using LearnSchoolApp.Models;
using LearnSchoolApp.Service;
using LearnSchoolApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnSchoolApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HeadOfDepramentController : ControllerBase
    {
        private readonly HeadOfDepramentService _headOfDepramentService;

        public HeadOfDepramentController(HeadOfDepramentService headOfDepramentService)
        {
            _headOfDepramentService = headOfDepramentService;
        }

        [HttpGet]
        public ActionResult<List<HeadOfDeprament>> Get() =>
            _headOfDepramentService.Get();

        [HttpGet("{id:length(24)}", Name = "GetHeadOfDeprament")]
        public ActionResult<Result<HeadOfDeprament>> Get(string id)
        {
            var headOfDeprament = _headOfDepramentService.Get(id);
            if (headOfDeprament == null)
            {
                return NotFound();
            }
            return new Result<HeadOfDeprament>(headOfDeprament);
        }

        [HttpPost]
        public ActionResult<Result<HeadOfDeprament>> Create(HeadOfDeprament headOfDeprament)
        {
            try
            {
                _headOfDepramentService.Create(headOfDeprament);
                return CreatedAtRoute("GetHeadOfDeprament", new { id = headOfDeprament.Id.ToString() }, headOfDeprament);
            }
            catch (Exception e)
            {
                return StatusCode(500, new Result<HeadOfDeprament>(e.Message));
            }
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, UpdateUser headOfDepramentIn)
        {
            var book = _headOfDepramentService.Get(id);

            if (book == null)
            {
                return NotFound();
            }
            _headOfDepramentService.Update(id, headOfDepramentIn);
            return Ok();
        }

        [HttpPut("password/{id:length(24)}")]
        public IActionResult UpdatePassword(string id, UpdatePassword headOfDepramentIn)
        {
            var book = _headOfDepramentService.Get(id);

            if (book == null)
            {
                return NotFound();
            }
            _headOfDepramentService.UpdatePassword(id, headOfDepramentIn);
            return Ok();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var command = _headOfDepramentService.Get(id);

            if (command == null)
            {
                return NotFound();
            }
            _headOfDepramentService.Delete(id);
            return Ok();
        }
    }
}
