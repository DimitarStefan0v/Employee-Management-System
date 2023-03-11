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
                FirstName = input.FirstName.Trim(),
                LastName = input.LastName.Trim(),
                Email = input.Email.Trim(),
                PhoneNumber = input.PhoneNumber.Trim(),
                DateOfBirth = input.DateOfBirth,
                MonthlySalary = input.MonthlySalary,
                AddedByUserId = userId,
            };

            await this.employeesRepository.AddAsync(employee);
            await this.employeesRepository.SaveChangesAsync();
        }

        /// <summary>
        /// Get All Employees.
        /// </summary>
        public IEnumerable<T> GetAll<T>(string sort, int page, int itemsPerPage)
        {
            var query = this.employeesRepository
                .AllAsNoTracking()
                .AsQueryable();

            SortEmployees(ref sort, ref query);

            return query
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
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

        /// <summary>
        /// Get Employee by Name.
        /// </summary>
        public IEnumerable<T> GetByName<T>(string name, string sort, int page, int itemsPerPage)
        {
            var query = this.employeesRepository
                .AllAsNoTracking()
                .Where(x => x.FirstName.ToLower().Contains(name.ToLower()) || x.LastName.ToLower().Contains(name.ToLower()))
                .AsQueryable();

            if (query.Count() > 1)
            {
                SortEmployees(ref sort, ref query);

                return query
                    .Skip((page - 1) * itemsPerPage)
                    .Take(itemsPerPage)
                    .To<T>()
                    .ToList();
            }

            return query
                .To<T>()
                .ToList();
        }

        /// <summary>
        /// Check If Employee with the same Names exists.
        /// </summary>
        public bool CheckIfEmployeeExist(string firstName, string lastName)
        {
            return this.employeesRepository
                .AllAsNoTracking()
                .Any(x => x.FirstName.ToLower() == firstName.ToLower().Trim() && x.LastName.ToLower() == lastName.ToLower().Trim());
        }

        /// <summary>
        /// Sort Employees.
        /// </summary>
        private static void SortEmployees(ref string sort, ref IQueryable<Employee> query)
        {
            if (sort == null)
            {
                sort = "ascending";
            }

            sort = sort.ToLower().Trim();

            switch (sort)
            {
                case "ascending":
                    query = query
                        .OrderBy(x => x.DateOfBirth)
                        .ThenBy(x => x.FirstName)
                        .ThenBy(x => x.LastName);
                    break;
                case "descending":
                    query = query
                        .OrderByDescending(x => x.DateOfBirth)
                        .ThenBy(x => x.FirstName)
                        .ThenBy(x => x.LastName);
                    break;
                case "pending-tasks":
                    query = query
                        .OrderByDescending(x => x.Assignments.Where(a => a.Finished == false).Count())
                        .ThenBy(x => x.FirstName)
                        .ThenBy(x => x.LastName);
                    break;
                case "finished-tasks":
                    query = query
                        .OrderByDescending(x => x.Assignments.Where(a => a.Finished == true).Count())
                        .ThenBy(x => x.FirstName)
                        .ThenBy(x => x.LastName);
                    break;
                case "salary":
                    query = query
                        .OrderByDescending(x => x.MonthlySalary)
                        .ThenBy(x => x.FirstName)
                        .ThenBy(x => x.LastName);
                    break;
                default:
                    sort = "ascending";
                    query = query
                        .OrderBy(x => x.DateOfBirth)
                        .ThenBy(x => x.FirstName)
                        .ThenBy(x => x.LastName);
                    break;
            }
        }
    }
}
