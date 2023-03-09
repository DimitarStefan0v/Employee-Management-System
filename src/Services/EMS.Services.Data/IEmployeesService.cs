﻿namespace EMS.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using EMS.Web.ViewModels.Employees;

    public interface IEmployeesService
    {
        Task CreateAsync(CreateEmployeeInputModel input, string userId);

        IEnumerable<T> GetAll<T>();

        T GetById<T>(int id);

        Task UpdateAsync(int id, EditEmployeeInputModel input);

        Task DeleteAsync(int id);
    }
}
