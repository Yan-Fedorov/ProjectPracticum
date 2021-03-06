﻿using Microsoft.AspNetCore.Authorization;
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

        //[HttpGet("forUser")]
        //public object GetUsers()
        //{
        //    return _courseService.GetUserCourses(User.GetUserId());
        //}


        [HttpPost("{id}")]
        [Authorize]
        public IActionResult Update(Guid id, [FromBody]CourseInfo item)
        {
            if (ModelState.IsValid)
            {
                _courseService.Update(id, item);
                return Ok(item);
            }
            return BadRequest(ModelState);
        }
        [Authorize]
        [Route("addToCompany")]
        [HttpPost]
        public IActionResult AddToCompany([FromBody]CourseInfo item)
        {
            var companyId = User.GetUserId();
            if (ModelState.IsValid)
            {
                _courseService.AddToCompany(item, companyId);
                return Ok(item);
            }
            return BadRequest(ModelState);
        }
        [HttpPost]
        [Authorize]
        public IActionResult Add([FromBody]CourseInfo item)
        {
            if (ModelState.IsValid)
            {
                var dbCompany = _courseService.Add(item);
                return Ok(dbCompany);
            }
            return BadRequest(ModelState);
        }
        [Authorize]
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
