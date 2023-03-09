namespace EMS.Services.Data
{
    using System.Threading.Tasks;

    using EMS.Web.ViewModels.Employees;

    public interface IEmployeesService
    {
        Task CreateAsync(CreateEmployeeInputModel input);
    }
}
