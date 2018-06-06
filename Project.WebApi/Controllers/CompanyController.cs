using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Domain.Services.CompanyField;
using Project.Domain;

namespace Project.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class CompanyController : Controller
    {
        private readonly CompanyService _companyService;
        public CompanyController(CompanyService companyService)
        {
            _companyService = companyService;
        }
        [HttpGet]
        public object Get()
        {
            return _companyService.GetItemsList();
        }
        [HttpGet("{id}")]
        public object GetById(Guid id)
        {
            return _companyService.GetElementById(id);
        }
        [HttpPost("{id}")]
        public IActionResult Update(Guid id, [FromBody]CompanyInfo company)
        {
            if (ModelState.IsValid)
            {
                _companyService.Update(id ,company);
                return Ok(company);
            }
            return BadRequest(ModelState);
        }
        [HttpPost]
        public IActionResult Add([FromBody]CompanyInfo company)
        {
            if (ModelState.IsValid)
            {
                var dbCompany = _companyService.Add(company);
                return Ok(dbCompany);
            }
            return BadRequest(ModelState);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            
            if (ModelState.IsValid)
            {
                _companyService.Delete(id);
                return Ok();
            }
            return BadRequest(ModelState);
        }
    }
}
//[Route("api/[controller]")]
//public class CompanyController : Controller
//{
//    private readonly CompanyService _companyService;
//    public CompanyController(CompanyService companyService)
//    {
//        _companyService = companyService;
//    }
//    [HttpGet]
//    public object Get()
//    {
//        return _companyService.GetCompaniesList();
//    }
//    [HttpGet("{id}")]
//    public object GetById(Guid id)
//    {
//        return _companyService.GetElementById(id);
//    }
//    [HttpPost("{id}")]
//    public IActionResult Update(Guid id, [FromBody]Company company)
//    {
//        if (ModelState.IsValid)
//        {
//            _companyService.Update(id, company);
//            return Ok(company);
//        }
//        return BadRequest(ModelState);
//    }
//    [HttpPost]
//    public IActionResult Add([FromBody]CompanyInfo company)
//    {
//        if (ModelState.IsValid)
//        {
//            var dbCompany = _companyService.Add(company);
//            return Ok(dbCompany);
//        }
//        return BadRequest(ModelState);
//    }
//    [HttpDelete("{id}")]
//    public IActionResult Delete(Guid id)
//    {

//        if (ModelState.IsValid)
//        {
//            _companyService.Delete(id);
//            return Ok();
//        }
//        return BadRequest(ModelState);
//    }


//}
