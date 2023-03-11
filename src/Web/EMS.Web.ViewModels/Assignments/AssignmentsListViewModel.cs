namespace EMS.Web.ViewModels.Assignments
{
    using System.Collections.Generic;

    public class AssignmentsListViewModel : PagingViewModel
    {
        public IEnumerable<AssignmentInListViewModel> Assignments { get; set; }
    }
}
