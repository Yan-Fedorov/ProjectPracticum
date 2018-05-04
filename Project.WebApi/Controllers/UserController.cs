using Microsoft.AspNetCore.Mvc;
using Project.Domain.Services.UserField;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class UserController: Controller
    {
        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public object Get()
        {
            return _userService.GetItemsList();
        }
        [HttpGet("{id}")]
        public object GetById(Guid id)
        {
            return _userService.GetElementById(id);
        }
        [HttpPost("{id}")]
        public IActionResult Update(Guid id, [FromBody]UserInfo item)
        {
            if (ModelState.IsValid)
            {
                _userService.Update(id, item);
                return Ok(item);
            }
            return BadRequest(ModelState);
        }
        [HttpPost]
        public IActionResult Add([FromBody]UserInfo item)
        {
            if (ModelState.IsValid)
            {
                var dbCompany = _userService.Add(item);
                return Ok(dbCompany);
            }
            return BadRequest(ModelState);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {

            if (ModelState.IsValid)
            {
                _userService.Delete(id);
                return Ok();
            }
            return BadRequest(ModelState);
        }
    }
}
