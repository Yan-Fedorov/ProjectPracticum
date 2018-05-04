using Microsoft.AspNetCore.Mvc;
using Project.Domain.Services.CourseField;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class CourseController: Controller
    {
        private readonly CourseService _courseService;
        public CourseController(CourseService courseService)
        {
            _courseService = courseService;
        }
        [HttpGet]
        public object Get()
        {
            return _courseService.GetItemsList();
        }
        [HttpGet("{id}")]
        public object GetById(Guid id)
        {
            return _courseService.GetElementById(id);
        }
        [HttpPost("{id}")]
        public IActionResult Update(Guid id, [FromBody]CourseInfo item)
        {
            if (ModelState.IsValid)
            {
                _courseService.Update(id, item);
                return Ok(item);
            }
            return BadRequest(ModelState);
        }
        [HttpPost]
        public IActionResult Add([FromBody]CourseInfo item)
        {
            if (ModelState.IsValid)
            {
                var dbCompany = _courseService.Add(item);
                return Ok(dbCompany);
            }
            return BadRequest(ModelState);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {

            if (ModelState.IsValid)
            {
                _courseService.Delete(id);
                return Ok();
            }
            return BadRequest(ModelState);
        }
    }
}
