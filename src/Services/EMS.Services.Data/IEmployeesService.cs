namespace EMS.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using EMS.Web.ViewModels.Employees;

    public interface IEmployeesService
    {
        Task CreateAsync(CreateEmployeeInputModel input, string userId);

        IEnumerable<T> GetAll<T>(string sort, int page, int itemsPerPage);

        T GetById<T>(int id);

        IEnumerable<T> GetByName<T>(string name, string sort, int page, int itemsPerPage);

        Task UpdateAsync(int id, EditEmployeeInputModel input);

        Task DeleteAsync(int id);

        bool CheckIfEmployeeExist(string firstName, string lastName);

        IEnumerable<T> GetBestEmployees<T>(int countEmployees);
    }
}
