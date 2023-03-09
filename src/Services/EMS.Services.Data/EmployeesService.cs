namespace EMS.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using EMS.Data.Common.Repositories;
    using EMS.Data.Models;
    using EMS.Web.ViewModels.Employees;

    public class EmployeesService : IEmployeesService
    {
        private readonly IDeletableEntityRepository<Employee> employeesRepository;

        public EmployeesService(IDeletableEntityRepository<Employee> employeesRepository)
        {
            this.employeesRepository = employeesRepository;
        }

        public async Task CreateAsync(CreateEmployeeInputModel input, string userId)
        {
            var employee = new Employee
            {
                FirstName = input.FirstName,
                LastName = input.LastName,
                Email = input.Email,
                PhoneNumber = input.PhoneNumber,
                DateOfBirth = input.DateOfBirth,
                MonthlySalary = input.MonthlySalary,
                AddedByUserId = userId == null ? "Guest User" : userId,
            };

            await this.employeesRepository.AddAsync(employee);
            await this.employeesRepository.SaveChangesAsync();
        }
    }
}
