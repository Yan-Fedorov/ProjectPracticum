using Microsoft.AspNetCore.Mvc;
using Project.Domain.Services.UserNotificationField;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class UserNotificationController: Controller
    {
        private readonly UserNotificationService _userNotificationService;
        public UserNotificationController(UserNotificationService userNotificationService)
        {
            _userNotificationService = userNotificationService;
        }
        [HttpGet]
        public object Get()
        {
            return _userNotificationService.GetItemsList();
        }
        [HttpGet("{id}")]
        public object GetById(Guid id)
        {
            return _userNotificationService.GetElementById(id);
        }
        [HttpPost("{id}")]
        public IActionResult Update(Guid id, [FromBody]UserNotificationInfo item)
        {
            if (ModelState.IsValid)
            {
                _userNotificationService.Update(id, item);
                return Ok(item);
            }
            return BadRequest(ModelState);
        }
        [HttpPost]
        public IActionResult Add([FromBody]UserNotificationInfo item)
        {
            if (ModelState.IsValid)
            {
                var dbCompany = _userNotificationService.Add(item);
                return Ok(dbCompany);
            }
            return BadRequest(ModelState);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {

            if (ModelState.IsValid)
            {
                _userNotificationService.Delete(id);
                return Ok();
            }
            return BadRequest(ModelState);
        }
    }
}
