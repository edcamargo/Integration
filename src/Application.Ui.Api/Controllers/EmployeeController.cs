using Application.Ui.Api.Dtos;
using AutoMapper;
using Integration.Domain.Core.Interfaces.Services;
using Integration.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Application.Ui.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeService _employeeService;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(IMapper mapper, IEmployeeService employeeService, ILogger<EmployeeController> logger)
        {
            _mapper = mapper;
            _employeeService = employeeService;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            try
            {
                var _employee = _employeeService.GetAll();
                return new OkObjectResult(_employee);
            }
            catch (ArgumentNullException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(Guid id)
        {
            try
            {
                var _employee = _employeeService.GetById(id);
                return new OkObjectResult(_employee);
            }
            catch (ArgumentNullException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] EmployeeDto employeeDto)
        {
            try
            {
                if (employeeDto == null)
                    return BadRequest();

                var _employee = _mapper.Map<Employee>(employeeDto);
                var _employeeRet = _employeeService.Add(_employee);

                return Created("/", "Created");
            }
            catch (ArgumentNullException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message + " | " + e.InnerException.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] EmployeeDto employeeDto)
        {
            try
            {
                var _employee = _mapper.Map<Employee>(employeeDto);

                _employeeService.Update(_employee);
                return Ok(employeeDto);
            }
            catch (ArgumentNullException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message + " | " + e.InnerException.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete([FromUri] Guid id)
        {
            try
            {
                var _employee = _employeeService.GetById(id);

                if (_employee != null)
                {
                    _employeeService.Remove(_employee);
                }

                return Ok();
            }
            catch (ArgumentNullException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("UpdateSalary")]
        public IActionResult UpdateSalary([FromBody] Guid id)
        {
            try
            {
                var _employee = _employeeService.UpdateSalary(id);
                return new OkObjectResult("Salário alterado");
            }
            catch (ArgumentNullException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message + " | " + e.InnerException.Message);
            }
        }
    }
}