namespace EMS.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using EMS.Data.Common.Repositories;
    using EMS.Data.Models;
    using EMS.Services.Mapping;
    using EMS.Web.ViewModels.Employees;

    public class EmployeesService : IEmployeesService
    {
        private readonly IDeletableEntityRepository<Employee> employeesRepository;

        public EmployeesService(IDeletableEntityRepository<Employee> employeesRepository)
        {
            this.employeesRepository = employeesRepository;
        }

        /// <summary>
        /// Create Employee and Add it to Database.
        /// </summary>
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
                AddedByUserId = userId == null ? null : userId,
            };

            await this.employeesRepository.AddAsync(employee);
            await this.employeesRepository.SaveChangesAsync();
        }

        /// <summary>
        /// Get All Employees.
        /// </summary>
        public IEnumerable<T> GetAll<T>()
        {
            return this.employeesRepository
                .AllAsNoTracking()
                .To<T>()
                .ToList();
        }

        /// <summary>
        /// Get Employee by Id.
        /// </summary>
        public T GetById<T>(int id)
        {
            return this.employeesRepository
                .AllAsNoTracking()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefault();
        }

        /// <summary>
        /// Update Employee.
        /// </summary>
        public async Task UpdateAsync(int id, EditEmployeeInputModel input)
        {
            var employee = this.employeesRepository.All().FirstOrDefault(x => x.Id == id);
            if (employee != null)
            {
                employee.FirstName = input.FirstName;
                employee.LastName = input.LastName;
                employee.PhoneNumber = input.PhoneNumber;
                employee.DateOfBirth = input.DateOfBirth;
                employee.Email = input.Email;
                employee.MonthlySalary = input.MonthlySalary;

                await this.employeesRepository.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Delete Employee(soft delete).
        /// </summary>
        public async Task DeleteAsync(int id)
        {
            var employee = this.employeesRepository.All().FirstOrDefault(x => x.Id == id);
            if (employee != null)
            {
                this.employeesRepository.Delete(employee);
                await this.employeesRepository.SaveChangesAsync();
            }
        }
    }
}
