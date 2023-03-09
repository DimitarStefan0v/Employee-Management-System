namespace EMS.Web.ViewModels.Employees
{
    using System;
    using System.Linq;

    using AutoMapper;
    using EMS.Data.Models;
    using EMS.Services.Mapping;

    public class EmployeeInListViewModel : BaseEmployeeViewModel, IMapFrom<Employee>, IHaveCustomMappings
    {
        public int FinishedTasks { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<Employee, EmployeeInListViewModel>()
                .ForMember(x => x.FinishedTasks, opt => opt
                                                        .MapFrom(e => e.Assignments
                                                                        .Where(e => e.Finished)
                                                                        .Count()));
        }
    }
}
