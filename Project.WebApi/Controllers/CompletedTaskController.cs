using Microsoft.AspNetCore.Mvc;
using Project.Domain.Services.CompletedTaskField;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class CompletedTaskController: Controller
    {
        private readonly CompletedTaskService _companyNotificationService;
        public CompletedTaskController(CompletedTaskService companyNotificationService)
        {
            _companyNotificationService = companyNotificationService;
        }
        [HttpGet]
        public object Get()
        {
            return _companyNotificationService.GetItemsList();
        }
        [HttpGet("{id}")]
        public object GetById(Guid id)
        {
            return _companyNotificationService.GetElementById(id);
        }
        [HttpPost("{id}")]
        public IActionResult Update(Guid id, [FromBody]CompletedTaskInfo item)
        {
            if (ModelState.IsValid)
            {
                _companyNotificationService.Update(id, item);
                return Ok(item);
            }
            return BadRequest(ModelState);
        }
        [HttpPost]
        public IActionResult Add([FromBody]CompletedTaskInfo item)
        {
            if (ModelState.IsValid)
            {
                var dbCompany = _companyNotificationService.Add(item);
                return Ok(dbCompany);
            }
            return BadRequest(ModelState);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {

            if (ModelState.IsValid)
            {
                _companyNotificationService.Delete(id);
                return Ok();
            }
            return BadRequest(ModelState);
        }
    }
}
