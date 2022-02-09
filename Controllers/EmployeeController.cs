using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DTOs;
using WebApplication1.Model;
using WebApplication1.UnitOfWork;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private static ILogger<EmployeeController> logger;
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public EmployeeController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<EmployeeController> _logger)
        {
            uow = unitOfWork;
            this.mapper = mapper;
            logger = _logger;
        }
        // GET: api/<EmployeeController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDTO>> Get(int id)
        {
            var entity =await uow.employeeRepository.GetByID(id);
            
             
            var employee = mapper.Map<EmployeeDTO>(entity);
            employee.DepartmentName = entity.Department.DepartmentName;

            return Ok(employee);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<ActionResult> Post(EmployeeDTO entity)
        {
            var employee = mapper.Map<Employee>(entity);
            await uow.employeeRepository.Insert(employee);
            await uow.SaveAsync();
            return Ok();
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(EmployeeDTO entity)
        {
            var employee = mapper.Map<Employee>(entity);
            await uow.employeeRepository.Update(employee);
            return Ok();
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await uow.employeeRepository.Delete(id);
                await uow.SaveAsync();
                return Ok();
            }
            catch (Exception ex)
            {

                logger.LogInformation(ex.Message);
                return NoContent();
            }
         
        }
    }
}
