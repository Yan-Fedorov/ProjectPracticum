using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Domain.Services.UserAndCoursesField;
using Microsoft.AspNetCore.Authorization;

namespace Project.WebApi.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    public class UserCoursesController: Controller
    {
        private readonly UserAndCoursesService _service;
        public UserCoursesController(UserAndCoursesService service)
        {
            _service = service;
        }
        [HttpPost("{couseId}")]
        public object Add(Guid couseId)
        {
            //if (ModelState.IsValid)
            //{
                var dbCompany = _service.AddCourseToUser(couseId, User.GetUserId());
                return Ok(dbCompany.Id);
            //}
            return BadRequest(ModelState);
        }

        [HttpGet]
        public object Get()
        {
            return _service.GetUserCourses(User.GetUserId());
        }
    }


}
