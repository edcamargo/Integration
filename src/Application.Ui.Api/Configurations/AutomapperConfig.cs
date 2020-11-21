using Application.Ui.Api.Dtos;
using AutoMapper;
using Integration.Domain.Entities;

namespace Application.Ui.Api.Configurations
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
        }
    }
}