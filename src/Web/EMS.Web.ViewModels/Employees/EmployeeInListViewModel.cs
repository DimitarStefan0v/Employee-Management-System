namespace EMS.Web.ViewModels.Employees
{
    using System;
    using System.Linq;

    using AutoMapper;
    using EMS.Data.Models;
    using EMS.Services.Mapping;

    public class EmployeeInListViewModel : IMapFrom<Employee>, IHaveCustomMappings
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime DateOfBirth { get; set; }

        public double MonthlySalary { get; set; }

        public string AddedByUserUserName { get; set; }

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
