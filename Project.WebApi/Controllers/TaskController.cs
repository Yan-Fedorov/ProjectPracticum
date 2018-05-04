using Microsoft.AspNetCore.Mvc;
using Project.Domain.Services.TaskField;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class TaskController: Controller
    {
        private readonly TaskService _taskService;
        public TaskController(TaskService taskService)
        {
            _taskService = taskService;
        }
        [HttpGet]
        public object Get()
        {
            return _taskService.GetItemsList();
        }
        [HttpGet("{id}")]
        public object GetById(Guid id)
        {
            return _taskService.GetElementById(id);
        }
        [HttpPost("{id}")]
        public IActionResult Update(Guid id, [FromBody]TaskInfo item)
        {
            if (ModelState.IsValid)
            {
                _taskService.Update(id, item);
                return Ok(item);
            }
            return BadRequest(ModelState);
        }
        [HttpPost]
        public IActionResult Add([FromBody]TaskInfo item)
        {
            if (ModelState.IsValid)
            {
                var dbCompany = _taskService.Add(item);
                return Ok(dbCompany);
            }
            return BadRequest(ModelState);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {

            if (ModelState.IsValid)
            {
                _taskService.Delete(id);
                return Ok();
            }
            return BadRequest(ModelState);
        }
    }
}
