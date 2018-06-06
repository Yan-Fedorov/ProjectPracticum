using Microsoft.AspNetCore.Authorization;
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
        [HttpPost]
        public object Add([FromBody]UserInfo item)
        {
            if (ModelState.IsValid)
            {
                var dbCompany = _userService.Add(item);
                return Ok(dbCompany);
            }
            return BadRequest(ModelState);
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
        [Authorize]
        [HttpPost("{id}")]
        public object Update(Guid id, [FromBody]UserInfo item)
        {
            var userId = User.GetUserId();

            if (ModelState.IsValid)
            {
                _userService.Update(id, item);
                return Ok(item);
            }
            return BadRequest(ModelState);
        }
        [Authorize]
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


        public void Test()
        {
            var st = 10;
            var obj = new TeC
            {
                Num = 10,
                St = "23"
            };
            Mod(st, obj);
        }

        public void Mod(int inSt, TeC o)
        {
            inSt = 202;

            o.St = "20";
            o.Num = 2;
        }

        public class TeC
        {
            public int Num { get; set; }
            public string St { get; set; }
        }
    }
}
