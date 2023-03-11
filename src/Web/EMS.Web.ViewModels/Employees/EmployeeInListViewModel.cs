namespace EMS.Web.ViewModels.Employees
{
    using System.Linq;

    using AutoMapper;
    using EMS.Data.Models;
    using EMS.Services.Mapping;

    public class EmployeeInListViewModel : BaseEmployeeViewModel, IMapFrom<Employee>, IHaveCustomMappings
    {
        public int PendingAssignmentsCount { get; set; }

        public int FinishedAssignmentsCount { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<Employee, EmployeeInListViewModel>()
                .ForMember(x => x.PendingAssignmentsCount, opt => opt
                                                        .MapFrom(e => e.Assignments
                                                                    .Where(a => a.Finished == false)
                                                                    .Count()))
                .ForMember(x => x.FinishedAssignmentsCount, opt => opt
                                                        .MapFrom(e => e.Assignments
                                                                    .Where(a => a.Finished == true)
                                                                    .Count()));
        }
    }
}
