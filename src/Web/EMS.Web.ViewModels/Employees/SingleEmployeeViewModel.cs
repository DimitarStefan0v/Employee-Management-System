namespace EMS.Web.ViewModels.Employees
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using AutoMapper;
    using EMS.Data.Models;
    using EMS.Services.Mapping;
    using EMS.Web.ViewModels.Assignments;

    public class SingleEmployeeViewModel : BaseEmployeeViewModel, IMapFrom<Employee>, IHaveCustomMappings
    {
        [Display(Name = "Assignment")]
        public int AssignmentId { get; set; }

        public ICollection<AssignmentsViewModel> Assignments { get; set; }

        public ICollection<AssignmentsViewModel> PendingAssignments { get; set; }

        public ICollection<AssignmentsViewModel> FinishedAssignments { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<Employee, SingleEmployeeViewModel>()
                .ForMember(x => x.PendingAssignments, opt => opt
                                                        .MapFrom(e => e.Assignments
                                                                    .Where(a => a.Finished == false)
                                                                    .Select(a => new AssignmentsViewModel
                                                                    {
                                                                        Id = a.Id,
                                                                        Title = a.Title,
                                                                        StartDate = a.StartDate,
                                                                        DueDate = a.DueDate,
                                                                        CompletedDate = a.CompletedDate,
                                                                    })))
                .ForMember(x => x.FinishedAssignments, opt => opt
                                                        .MapFrom(e => e.Assignments
                                                                    .Where(a => a.Finished == true)
                                                                    .Select(a => new AssignmentsViewModel
                                                                    {
                                                                        Id = a.Id,
                                                                        Title = a.Title,
                                                                        StartDate = a.StartDate,
                                                                        DueDate = a.DueDate,
                                                                        CompletedDate = a.CompletedDate,
                                                                    })));
        }
    }
}
