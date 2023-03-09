namespace EMS.Web.ViewModels.Employees
{
    using System;

    using EMS.Data.Models;
    using EMS.Services.Mapping;

    public class SingleEmployeeViewModel : BaseEmployeeViewModel, IMapFrom<Employee>
    {
    }
}
