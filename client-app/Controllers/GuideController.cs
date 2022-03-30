using LearnSchoolApp.Entities;
using LearnSchoolApp.Models;
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
    public class GuideController : ControllerBase
    {
        private readonly GuideService _guideService;

        public GuideController(GuideService guideService)
        {
            _guideService = guideService;
        }
        [HttpGet]
        public ActionResult<List<Guide>> Get() =>
            _guideService.Get();

        [HttpGet("{id:length(24)}", Name = "GetGuide")]
        public ActionResult<Result<Guide>> Get(string id)
        {
            var Guide = _guideService.Get(id);
            if (Guide == null)
            {
                return NotFound();
            }
            return new Result<Guide>(Guide);
        }

        [HttpPost]
        public ActionResult<Result<Guide>> Create(Guide Guide)
        {
            try
            {
                _guideService.Create(Guide);
                return CreatedAtRoute("GetGuide", new { id = Guide.Id.ToString() }, Guide);
            }
            catch (Exception e)
            {
                return StatusCode(500, new Result<Guide>(e.Message));
            }
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, UpdateUser GuideIn)
        {
            var book = _guideService.Get(id);

            if (book == null)
            {
                return NotFound();
            }
            _guideService.Update(id, GuideIn);
            return Ok();
        }
        
        [HttpPut("password/{id:length(24)}")]
        public IActionResult UpdatePassword(string id, UpdatePassword GuideIn)
        {
            var book = _guideService.Get(id);

            if (book == null)
            {
                return NotFound();
            }
            _guideService.UpdatePassword(id, GuideIn);
            return Ok();
        }
        
        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var command = _guideService.Get(id);

            if (command == null)
            {
                return NotFound();
            }
            _guideService.Delete(id);
            return Ok();
        }
    }
}
