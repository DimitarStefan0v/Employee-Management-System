namespace EMS.Web.ViewModels.Employees
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using EMS.Data.Models;
    using EMS.Services.Mapping;
    using EMS.Web.ViewModels.Assignments;

    public class SingleEmployeeViewModel : BaseEmployeeViewModel, IMapFrom<Employee>
    {
        [Display(Name = "Assignment")]
        public int AssignmentId { get; set; }

        public ICollection<AssignmentsViewModel> Assignments { get; set; }

        public ICollection<AssignmentsViewModel> PendingAssignments { get; set; }

        public ICollection<AssignmentsViewModel> FinishedAssignments { get; set; }
    }
}
