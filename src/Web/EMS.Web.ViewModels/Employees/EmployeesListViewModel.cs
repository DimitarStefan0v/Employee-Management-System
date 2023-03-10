namespace EMS.Web.ViewModels.Employees
{
    using System.Collections.Generic;

    public class EmployeesListViewModel : PagingViewModel
    {
        public IEnumerable<EmployeeInListViewModel> Employees { get; set; }
    }
}
