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

        public CountsService(IDeletableEntityRepository<Employee> employeesRepository)
        {
            this.employeesRepository = employeesRepository;
        }

        public int GetEmployeesCount()
        {
            return this.employeesRepository
                .AllAsNoTracking()
                .Count();
        }
    }
}
