namespace EMS.Web.ViewModels.Employees
{
    using EMS.Data.Models;
    using EMS.Services.Mapping;

    public class EditEmployeeInputModel : BaseEmployeeInputModel, IMapFrom<Employee>
    {
    }
}
