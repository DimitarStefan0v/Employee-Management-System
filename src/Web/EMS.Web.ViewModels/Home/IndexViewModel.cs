namespace EMS.Web.ViewModels.Home
{
    using System.Collections.Generic;

    using EMS.Web.ViewModels.Employees;

    public class IndexViewModel
    {
        public IEnumerable<EmployeeInListViewModel> BestEmployees { get; set; }
    }
}
