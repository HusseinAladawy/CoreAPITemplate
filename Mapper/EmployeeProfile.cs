using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DTOs;
using WebApplication1.Model;

namespace WebApplication1.Mapper
{
    public class EmployeeProfile:Profile
    {
        public EmployeeProfile()
        {
            CreateMap<DepartmentDTO, Department>();
            CreateMap<EmployeeDTO, Employee>();
            CreateMap<Employee, EmployeeDTO>();
            CreateMap<Department, DepartmentDTO>();
        }
    }
}
