namespace EMS.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using EMS.Web.ViewModels.Employees;

    public interface IEmployeesService
    {
        Task CreateAsync(CreateEmployeeInputModel input, string userId);

        IEnumerable<T> GetAll<T>();
    }
}
