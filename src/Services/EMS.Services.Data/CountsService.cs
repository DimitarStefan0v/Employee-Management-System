namespace EMS.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using EMS.Data.Common.Repositories;
    using EMS.Data.Models;

    public class CountsService : ICountsService
    {
        private readonly IDeletableEntityRepository<Employee> employeesRepository;
        private readonly IDeletableEntityRepository<Assignment> assignmentsRepository;

        public CountsService(
            IDeletableEntityRepository<Employee> employeesRepository,
            IDeletableEntityRepository<Assignment> assignmentsRepository)
        {
            this.employeesRepository = employeesRepository;
            this.assignmentsRepository = assignmentsRepository;
        }

        public int GetAssignmentsCount()
        {
            return this.assignmentsRepository
                .AllAsNoTracking()
                .Count();
        }

        public int GetEmployeesCount()
        {
            return this.employeesRepository
                .AllAsNoTracking()
                .Count();
        }

        public int GetEmployeesCountByName(string name)
        {
            return this.employeesRepository
                .AllAsNoTracking()
                .Where(x => x.FirstName.ToLower().Contains(name.ToLower()) || x.LastName.ToLower().Contains(name.ToLower()))
                .Count();
        }
    }
}
