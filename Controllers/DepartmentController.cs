using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;
using WebApplication1.Repository;
using WebApplication1.UnitOfWork;
using WebApplication1.DTOs;
using AutoMapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;



        public DepartmentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            uow = unitOfWork;
            this.mapper = mapper;


        }
        // GET: api/<DepartmentController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<DepartmentController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentDTO>> Get(int id)
        {
            
          var entity = await  uow.departmentRepository.GetByID(id);

           var dept = mapper.Map<DepartmentDTO>(entity);
            return Ok(dept);
        }

        // POST api/<DepartmentController>
        [HttpPost]
        public async Task Post(DepartmentDTO department)
        {
            await uow.departmentRepository.Insert(mapper.Map<Department>(department));
            await uow.SaveAsync();
        }

        // PUT api/<DepartmentController>/5
        [HttpPut("{id}")]
        public async Task Put(DepartmentDTO department)
        {
            var dept = mapper.Map<Department>(department);
            await uow.departmentRepository.Update(dept);
            await uow.SaveAsync();
        }

        // DELETE api/<DepartmentController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
          
            await uow.departmentRepository.Delete(id);
            await uow.SaveAsync();

        }
    }
}
