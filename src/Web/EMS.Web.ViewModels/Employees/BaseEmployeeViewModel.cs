namespace EMS.Web.ViewModels.Employees
{
    using System;

    public abstract class BaseEmployeeViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime DateOfBirth { get; set; }

        public double MonthlySalary { get; set; }

        public string AddedByUserUserName { get; set; }
    }
}
