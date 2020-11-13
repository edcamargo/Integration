using Integration.Domain.Core.Interfaces.Services;
using Integration.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Application.Ui.Api.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(IEmployeeService employeeService, ILogger<EmployeeController> logger)
        {
            _employeeService = employeeService;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var _employee = _employeeService.GetAll();
            return new OkObjectResult(_employee);
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(Guid id)
        {
            var _employee = _employeeService.GetById(id);
            return new OkObjectResult(_employee);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Employee employee)
        {
            employee.ConfirmationIntegration();
            var returnEmp = _employeeService.Add(employee);

            return new OkObjectResult(returnEmp);
        }

        [HttpPost("UpdateSalary")]
        public IActionResult UpdateSalary([FromBody] Guid id)
        {
            var returnEmp = _employeeService.UpdateSalary(id);
            return new OkObjectResult(returnEmp);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Employee employee) 
            => Ok();

        [HttpDelete]
        public IActionResult Delete([FromUri] Guid id)
        {
            var _employee = _employeeService.GetById(id);
            _employeeService.Remove(_employee);

            return Ok();
        }
    }
}
