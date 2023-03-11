namespace EMS.Web.ViewModels.Assignments
{
    using System;

    using AutoMapper;
    using EMS.Data.Models;
    using EMS.Services.Mapping;

    public class AssignmentInListViewModel : IMapFrom<Assignment>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime DueDate { get; set; }

        public string AssignedEmployee { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<Assignment, AssignmentInListViewModel>()
                .ForMember(x => x.AssignedEmployee, opt => opt
                                                        .MapFrom(a => a.EmployeeId != null ? a.Employee.FirstName + " " + a.Employee.LastName : null));
        }
    }
}
