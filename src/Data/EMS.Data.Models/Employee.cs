namespace EMS.Data.Models
{
    using System;
    using System.Collections.Generic;

    using EMS.Data.Common.Models;

    public class Employee : BaseDeletableModel<int>
    {
        public Employee()
        {
            this.Assignments = new HashSet<EmployeeAssignment>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime DateOfBirth { get; set; }

        public double MonthlySalary { get; set; }

        public ICollection<EmployeeAssignment> Assignments { get; set; }

        public string AddedByUserId { get; set; }

        public ApplicationUser AddedByUser { get; set; }
    }
}
